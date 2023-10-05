using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab4_windowsApp
{
    public partial class startForm : Form
    {
        public static List<Bank_Account> accounts = new List<Bank_Account>();
        public static List<Client> clients = new List<Client>();
        public startForm()
        {
            InitializeComponent();
        }
        private void newClientCreation_Click(object sender, EventArgs e)
        {
            InputClientForm f = new InputClientForm();
            f.ShowDialog();
        }
        private void oldClientFinding_Click(object sender, EventArgs e)
        {
            InputClientForm f = new InputClientForm();
            f.convertToFindForm();
            f.ShowDialog();
        }
    }
}
