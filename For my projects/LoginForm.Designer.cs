namespace For_my_projects
{
    partial class LoginForm
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginCancel = new System.Windows.Forms.Button();
            this.LoginText = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.PasswordInstruct = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginButton.Location = new System.Drawing.Point(59, 90);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(107, 23);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Войти";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginCancel
            // 
            this.LoginCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginCancel.Location = new System.Drawing.Point(288, 90);
            this.LoginCancel.Name = "LoginCancel";
            this.LoginCancel.Size = new System.Drawing.Size(104, 23);
            this.LoginCancel.TabIndex = 1;
            this.LoginCancel.Text = "Отмена";
            this.LoginCancel.UseVisualStyleBackColor = true;
            this.LoginCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoginText
            // 
            this.LoginText.AutoSize = true;
            this.LoginText.Font = new System.Drawing.Font("Times New Roman", 12.2F);
            this.LoginText.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LoginText.Location = new System.Drawing.Point(1, 9);
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(433, 19);
            this.LoginText.TabIndex = 2;
            this.LoginText.Text = "Добро пожаловать! Для прохождения теста введите пароль.";
            this.LoginText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LoginText.Click += new System.EventHandler(this.label1_Click);
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(130, 51);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(178, 20);
            this.PasswordInput.TabIndex = 3;
            this.PasswordInput.TextChanged += new System.EventHandler(this.PasswordInput_TextChanged);
            // 
            // PasswordInstruct
            // 
            this.PasswordInstruct.AutoSize = true;
            this.PasswordInstruct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordInstruct.Location = new System.Drawing.Point(63, 50);
            this.PasswordInstruct.Name = "PasswordInstruct";
            this.PasswordInstruct.Size = new System.Drawing.Size(61, 19);
            this.PasswordInstruct.TabIndex = 4;
            this.PasswordInstruct.Text = "Пароль:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 142);
            this.Controls.Add(this.PasswordInstruct);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.LoginText);
            this.Controls.Add(this.LoginCancel);
            this.Controls.Add(this.LoginButton);
            this.Name = "LoginForm";
            this.Text = "Вход в систему";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button LoginCancel;
        private System.Windows.Forms.Label LoginText;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label PasswordInstruct;
    }
}

