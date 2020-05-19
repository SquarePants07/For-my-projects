using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_my_projects
{
    public partial class AdminForm : Form
    {
        int DELETE_USERS_MODE = 1;
        int DOWNLOAD_PASSWORDS_MODE = 2;

        OpenFileDialog openFileDialog;
        public AdminForm()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files(*.csv)|*.csv";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GetPasswords_Click(object sender, EventArgs e)
        {
            ChooseClassForm chooseClassForm = new ChooseClassForm(DOWNLOAD_PASSWORDS_MODE);
            chooseClassForm.Show();
        }

        private void DeleteListUsers_Click(object sender, EventArgs e)
        {
            ChooseClassForm chooseClassForm = new ChooseClassForm(DELETE_USERS_MODE);
            chooseClassForm.Show();
        }

        private void AddListUsers_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            String filename = openFileDialog.FileName;
            try
            {
                StreamReader reader = new StreamReader(filename);
                int count = 1;
                String errorMessage = "";
                while (!reader.EndOfStream)
                {
                    try
                    {
                        String nextLine = reader.ReadLine();
                        String[] values = nextLine.Split(';');
                        String fio = values[0] + " " + values[1] + " " + values[2];
                        int number = Int32.Parse(values[3]);
                        String litera = values[4];
                        bool isTeacher = false;
                        if (count == 1)
                            isTeacher = true;
                        String password = DBWork.generatePassword(6);
                        DBWork.addUser(fio, litera, number, isTeacher, password);
                    }
                    catch (Exception ex)
                    {
                        errorMessage += "\nОшибка в строке " + count;
                    }
                    count++;
                }
                System.Windows.Forms.MessageBox.Show("Обработано " + count + " строк " + errorMessage);
            }
            catch (IOException ioe) {
                System.Windows.Forms.MessageBox.Show(ioe.Message);

            }
        }
        protected override void OnClosed(EventArgs e) {
            Program.returnToLoginForm();
            base.OnClosed(e);
        }
    }
}
