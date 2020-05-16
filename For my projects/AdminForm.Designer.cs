namespace For_my_projects
{
    partial class AdminForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddListUsers = new System.Windows.Forms.Button();
            this.DeleteListUsers = new System.Windows.Forms.Button();
            this.GetPasswords = new System.Windows.Forms.Button();
            this.Instruction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddListUsers
            // 
            this.AddListUsers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddListUsers.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AddListUsers.Font = new System.Drawing.Font("Times New Roman", 12.25F);
            this.AddListUsers.Location = new System.Drawing.Point(26, 93);
            this.AddListUsers.Name = "AddListUsers";
            this.AddListUsers.Size = new System.Drawing.Size(140, 55);
            this.AddListUsers.TabIndex = 0;
            this.AddListUsers.Text = "Добавить список учеников";
            this.AddListUsers.UseVisualStyleBackColor = true;
            // 
            // DeleteListUsers
            // 
            this.DeleteListUsers.Font = new System.Drawing.Font("Times New Roman", 12.25F);
            this.DeleteListUsers.Location = new System.Drawing.Point(381, 93);
            this.DeleteListUsers.Name = "DeleteListUsers";
            this.DeleteListUsers.Size = new System.Drawing.Size(140, 55);
            this.DeleteListUsers.TabIndex = 1;
            this.DeleteListUsers.Text = "Удалить список учеников";
            this.DeleteListUsers.UseVisualStyleBackColor = true;
            // 
            // GetPasswords
            // 
            this.GetPasswords.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.GetPasswords.Font = new System.Drawing.Font("Times New Roman", 12.25F);
            this.GetPasswords.Location = new System.Drawing.Point(195, 93);
            this.GetPasswords.Name = "GetPasswords";
            this.GetPasswords.Size = new System.Drawing.Size(140, 55);
            this.GetPasswords.TabIndex = 2;
            this.GetPasswords.Text = "Получить пароли";
            this.GetPasswords.UseVisualStyleBackColor = true;
            this.GetPasswords.Click += new System.EventHandler(this.GetPasswords_Click);
            // 
            // Instruction
            // 
            this.Instruction.AutoSize = true;
            this.Instruction.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Instruction.Location = new System.Drawing.Point(22, 32);
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new System.Drawing.Size(170, 21);
            this.Instruction.TabIndex = 3;
            this.Instruction.Text = "Выберите действие:";
            this.Instruction.Click += new System.EventHandler(this.label1_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(545, 195);
            this.Controls.Add(this.Instruction);
            this.Controls.Add(this.GetPasswords);
            this.Controls.Add(this.DeleteListUsers);
            this.Controls.Add(this.AddListUsers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.Text = "Режим(Администратор)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddListUsers;
        private System.Windows.Forms.Button DeleteListUsers;
        private System.Windows.Forms.Button GetPasswords;
        private System.Windows.Forms.Label Instruction;
    }
}

