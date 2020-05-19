using For_my_projects.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_my_projects
{
    public partial class TeacherForm : Form
    {
        User currentUser;
        Dictionary<User, List<Answer>> results;
        int totalTests;
        List<Question> questions;
        List<Status> statuses;
        int totalK;
        int totalC;
        int N;
        PupilGroup group;

        SaveFileDialog saveFileDialog;

        public TeacherForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            group = DBWork.getPupilGroup(currentUser.ClassId);
            this.Text += " " + currentUser.ToString() + " " + group.ToString();
            results = new Dictionary<User, List<Answer>>();
            totalTests = 0;
            totalK = 0;
            N = 0;
            questions = DBWork.getAllQuestions();
            statuses = DBWork.getAllStatuses();
            countResults();
            fillTable();
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files(*.txt)|*.txt";
        }

        private void countResults()
        {
            results = DBWork.getAllResultsByTeacher(currentUser);

            N = results.Count;

            foreach (User user in results.Keys) {
                if (results[user].Count == 5) {
                    totalTests++;
                }
            }
            CountUsers.Text = totalTests + "";

            foreach (User currentUser in results.Keys) {
                foreach (User user in results.Keys) {
                    if (currentUser.Id != user.Id) {
                        foreach (Answer answer in results[user]) {
                            if (answer.contains(currentUser.Id)) {
                                if (questions.ElementAt(answer.QuestionId - 1).IsGood)
                                {
                                    currentUser.addP();
                                }
                                else {
                                    currentUser.addC();
                                }
                            }
                        }
                    }
                }

                if (currentUser.P > 0)
                {
                    if (currentUser.P >= currentUser.C)
                    {
                        if ((double)currentUser.C / (double)currentUser.P < 0.5)
                        {
                            currentUser.StatusId = 1; //звезда
                        }
                        else
                        {
                            currentUser.StatusId = 2; //среднестатусный
                        }
                    }
                    else
                    {
                        currentUser.StatusId = 3; //пренебрегаемый
                    }
                }
                else {
                    if (currentUser.C == 0)
                    {
                        currentUser.StatusId = 4; //изолируемый
                    }
                    else {
                        currentUser.StatusId = 5; //изгой
                    }
                }

            }

            foreach (User currentUser in results.Keys)
            {
                foreach (Answer answer in results[currentUser])
                {
                    for (int i = 0; i < answer.Answers.Count; i++)
                    {
                        int userId = answer.getAnswerAt(i);
                        foreach (User user in results.Keys)
                        {
                            if (user.Id == userId)
                            {
                                foreach (Answer userAnswer in results[currentUser])
                                {
                                    if (answer.QuestionId == userAnswer.QuestionId && userAnswer.contains(currentUser.Id))
                                    {
                                        totalK++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Reciprocity.Text = totalK + "";

            totalC = totalK / (N * (N - 1) / 2);

            Welfare.Text = totalC + "";
        }

        private void fillTable()
        {
            foreach (User user in results.Keys) {
                ListViewItem listViewItem = new ListViewItem(user.ToString());
                listViewItem.SubItems.Add(statuses.ElementAt(user.StatusId - 1).ToString());
                if (results[user].Count == 5)
                {
                    listViewItem.SubItems.Add("Да");
                }
                else {
                    listViewItem.SubItems.Add("Нет");
                }
                listView1.Items.Add(listViewItem);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            Program.returnToLoginForm();
            base.OnClosed(e);
        }

        private void TeacherCancelButton_Click(object sender, EventArgs e)
        {
            Program.returnToLoginForm();
            this.Close();
        }

        private void Donloadresults_Click(object sender, EventArgs e)
        {
            String result = "Класс: " + group.ToString() + "\n";
            result += "Количество пройденных тестов: " + totalTests + "\n";
            result += "Коэффициент благополучия класса: " + totalC + "\n";
            result += "Количество взаимных выборов: " + totalK + "\n";
            result += " __________________________________________________________________________________ " + "\n";
            result += "|                     ФИО                     |         Статус         | Сдан тест |" + "\n";
            result += "|_____________________________________________|________________________|___________|" + "\n";
            foreach (User currentUser in results.Keys)
            {
                result += "|";
                result += currentUser.ToString();
                int freeSpace = 45 - currentUser.ToString().Length;
                for (int i = 0; i < freeSpace; i++) {
                    result += " ";
                }
                result += "|";
                String statusName = statuses.ElementAt(currentUser.StatusId - 1).ToString();
                result += statusName;

                freeSpace = 24 - statusName.Length;
                for (int i = 0; i < freeSpace; i++)
                {
                    result += " ";
                }

                result += "|";
                if (results[currentUser].Count == 5)
                {
                    result +=  "Да ";
                }
                else
                {
                    result += "Нет";
                }
                result += "        ";
                result += "|" + "\n";
                result += "|_____________________________________________|________________________|___________|" + "\n";
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            String filename = saveFileDialog.FileName;
            System.IO.File.WriteAllText(filename, result);
        }
    }
}
