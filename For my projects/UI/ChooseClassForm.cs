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
    public partial class ChooseClassForm : Form
    {
        private List<PupilGroup> pupilGroups;
        SaveFileDialog saveFileDialog;
        int mode;
        public ChooseClassForm(int mode)
        {
            InitializeComponent();
            loadPupilGroups();
            this.mode = mode;
            switch (mode){
                case 1:
                    label1.Text = "Выберите класс для удаления";
                    button1.Text = "Удалить";
                    break;
                case 2:
                    label1.Text = "Выберите класс для выгрузки паролей";
                    button1.Text = "Выгрузить";
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files(*.txt)|*.txt";
                    break;
            }
        }

        private void loadPupilGroups()
        {
            pupilGroups = DBWork.getAllPupilGroups();
            PupilGroup defaultGroup = new PupilGroup(0, "Все классы", -1);
            this.comboBox1.Items.Add(defaultGroup);
            foreach (PupilGroup group in pupilGroups) {
                this.comboBox1.Items.Add(group);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            PupilGroup pupilGroup = (PupilGroup)comboBox1.SelectedItem;
            int selectedIndex = comboBox1.SelectedIndex;
            switch (mode)
            {
                case 1:
                    DBWork.deleteUsersFromPupilGroup(pupilGroup.Id);
                    comboBox1.SelectedIndex = 0;
                    comboBox1.Items.RemoveAt(selectedIndex);
                    System.Windows.Forms.MessageBox.Show("Данные удалены");
                    break;
                case 2:
                    String passwords = DBWork.getUserPasswords(pupilGroup.Id);
                    if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                        return;
                    String filename = saveFileDialog.FileName;
                    System.IO.File.WriteAllText(filename, passwords);
                    break;
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
