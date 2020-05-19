using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using For_my_projects.DataModel;
using MySql.Data.MySqlClient;

namespace For_my_projects
{
    class DBWork
    {

        static MySqlConnection connection;

        static public void Init()
        {
            connection = new MySqlConnection();
            connection.ConnectionString =
                "Data Source=127.0.0.1;" +
                "Initial Catalog=psychologytest;" +
                "User id=root;" +
                "Password=25011994;";
            connection.Open();
        }

        public static Dictionary<User, List<Answer>> getAllResultsByTeacher(User currentUser)
        {
            Dictionary<User, List<Answer>> results = new Dictionary<User, List<Answer>>();
            List<User> users = getClassmates(currentUser.ClassId);
            foreach (User user in users) {
                String query = "SELECT * FROM results WHERE idusers = " + user.Id + " ORDER BY idquestions";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = connection;
                MySqlDataReader data = command.ExecuteReader();
                if (data.HasRows)
                {
                    List<Answer> answers = new List<Answer>();
                    while (data.Read())
                    {
                        List<Int32> questionAnswers = new List<Int32>();
                        questionAnswers.Add(data.GetInt32(2));
                        questionAnswers.Add(data.GetInt32(3));
                        questionAnswers.Add(data.GetInt32(4));
                        questionAnswers.Add(data.GetInt32(5));
                        questionAnswers.Add(data.GetInt32(6));
                        answers.Add(new Answer(data.GetInt32(0), data.GetInt32(1), questionAnswers));
                    }
                    data.Close(); 
                    results.Add(user, answers);
                }
                else {
                    data.Close();
                    results.Add(user, new List<Answer>());
                }
            }
            return results;
        }

        public static PupilGroup getPupilGroup(int classId)
        {
            PupilGroup pupilGroup = null;
            String query = "SELECT * FROM classes WHERE idclasses = " + classId;
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;
            MySqlDataReader data = command.ExecuteReader();
            if (data.HasRows)
            {
                data.Read();
                pupilGroup = new PupilGroup(data.GetInt32(0), data.GetString(1), data.GetInt32(2));
            }
            data.Close();
            return pupilGroup;
        }

        static public int loginUser(String password)
        {
            String query = "SELECT idUsers FROM users WHERE Password = " + password;
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;
            MySqlDataReader data = command.ExecuteReader();
            int userId = 0;
            if (data.HasRows)
            {
                data.Read();
                userId = data.GetInt32(0);
            }
            data.Close();
            return userId;
        }

        static public User getUserDetails(int id)
        {
            String query = "SELECT idUsers, IsTeacher, Usersname, idstatus, idclasses FROM users WHERE idUsers = " + id;
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;
            MySqlDataReader data = command.ExecuteReader();
            User user = null;
            if (data.HasRows)
            {
                data.Read();
                int statusId = 0;
                if (!data.IsDBNull(3)) {
                    statusId = data.GetInt32(3);
                }
                user = new User(data.GetInt32(0), data.GetByte(1), data.GetString(2), statusId, data.GetInt32(4));
            }
            data.Close();
            return user;

        }

        public static List<User> getClassmates(int classId)
        {
            List<User> users = new List<User>();
            String query = "SELECT idUsers, IsTeacher, Usersname, idstatus, idclasses FROM users WHERE idclasses = " + classId + " AND IsTeacher = 0 ORDER BY Usersname";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;
            MySqlDataReader data = command.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    int statusId = 0;
                    if (!data.IsDBNull(3))
                    {
                        statusId = data.GetInt32(3);
                    }
                    users.Add(new User(data.GetInt32(0), data.GetInt32(1), data.GetString(2), statusId, data.GetInt32(4)));
                }
            }
            data.Close();
            return users;
        }

        public static void deleteUsersFromPupilGroup(int pupilGroupId) {
            List<Int32> userIds = new List<Int32>();
            String query = ""; 
            if(pupilGroupId == -1)
                query = "SELECT idUsers FROM users WHERE idclasses <> 1";
            else
                query = "SELECT idUsers FROM users WHERE idclasses = " + pupilGroupId;
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;
            MySqlDataReader data = command.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    userIds.Add(data.GetInt32(0));
                }
            }
            data.Close();
            foreach (Int32 id in userIds)
            {
                query = "DELETE FROM results WHERE idusers = " + id;
                MySqlCommand deleteResultCommand = new MySqlCommand(query);
                deleteResultCommand.Connection = connection;
                deleteResultCommand.ExecuteNonQuery();

                query = "DELETE FROM users WHERE idusers = " + id;
                MySqlCommand deleteUserCommand = new MySqlCommand(query);
                deleteUserCommand.Connection = connection;
                deleteUserCommand.ExecuteNonQuery();
            }

            if (pupilGroupId == -1)
                query = "DELETE FROM classes WHERE idclasses <> 1";
            else
                query = "DELETE FROM classes WHERE idclasses = " + pupilGroupId;
            
            MySqlCommand deletePupilGroupCommand = new MySqlCommand(query);
            deletePupilGroupCommand.Connection = connection;
            deletePupilGroupCommand.ExecuteNonQuery();
        }

        public static string generatePassword(int length)
        {
            int i = 0;
            while (i < 5)
            {
                const string valid = "1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < length--)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                }
                String query = "SELECT Password FROM users WHERE Password = '" + res.ToString() + "'";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = connection;
                MySqlDataReader data = command.ExecuteReader();
                if (!data.HasRows)
                    data.Close();
                    return res.ToString();
                i++;
            }
            throw new Exception();
        }

        public static void addUser(string fio, string litera, int number, bool isTeacher, String password)
        {
            String query = "SELECT idclasses FROM classes WHERE classeslitera = '" + litera + "' AND Classesnum = " + number;
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;
            MySqlDataReader data = command.ExecuteReader();
            if (!data.HasRows)
            {
                data.Close();
                query = "INSERT INTO classes (classeslitera, Classesnum) VALUES('" + litera + "', " + number + ")";
                MySqlCommand insertClassCommand = new MySqlCommand(query);
                insertClassCommand.Connection = connection;
                insertClassCommand.ExecuteNonQuery();

                query = "SELECT idclasses FROM classes WHERE classeslitera = '" + litera + "' AND Classesnum = " + number;
                data = command.ExecuteReader();
                if (!data.HasRows) {
                    throw new Exception();
                }
            }

            data.Read();
            int pupilGroupId = data.GetInt32(0);
            data.Close();
            
            query = "INSERT INTO users (Usersname, Password, idclasses, IsTeacher) VALUES('" + fio + "', '" + password + "', " + pupilGroupId + ", ";
            if (isTeacher)
            {
                query += "1)";
            }
            else {
                query += "0)";
            }

            MySqlCommand insertUserCommand = new MySqlCommand(query);
            insertUserCommand.Connection = connection;
            insertUserCommand.ExecuteNonQuery();
        }

        public static string getUserPasswords(int pupilGroupId)
        {
            String result = "";
            String query = "";
            if (pupilGroupId == -1)
                query = "SELECT Usersname, Password FROM users WHERE idclasses <> 1";
            else
                query = "SELECT Usersname, Password FROM users WHERE idclasses = " + pupilGroupId;
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;
            MySqlDataReader data = command.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    result += "ФИО: " + data.GetString(0) + " Пароль: " + data.GetString(1) + "\n\r";
                }
            }
            data.Close();
            return result;
        }

        public static List<PupilGroup> getAllPupilGroups()
        {
            List<PupilGroup> pupilGroups = new List<PupilGroup>();
            String query = "SELECT * FROM classes WHERE idclasses <> 1";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;
            MySqlDataReader data = command.ExecuteReader();
            if (data.HasRows) {
                while (data.Read()) {
                    pupilGroups.Add(new PupilGroup(data.GetInt32(0), data.GetString(1), data.GetInt32(2)));
                }
            }
            data.Close();
            return pupilGroups;
        }

        public static List<Question> getAllQuestions()
        {
            List<Question> questions = new List<Question>();
            String query = "SELECT * FROM questions ORDER BY idquestions";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;
            MySqlDataReader data = command.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    questions.Add(new Question(data.GetInt32(0), data.GetString(1), data.GetByte(2)));
                }
            }
            data.Close();
            return questions;
        }

        public static void commitAnswers(List<Answer> answers)
        {
            foreach (Answer answer in answers) {
                String query = "SELECT idusers FROM results WHERE idusers = " + answer.UserId + " AND idquestions = " + answer.QuestionId;
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = connection;
                MySqlDataReader data = command.ExecuteReader();

                if (!data.HasRows)
                {
                    data.Close();
                    query = "INSERT INTO results (idusers, idquestions, ans_1, ans_2, ans_3, ans_4, ans_5) VALUES(" + answer.UserId + ", " + answer.QuestionId + ", " + answer.getAnswerAt(0) + ", " + answer.getAnswerAt(1) + ", " + answer.getAnswerAt(2) + ", " + answer.getAnswerAt(3) + ", " + answer.getAnswerAt(4) + ")";
                    MySqlCommand insertAnswerCommand = new MySqlCommand(query);
                    insertAnswerCommand.Connection = connection;
                    insertAnswerCommand.ExecuteNonQuery();
                }
                else {
                    data.Close();
                    query = "UPDATE results SET ans_1 = " + answer.getAnswerAt(0) + ", ans_2 = " + answer.getAnswerAt(1) + ", ans_3 = " + answer.getAnswerAt(2) + ", ans_4 = " + answer.getAnswerAt(3) + ", ans_5 = " + answer.getAnswerAt(4) + " WHERE idusers = " + answer.UserId + " AND idquestions = " + answer.QuestionId;
                    MySqlCommand updateAnswerCommand = new MySqlCommand(query);
                    updateAnswerCommand.Connection = connection;
                    updateAnswerCommand.ExecuteNonQuery();
                }
            }
        }

        public static List<Status> getAllStatuses()
        {
            List<Status> statuses = new List<Status>();
            String query = "SELECT * FROM statusdictionary ORDER BY idstatus";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;
            MySqlDataReader data = command.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    statuses.Add(new Status(data.GetInt32(0), data.GetString(1)));
                }
            }
            data.Close();
            return statuses;
        }
    }
}
