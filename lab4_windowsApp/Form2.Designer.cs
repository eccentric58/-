
namespace lab4_windowsApp
{
    partial class InputClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private bool state = true; // true - create;    false - find
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
        /// 
        public void convertToFindForm()
        {
            this.Text = "Поиск пользователя";
            createButton.Text = "Найти";
            jobLabel.Hide();
            job_textBox.Hide();
            state = false;
        }
        private void InitializeComponent()
        {
            FirstNameLabel = new Label();
            lastNameLabel = new Label();
            fatherNameLabel = new Label();
            yearOfBirthLabel = new Label();
            jobLabel = new Label();
            year_textBox = new TextBox();
            job_textBox = new TextBox();
            fatherName_textBox = new TextBox();
            lastName_textBox = new TextBox();
            firstName_textBox = new TextBox();
            createButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Location = new Point(12, 9);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new Size(111, 15);
            FirstNameLabel.TabIndex = 0;
            FirstNameLabel.Text = "Введите фамилию:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(12, 33);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(78, 15);
            lastNameLabel.TabIndex = 1;
            lastNameLabel.Text = "Введите имя:";
            // 
            // fatherNameLabel
            // 
            fatherNameLabel.AutoSize = true;
            fatherNameLabel.Location = new Point(12, 58);
            fatherNameLabel.Name = "fatherNameLabel";
            fatherNameLabel.Size = new Size(105, 15);
            fatherNameLabel.TabIndex = 2;
            fatherNameLabel.Text = "Введите отчество:";
            // 
            // yearOfBirthLabel
            // 
            yearOfBirthLabel.AutoSize = true;
            yearOfBirthLabel.Location = new Point(12, 83);
            yearOfBirthLabel.Name = "yearOfBirthLabel";
            yearOfBirthLabel.Size = new Size(132, 15);
            yearOfBirthLabel.TabIndex = 3;
            yearOfBirthLabel.Text = "Введите год рождения:";
            // 
            // jobLabel
            // 
            jobLabel.AutoSize = true;
            jobLabel.Location = new Point(12, 106);
            jobLabel.Name = "jobLabel";
            jobLabel.Size = new Size(121, 15);
            jobLabel.TabIndex = 4;
            jobLabel.Text = "Введите профессию:";
            // 
            // year_textBox
            // 
            year_textBox.Location = new Point(150, 80);
            year_textBox.Name = "year_textBox";
            year_textBox.Size = new Size(192, 23);
            year_textBox.TabIndex = 5;
            year_textBox.Click += year_textBox_Click;
            // 
            // job_textBox
            // 
            job_textBox.Location = new Point(150, 106);
            job_textBox.Name = "job_textBox";
            job_textBox.Size = new Size(192, 23);
            job_textBox.TabIndex = 6;
            job_textBox.Click += job_textBox_Click;
            // 
            // fatherName_textBox
            // 
            fatherName_textBox.Location = new Point(150, 55);
            fatherName_textBox.Name = "fatherName_textBox";
            fatherName_textBox.Size = new Size(192, 23);
            fatherName_textBox.TabIndex = 7;
            fatherName_textBox.Click += fatherName_textBox_Click;
            // 
            // lastName_textBox
            // 
            lastName_textBox.Location = new Point(150, 30);
            lastName_textBox.Name = "lastName_textBox";
            lastName_textBox.Size = new Size(192, 23);
            lastName_textBox.TabIndex = 8;
            lastName_textBox.Click += lastName_textBox_Click;
            // 
            // firstName_textBox
            // 
            firstName_textBox.Location = new Point(150, 5);
            firstName_textBox.Name = "firstName_textBox";
            firstName_textBox.Size = new Size(192, 23);
            firstName_textBox.TabIndex = 9;
            firstName_textBox.Click += firstName_textBox_Click;
            // 
            // createButton
            // 
            createButton.Location = new Point(64, 135);
            createButton.Name = "createButton";
            createButton.Size = new Size(80, 30);
            createButton.TabIndex = 10;
            createButton.Text = "Создать";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(200, 135);
            backButton.Name = "backButton";
            backButton.Size = new Size(80, 30);
            backButton.TabIndex = 11;
            backButton.Text = "Вернуться";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // InputClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 169);
            Controls.Add(backButton);
            Controls.Add(createButton);
            Controls.Add(firstName_textBox);
            Controls.Add(lastName_textBox);
            Controls.Add(fatherName_textBox);
            Controls.Add(job_textBox);
            Controls.Add(year_textBox);
            Controls.Add(jobLabel);
            Controls.Add(yearOfBirthLabel);
            Controls.Add(fatherNameLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(FirstNameLabel);
            MaximumSize = new Size(365, 208);
            MinimumSize = new Size(365, 193);
            Name = "InputClientForm";
            Text = "Создание нового пользователя";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FirstNameLabel;
        private Label lastNameLabel;
        private Label fatherNameLabel;
        private Label yearOfBirthLabel;
        private Label jobLabel;
        private TextBox year_textBox;
        private TextBox job_textBox;
        private TextBox fatherName_textBox;
        private TextBox lastName_textBox;
        private TextBox firstName_textBox;
        private Button createButton;
        private Button backButton;
    }
}