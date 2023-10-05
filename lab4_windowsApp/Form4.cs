using System;
using System.Windows.Forms;

namespace lab4_windowsApp
{
    public partial class Form4 : Form
    {
        public static string closedAccError = "### BANK ACCOUNT IS CLOSED ###";
        public Form4()
        {
            InitializeComponent();
            label1.Text = "Balance: ";
            comboBox1.Text = "History: ";
        }
        private void openAcc_Click(object sender, EventArgs e)
        {
            accountForm.curAcc.OpenAccount();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            accountForm.curAcc.CloseAccount();
        }
        private void historyView_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < accountForm.curAcc.getHistory().Count; i++)
            {
                comboBox1.Items.Add(accountForm.curAcc.getHistory()[i]);
            }
        }
        private void inputMoney_Click(object sender, EventArgs e)
        {
            double sum;
            if (textBox1.Text == "")
            {
                this.textBox1.Text = InputClientForm.empty_error_str;
            }
            else
            {
                if (!(double.TryParse(textBox1.Text, out sum)))
                {
                    this.textBox1.Text = InputClientForm.incorrect_num_error_str;
                }
                else
                {
                    if (accountForm.curAcc.GetState())
                    {
                        accountForm.curAcc.in_money(sum);
                        this.textBox1.Text = $"### TRANSACTION IN: {sum} ###";
                    }
                    else
                    {
                        this.textBox1.Text = closedAccError;
                    }
                }
            }
        }
        private void OutMoney_Click(object sender, EventArgs e)
        {
            double sum;
            if (textBox2.Text == "")
            {
                this.textBox2.Text = InputClientForm.empty_error_str;
            }
            else
            {
                if (!(double.TryParse(textBox2.Text, out sum)))
                {
                    this.textBox2.Text = InputClientForm.incorrect_num_error_str;
                }
                else
                {
                    if (accountForm.curAcc.GetState())
                    {
                        accountForm.curAcc.out_money(sum);
                        this.textBox2.Text = $"### TRANSACTION OUT: {sum} ###";
                    }
                    else
                    {
                        this.textBox2.Text = closedAccError;
                    }
                }
            }
        }
        private void balanceView_Click(object sender, EventArgs e)
        {
            label1.Text = "Balance: " + accountForm.curAcc.getBalance().ToString();
        }
    }
}
