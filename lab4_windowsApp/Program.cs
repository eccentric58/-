using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab4_windowsApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new startForm());
        }
        
    }
    public class Client
    {
        private string first_name, last_name, father_name, job;
        private int year_of_birth;
        private int[] bank_accounts;
        public Client(string firstName, string lastName, string fatherName, int yearOfBirth, string job_)
        {
            first_name = firstName;
            last_name = lastName;
            father_name = fatherName;
            year_of_birth = yearOfBirth;
            job = job_;
            bank_accounts = new int[0];
        }
        public override string ToString()
        {
            return first_name + ' ' + last_name + ' ' + father_name + ' ' + year_of_birth.ToString();
        }
        public void addAccount(int num)
        {
            Array.Resize(ref bank_accounts, bank_accounts.Length + 1);
            bank_accounts[bank_accounts.Length - 1] = num;
        }
        public int[] GetAccounts() { return bank_accounts; }
    }
    public class Transaction
    {
        private double sum;
        private string date;
        private bool direction;
        public Transaction(double s, string d, bool dir)
        {
            sum = s;
            date = d;
            direction = dir;    // 1 - in   0 - out
        }
        public override string ToString()
        {
            return direction ? date + "     IN:     " + sum.ToString() : date + "    OUT:     " + sum.ToString();
        }
    }
    public class Bank_Account
    {
        private static int NumbersForAccounts = 0;
        private int number_of_account;
        private double balance;
        private bool state;
        private Transaction[] history_in, history_out, history;
        public Bank_Account()
        {
            number_of_account = NumbersForAccounts;
            NumbersForAccounts += 1;
            balance = 0.0;
            state = true;
            history_in = new Transaction[0];
            history_out = new Transaction[0];
            history = new Transaction[0];
        }
        public bool GetState() { return state; }
        public void OpenAccount()
        {
            state = true;
        }
        public void CloseAccount()
        {
            state = false;
        }
        public int GetNumber() { return number_of_account; }
        public void in_money(double sum)
        {
            Transaction t = new Transaction(sum, "18.03.2022", true);
            Array.Resize(ref history_in, history_in.Length + 1);
            history_in[history_in.Length - 1] = t;
            Array.Resize(ref history, history.Length + 1);
            history[history.Length - 1] = t;
            balance += sum;
        }
        public void out_money(double sum)
        {
            Transaction t = new Transaction(sum, "18.03.2022", false);
            Array.Resize(ref history_out, history_out.Length + 1);
            history_out[history_out.Length - 1] = t;
            Array.Resize(ref history, history.Length + 1);
            history[history.Length - 1] = t;
            balance -= sum;
        }
        public double getBalance() { return balance; }
        public List<string> getHistory()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < history.Length; i++)
                result.Add(history[i].ToString());
            return result;
        }
    }
}
