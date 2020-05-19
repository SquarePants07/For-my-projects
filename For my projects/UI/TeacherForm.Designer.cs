namespace For_my_projects
{
    partial class TeacherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Results = new System.Windows.Forms.ListView();
            this.CountUsers = new System.Windows.Forms.TextBox();
            this.Welfare = new System.Windows.Forms.TextBox();
            this.Reciprocity = new System.Windows.Forms.TextBox();
            this.Donloadresults = new System.Windows.Forms.Button();
            this.TeacherCancelButton = new System.Windows.Forms.Button();
            this.CountUsersTest = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Results
            // 
            this.Results.HideSelection = false;
            this.Results.Location = new System.Drawing.Point(355, 22);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(482, 323);
            this.Results.TabIndex = 0;
            this.Results.UseCompatibleStateImageBehavior = false;
            // 
            // CountUsers
            // 
            this.CountUsers.Location = new System.Drawing.Point(28, 115);
            this.CountUsers.Name = "CountUsers";
            this.CountUsers.ReadOnly = true;
            this.CountUsers.Size = new System.Drawing.Size(308, 26);
            this.CountUsers.TabIndex = 1;
            // 
            // Welfare
            // 
            this.Welfare.Location = new System.Drawing.Point(28, 215);
            this.Welfare.Name = "Welfare";
            this.Welfare.ReadOnly = true;
            this.Welfare.Size = new System.Drawing.Size(308, 26);
            this.Welfare.TabIndex = 2;
            // 
            // Reciprocity
            // 
            this.Reciprocity.Location = new System.Drawing.Point(28, 319);
            this.Reciprocity.Name = "Reciprocity";
            this.Reciprocity.ReadOnly = true;
            this.Reciprocity.Size = new System.Drawing.Size(308, 26);
            this.Reciprocity.TabIndex = 3;
            // 
            // Donloadresults
            // 
            this.Donloadresults.Location = new System.Drawing.Point(355, 365);
            this.Donloadresults.Name = "Donloadresults";
            this.Donloadresults.Size = new System.Drawing.Size(193, 35);
            this.Donloadresults.TabIndex = 4;
            this.Donloadresults.Text = "Скачать результаты";
            this.Donloadresults.UseVisualStyleBackColor = true;
            // 
            // TeacherCancelButton
            // 
            this.TeacherCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.TeacherCancelButton.Location = new System.Drawing.Point(613, 365);
            this.TeacherCancelButton.Name = "TeacherCancelButton";
            this.TeacherCancelButton.Size = new System.Drawing.Size(193, 35);
            this.TeacherCancelButton.TabIndex = 5;
            this.TeacherCancelButton.Text = "Отмена";
            this.TeacherCancelButton.UseVisualStyleBackColor = true;
            // 
            // CountUsersTest
            // 
            this.CountUsersTest.AutoSize = true;
            this.CountUsersTest.Location = new System.Drawing.Point(24, 82);
            this.CountUsersTest.Name = "CountUsersTest";
            this.CountUsersTest.Size = new System.Drawing.Size(229, 19);
            this.CountUsersTest.TabIndex = 6;
            this.CountUsersTest.Text = "Количество пройденных тестов:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Коэффициент благополучия класса:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Количество взаимных выборов:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.TeacherCancelButton;
            this.ClientSize = new System.Drawing.Size(862, 412);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CountUsersTest);
            this.Controls.Add(this.TeacherCancelButton);
            this.Controls.Add(this.Donloadresults);
            this.Controls.Add(this.Reciprocity);
            this.Controls.Add(this.Welfare);
            this.Controls.Add(this.CountUsers);
            this.Controls.Add(this.Results);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TeacherForm";
            this.Text = "Режим(Учитель)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Results;
        private System.Windows.Forms.TextBox CountUsers;
        private System.Windows.Forms.TextBox Welfare;
        private System.Windows.Forms.TextBox Reciprocity;
        private System.Windows.Forms.Button Donloadresults;
        private System.Windows.Forms.Button TeacherCancelButton;
        private System.Windows.Forms.Label CountUsersTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}