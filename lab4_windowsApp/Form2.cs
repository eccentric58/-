using System;
using System.Windows.Forms;

namespace lab4_windowsApp
{
    public partial class InputClientForm : Form
    {
        public static string empty_error_str = "### EMPTY ###";
        public static string incorrect_num_error_str = "### NOT NUM ###";
        static string clientDidntExists = "### CLIENT DIDN'T EXIST ###";
        static string clientHasFounded = "### CLIENT HAS FOUNDED ###";
        static string clientHasCreated = "### CLIENT HAS CREATED ###";

        public static Client curClient = null;
        public InputClientForm()
        {
            InitializeComponent();
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            string firstName = this.firstName_textBox.Text;
            string lastName = this.lastName_textBox.Text;
            string fatherName = this.fatherName_textBox.Text;
            string yearSTR = this.year_textBox.Text;
            int year = 0;
            string job = this.job_textBox.Text;
            bool correctSignal = true;
            if (firstName == "")
            {
                this.firstName_textBox.Text = empty_error_str;
                correctSignal = false;
            }
            if (lastName == "")
            {
                this.lastName_textBox.Text = empty_error_str;
                correctSignal = false;
            }
            if (fatherName == "")
            {
                this.fatherName_textBox.Text = empty_error_str;
                correctSignal = false;
            }
            if (yearSTR == "")
            {
                this.year_textBox.Text = empty_error_str;
                correctSignal = false;
            }
            else
            {
                if (!(int.TryParse(yearSTR, out year)))
                {
                    this.year_textBox.Text = incorrect_num_error_str;
                    correctSignal = false;
                }
            }

            if (this.state == true) // create
            {
                if (job == "")
                {
                    this.job_textBox.Text = empty_error_str;
                    correctSignal = false;
                }
                if (correctSignal)
                {
                    Client cl = new Client(firstName, lastName, fatherName, year, job);
                    startForm.clients.Add(cl);
                    curClient = cl;
                    this.firstName_textBox.Text = clientHasCreated;
                    accountForm f = new accountForm();
                    f.ShowDialog();
                }
            }
            else    // find
            {
                if (correctSignal)
                {
                    int i;
                    for (i = 0; i < startForm.clients.Count; i++)
                    {
                        if (startForm.clients[i].ToString() == (firstName + ' ' + lastName + ' ' + fatherName + ' ' + year.ToString()))
                            break;
                    }
                    if (i == startForm.clients.Count)
                        this.firstName_textBox.Text = clientDidntExists;
                    else
                    {
                        this.firstName_textBox.Text = clientHasFounded;
                        curClient = startForm.clients[i];
                        accountForm f = new accountForm();
                        f.ShowDialog();
                    }
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void firstName_textBox_Click(object sender, EventArgs e)
        {
            if (this.firstName_textBox.Text == empty_error_str)
                this.firstName_textBox.Clear();
        }

        private void lastName_textBox_Click(object sender, EventArgs e)
        {
            if (this.lastName_textBox.Text == empty_error_str)
                this.lastName_textBox.Clear();
        }

        private void fatherName_textBox_Click(object sender, EventArgs e)
        {
            if (this.fatherName_textBox.Text == empty_error_str)
                this.fatherName_textBox.Clear();
        }

        private void year_textBox_Click(object sender, EventArgs e)
        {
            if (this.year_textBox.Text == empty_error_str || this.year_textBox.Text == incorrect_num_error_str)
                this.year_textBox.Clear();
        }

        private void job_textBox_Click(object sender, EventArgs e)
        {
            if (this.job_textBox.Text == empty_error_str)
                this.job_textBox.Clear();
        }
    }
}
