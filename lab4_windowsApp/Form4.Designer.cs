
namespace lab4_windowsApp
{
    partial class Form4
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
            openAcc = new Button();
            closeAcc = new Button();
            inputMoney = new Button();
            OutMoney = new Button();
            balanceView = new Button();
            historyView = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // openAcc
            // 
            openAcc.Location = new Point(12, 12);
            openAcc.Name = "openAcc";
            openAcc.Size = new Size(129, 32);
            openAcc.TabIndex = 0;
            openAcc.Text = "Открыть счет";
            openAcc.UseVisualStyleBackColor = true;
            openAcc.Click += openAcc_Click;
            // 
            // closeAcc
            // 
            closeAcc.Location = new Point(12, 55);
            closeAcc.Name = "closeAcc";
            closeAcc.Size = new Size(129, 32);
            closeAcc.TabIndex = 1;
            closeAcc.Text = "Закрыть счет";
            closeAcc.UseVisualStyleBackColor = true;
            closeAcc.Click += button1_Click;
            // 
            // inputMoney
            // 
            inputMoney.Location = new Point(12, 99);
            inputMoney.Name = "inputMoney";
            inputMoney.Size = new Size(129, 32);
            inputMoney.TabIndex = 2;
            inputMoney.Text = "Вклад денег";
            inputMoney.UseVisualStyleBackColor = true;
            inputMoney.Click += inputMoney_Click;
            // 
            // OutMoney
            // 
            OutMoney.Location = new Point(12, 143);
            OutMoney.Name = "OutMoney";
            OutMoney.Size = new Size(129, 32);
            OutMoney.TabIndex = 3;
            OutMoney.Text = "Снятие денег";
            OutMoney.UseVisualStyleBackColor = true;
            OutMoney.Click += OutMoney_Click;
            // 
            // balanceView
            // 
            balanceView.Location = new Point(12, 187);
            balanceView.Name = "balanceView";
            balanceView.Size = new Size(129, 32);
            balanceView.TabIndex = 4;
            balanceView.Text = "Просмотр баланса";
            balanceView.UseVisualStyleBackColor = true;
            balanceView.Click += balanceView_Click;
            // 
            // historyView
            // 
            historyView.Location = new Point(12, 233);
            historyView.Name = "historyView";
            historyView.Size = new Size(129, 32);
            historyView.TabIndex = 5;
            historyView.Text = "Просмотр истории";
            historyView.UseVisualStyleBackColor = true;
            historyView.Click += historyView_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(147, 149);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(192, 23);
            textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(147, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(192, 23);
            textBox1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(147, 196);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 9;
            label1.Text = "label1";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(147, 239);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(192, 23);
            comboBox1.TabIndex = 10;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 315);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(historyView);
            Controls.Add(balanceView);
            Controls.Add(OutMoney);
            Controls.Add(inputMoney);
            Controls.Add(closeAcc);
            Controls.Add(openAcc);
            Name = "Form4";
            Text = "Счет";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openAcc;
        private Button closeAcc;
        private Button inputMoney;
        private Button OutMoney;
        private Button balanceView;
        private Button historyView;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label1;
        private ComboBox comboBox1;
    }
}