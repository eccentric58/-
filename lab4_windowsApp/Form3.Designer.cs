
namespace lab4_windowsApp
{
    partial class accountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public static Client curClient = null;

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
            newAccount = new Button();
            oldAccount = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // newAccount
            // 
            newAccount.Location = new Point(12, 12);
            newAccount.Name = "newAccount";
            newAccount.Size = new Size(176, 32);
            newAccount.TabIndex = 0;
            newAccount.Text = "Создать новый счет";
            newAccount.UseVisualStyleBackColor = true;
            newAccount.Click += newAccount_Click;
            // 
            // oldAccount
            // 
            oldAccount.Location = new Point(12, 55);
            oldAccount.Name = "oldAccount";
            oldAccount.Size = new Size(176, 32);
            oldAccount.TabIndex = 1;
            oldAccount.Text = "Работать со старым счетом";
            oldAccount.UseVisualStyleBackColor = true;
            oldAccount.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(209, 61);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(156, 23);
            comboBox1.TabIndex = 2;
            // 
            // accountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 100);
            Controls.Add(comboBox1);
            Controls.Add(oldAccount);
            Controls.Add(newAccount);
            Name = "accountForm";
            Text = "Работа со счетами";
            ResumeLayout(false);
        }

        #endregion

        private Button newAccount;
        private Button oldAccount;
        private ComboBox comboBox1;
    }
}