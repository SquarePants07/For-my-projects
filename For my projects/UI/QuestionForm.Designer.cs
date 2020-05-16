namespace For_my_projects
{
    partial class QuestionForm
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
            this.Answer1 = new System.Windows.Forms.ListBox();
            this.Answer2 = new System.Windows.Forms.ListBox();
            this.Answer3 = new System.Windows.Forms.ListBox();
            this.Answer4 = new System.Windows.Forms.ListBox();
            this.Answer5 = new System.Windows.Forms.ListBox();
            this.NextQuestion = new System.Windows.Forms.Button();
            this.TextQuestion = new System.Windows.Forms.TextBox();
            this.NumAswerTxt3 = new System.Windows.Forms.Label();
            this.NumAswerTxt4 = new System.Windows.Forms.Label();
            this.NumAswerTxt5 = new System.Windows.Forms.Label();
            this.NumAswerTxt2 = new System.Windows.Forms.Label();
            this.NumAswerTxt1 = new System.Windows.Forms.Label();
            this.EndTestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Answer1
            // 
            this.Answer1.FormattingEnabled = true;
            this.Answer1.ItemHeight = 19;
            this.Answer1.Location = new System.Drawing.Point(39, 103);
            this.Answer1.Margin = new System.Windows.Forms.Padding(4);
            this.Answer1.Name = "Answer1";
            this.Answer1.Size = new System.Drawing.Size(282, 42);
            this.Answer1.TabIndex = 0;
            this.Answer1.SelectedIndexChanged += new System.EventHandler(this.Answer1_SelectedIndexChanged);
            // 
            // Answer2
            // 
            this.Answer2.FormattingEnabled = true;
            this.Answer2.ItemHeight = 19;
            this.Answer2.Location = new System.Drawing.Point(39, 175);
            this.Answer2.Margin = new System.Windows.Forms.Padding(4);
            this.Answer2.Name = "Answer2";
            this.Answer2.Size = new System.Drawing.Size(282, 42);
            this.Answer2.TabIndex = 1;
            // 
            // Answer3
            // 
            this.Answer3.FormattingEnabled = true;
            this.Answer3.ItemHeight = 19;
            this.Answer3.Location = new System.Drawing.Point(426, 103);
            this.Answer3.Margin = new System.Windows.Forms.Padding(4);
            this.Answer3.Name = "Answer3";
            this.Answer3.Size = new System.Drawing.Size(282, 42);
            this.Answer3.TabIndex = 2;
            // 
            // Answer4
            // 
            this.Answer4.FormattingEnabled = true;
            this.Answer4.ItemHeight = 19;
            this.Answer4.Location = new System.Drawing.Point(426, 175);
            this.Answer4.Margin = new System.Windows.Forms.Padding(4);
            this.Answer4.Name = "Answer4";
            this.Answer4.Size = new System.Drawing.Size(282, 42);
            this.Answer4.TabIndex = 3;
            // 
            // Answer5
            // 
            this.Answer5.FormattingEnabled = true;
            this.Answer5.ItemHeight = 19;
            this.Answer5.Location = new System.Drawing.Point(218, 248);
            this.Answer5.Margin = new System.Windows.Forms.Padding(4);
            this.Answer5.Name = "Answer5";
            this.Answer5.Size = new System.Drawing.Size(282, 42);
            this.Answer5.TabIndex = 4;
            // 
            // NextQuestion
            // 
            this.NextQuestion.Location = new System.Drawing.Point(310, 309);
            this.NextQuestion.Margin = new System.Windows.Forms.Padding(4);
            this.NextQuestion.Name = "NextQuestion";
            this.NextQuestion.Size = new System.Drawing.Size(190, 41);
            this.NextQuestion.TabIndex = 5;
            this.NextQuestion.Text = "Следующий вопрос";
            this.NextQuestion.UseVisualStyleBackColor = true;
            // 
            // TextQuestion
            // 
            this.TextQuestion.Location = new System.Drawing.Point(39, 37);
            this.TextQuestion.Margin = new System.Windows.Forms.Padding(4);
            this.TextQuestion.Multiline = true;
            this.TextQuestion.Name = "TextQuestion";
            this.TextQuestion.ReadOnly = true;
            this.TextQuestion.Size = new System.Drawing.Size(667, 57);
            this.TextQuestion.TabIndex = 6;
            this.TextQuestion.TextChanged += new System.EventHandler(this.TextQuestion_TextChanged);
            // 
            // NumAswerTxt3
            // 
            this.NumAswerTxt3.AutoSize = true;
            this.NumAswerTxt3.Location = new System.Drawing.Point(401, 103);
            this.NumAswerTxt3.Name = "NumAswerTxt3";
            this.NumAswerTxt3.Size = new System.Drawing.Size(18, 19);
            this.NumAswerTxt3.TabIndex = 7;
            this.NumAswerTxt3.Text = "3";
            // 
            // NumAswerTxt4
            // 
            this.NumAswerTxt4.AutoSize = true;
            this.NumAswerTxt4.Location = new System.Drawing.Point(401, 175);
            this.NumAswerTxt4.Name = "NumAswerTxt4";
            this.NumAswerTxt4.Size = new System.Drawing.Size(18, 19);
            this.NumAswerTxt4.TabIndex = 8;
            this.NumAswerTxt4.Text = "4";
            this.NumAswerTxt4.Click += new System.EventHandler(this.label1_Click);
            // 
            // NumAswerTxt5
            // 
            this.NumAswerTxt5.AutoSize = true;
            this.NumAswerTxt5.Location = new System.Drawing.Point(193, 248);
            this.NumAswerTxt5.Name = "NumAswerTxt5";
            this.NumAswerTxt5.Size = new System.Drawing.Size(18, 19);
            this.NumAswerTxt5.TabIndex = 9;
            this.NumAswerTxt5.Text = "5";
            // 
            // NumAswerTxt2
            // 
            this.NumAswerTxt2.AutoSize = true;
            this.NumAswerTxt2.Location = new System.Drawing.Point(14, 175);
            this.NumAswerTxt2.Name = "NumAswerTxt2";
            this.NumAswerTxt2.Size = new System.Drawing.Size(18, 19);
            this.NumAswerTxt2.TabIndex = 10;
            this.NumAswerTxt2.Text = "2";
            this.NumAswerTxt2.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // NumAswerTxt1
            // 
            this.NumAswerTxt1.AutoSize = true;
            this.NumAswerTxt1.Location = new System.Drawing.Point(14, 103);
            this.NumAswerTxt1.Name = "NumAswerTxt1";
            this.NumAswerTxt1.Size = new System.Drawing.Size(18, 19);
            this.NumAswerTxt1.TabIndex = 11;
            this.NumAswerTxt1.Text = "1";
            this.NumAswerTxt1.Click += new System.EventHandler(this.label2_Click);
            // 
            // EndTestButton
            // 
            this.EndTestButton.Location = new System.Drawing.Point(542, 309);
            this.EndTestButton.Margin = new System.Windows.Forms.Padding(4);
            this.EndTestButton.Name = "EndTestButton";
            this.EndTestButton.Size = new System.Drawing.Size(190, 41);
            this.EndTestButton.TabIndex = 12;
            this.EndTestButton.Text = "Завершить";
            this.EndTestButton.UseVisualStyleBackColor = true;
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 385);
            this.Controls.Add(this.EndTestButton);
            this.Controls.Add(this.NumAswerTxt1);
            this.Controls.Add(this.NumAswerTxt2);
            this.Controls.Add(this.NumAswerTxt5);
            this.Controls.Add(this.NumAswerTxt4);
            this.Controls.Add(this.NumAswerTxt3);
            this.Controls.Add(this.TextQuestion);
            this.Controls.Add(this.NextQuestion);
            this.Controls.Add(this.Answer5);
            this.Controls.Add(this.Answer4);
            this.Controls.Add(this.Answer3);
            this.Controls.Add(this.Answer2);
            this.Controls.Add(this.Answer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.25F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuestionForm";
            this.Text = "Социометрический тест";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Answer1;
        private System.Windows.Forms.ListBox Answer2;
        private System.Windows.Forms.ListBox Answer3;
        private System.Windows.Forms.ListBox Answer4;
        private System.Windows.Forms.ListBox Answer5;
        private System.Windows.Forms.Button NextQuestion;
        private System.Windows.Forms.TextBox TextQuestion;
        private System.Windows.Forms.Label NumAswerTxt3;
        private System.Windows.Forms.Label NumAswerTxt4;
        private System.Windows.Forms.Label NumAswerTxt5;
        private System.Windows.Forms.Label NumAswerTxt2;
        private System.Windows.Forms.Label NumAswerTxt1;
        private System.Windows.Forms.Button EndTestButton;
    }
}