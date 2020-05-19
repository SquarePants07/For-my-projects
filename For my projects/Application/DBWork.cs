using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                "Password=89197174637;";
            connection.Open();
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
    }
}
