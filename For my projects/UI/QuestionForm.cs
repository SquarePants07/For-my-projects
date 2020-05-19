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
    public partial class QuestionForm : Form
    {
        private User currentUser;
        private List<Question> questions;
        private int currentQuestionIndex;
        private List<Answer> answers;
        PupilGroup group;
       
        public QuestionForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            group = DBWork.getPupilGroup(currentUser.ClassId);
            this.Text += " " + currentUser.ToString() + " " + group.ToString();
            questions = DBWork.getAllQuestions();
            answers = new List<Answer>();
            currentQuestionIndex = 0;
            loadClassmates();

            TextQuestion.Text = questions.ElementAt(currentQuestionIndex).ToString();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
        }

        private void loadClassmates()
        {
            List<User> users = DBWork.getClassmates(currentUser.ClassId);
            User defaultUser = new User(0, 0, "Выберите одноклассника", 0, 0);
            this.comboBox1.Items.Add(defaultUser);
            foreach (User user in users)
            {
                if (currentUser.Id != user.Id)
                    this.comboBox1.Items.Add(user);
            };

            this.comboBox2.Items.Add(defaultUser);
            foreach (User user in users)
            {
                if(currentUser.Id != user.Id)
                    this.comboBox2.Items.Add(user);
            };

            this.comboBox3.Items.Add(defaultUser);
            foreach (User user in users)
            {
                if (currentUser.Id != user.Id)
                    this.comboBox3.Items.Add(user);
            };

            this.comboBox4.Items.Add(defaultUser);
            foreach (User user in users)
            {
                if (currentUser.Id != user.Id)
                    this.comboBox4.Items.Add(user);
            };

            this.comboBox5.Items.Add(defaultUser);
            foreach (User user in users)
            {
                if (currentUser.Id != user.Id)
                    this.comboBox5.Items.Add(user);
            };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TextQuestion_TextChanged(object sender, EventArgs e)
        {

        }

        private void Answer1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0 && comboBox2.SelectedIndex > 0 && comboBox3.SelectedIndex > 0 && comboBox4.SelectedIndex > 0 && comboBox5.SelectedIndex > 0)
            {
                if (checkUniqueIds())
                {
                    List<Int32> questionAnswers = new List<Int32>();
                    questionAnswers.Add(((User)comboBox1.SelectedItem).Id);
                    questionAnswers.Add(((User)comboBox2.SelectedItem).Id);
                    questionAnswers.Add(((User)comboBox3.SelectedItem).Id);
                    questionAnswers.Add(((User)comboBox4.SelectedItem).Id);
                    questionAnswers.Add(((User)comboBox5.SelectedItem).Id);

                    answers.Add(new Answer(currentUser.Id, currentQuestionIndex + 1, questionAnswers));

                    currentQuestionIndex++;
                    if (currentQuestionIndex == 4) {
                        EndTestButton.Text = "Завершить";
                    }

                    if (currentQuestionIndex < 5)
                    {
                        TextQuestion.Text = questions.ElementAt(currentQuestionIndex).ToString();
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = 0;
                        comboBox3.SelectedIndex = 0;
                        comboBox4.SelectedIndex = 0;
                        comboBox5.SelectedIndex = 0;
                    }
                    else {
                        try
                        {
                            DBWork.commitAnswers(answers);
                            System.Windows.Forms.MessageBox.Show("Спасибо за прохождение теста!");
                            Program.returnToLoginForm();
                            this.Close();
                        }
                        catch (Exception ex) {
                            System.Windows.Forms.MessageBox.Show("Ошибка при сохранении результатов! Обратитесь к администратору");
                            Program.returnToLoginForm();
                            this.Close();
                        }
                    }
                }
                else {
                    System.Windows.Forms.MessageBox.Show("Все ответы должны отличаться друг от друга");
                }
            }
            else {
                System.Windows.Forms.MessageBox.Show("Выберите варианты во всех пяти ответах");
            }
        }

        private bool checkUniqueIds()
        {
            HashSet<Int32> idSet = new HashSet<Int32>();
            idSet.Add(((User)comboBox1.SelectedItem).Id);
            idSet.Add(((User)comboBox2.SelectedItem).Id);
            idSet.Add(((User)comboBox3.SelectedItem).Id);
            idSet.Add(((User)comboBox4.SelectedItem).Id);
            idSet.Add(((User)comboBox5.SelectedItem).Id);
            if (idSet.Count == 5)
                return true;
            else
                return false;
        }

        protected override void OnClosed(EventArgs e)
        {
            Program.returnToLoginForm();
            base.OnClosed(e);
        }
    }
}
