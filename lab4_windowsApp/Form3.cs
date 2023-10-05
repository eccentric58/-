using System;
using System.Windows.Forms;

namespace lab4_windowsApp
{
    public partial class accountForm : Form
    {
        public static Bank_Account curAcc = null;
        public accountForm()
        {
            InitializeComponent();
            int[] accounts = InputClientForm.curClient.GetAccounts();
            comboBox1.Text = "Выберете счет";
            for (int i = 0; i < accounts.Length; i++)
                comboBox1.Items.Add(accounts[i]);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
        }
        private void newAccount_Click(object sender, EventArgs e)
        {
            Bank_Account ba = new Bank_Account();
            startForm.accounts.Add(ba);
            InputClientForm.curClient.addAccount(ba.GetNumber());
            comboBox1.Items.Add(InputClientForm.curClient.GetAccounts()[InputClientForm.curClient.GetAccounts().Length - 1]);
            curAcc = ba;
            Form4 f = new Form4();
            f.ShowDialog();
        }
    }
}
