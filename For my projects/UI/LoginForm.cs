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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void processLogin()
        {
            int userId = DBWork.loginUser(PasswordInput.Text);
            if (userId == 0)
            {
                System.Windows.Forms.MessageBox.Show("Неверный пароль!");
            }
            else if (userId == 1)
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                User user = DBWork.getUserDetails(userId);
                if (user == null)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка логина. Обратитесь к администратору");
                }
                else
                {
                    if (user.IsTeacher)
                    {
                        TeacherForm teacherForm = new TeacherForm(user);
                        teacherForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        QuestionForm questionForm = new QuestionForm(user);
                        questionForm.Show();
                        this.Hide();
                    }
                }
            }
        }

        public void clearPass()
        {
            this.PasswordInput.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            processLogin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void PasswordInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                processLogin();
            }
            else {
                char number = e.KeyChar;

                if (!Char.IsDigit(number) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
