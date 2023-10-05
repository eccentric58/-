using System;
using System.Linq;

namespace lab3_classes
{
    class Client
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
            return first_name + ' ' + last_name + ' ' + father_name + ' ' + year_of_birth.ToString() + ' ' + job;
        }
        public void addAccount(int num)
        {
            Array.Resize(ref bank_accounts, bank_accounts.Length + 1);
            bank_accounts[bank_accounts.Length - 1] = num;
        }
        public int[] GetAccounts() { return bank_accounts; }
    }
    class Transaction
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
            return direction ?  date + "     IN:     " + sum.ToString() :  date + "    OUT:     " + sum.ToString();
        }
    }
    class Bank_Account
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
            Console.WriteLine($"### ACCOUNT {number_of_account} WAS OPENED ###");
        }
        public void CloseAccount()
        {
            state = false;
            Console.WriteLine($"### ACCOUNT {number_of_account} WAS CLOSED ###");
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
            Console.WriteLine($"### TRANSACTION IN: {sum} ###");
        }
        public void out_money(double sum)
        {
            Transaction t = new Transaction(sum, "18.03.2022", false);
            Array.Resize(ref history_out, history_out.Length + 1);
            history_out[history_out.Length - 1] = t;
            Array.Resize(ref history, history.Length + 1);
            history[history.Length - 1] = t;
            balance -= sum;
            Console.WriteLine($"### TRANSACTION OUT: {sum} ###");
        }
        public double getBalance() { return balance; }
        public string getHistory()
        {
            string result = "";
            for (int i = 0; i < history.Length; i++)
                result += history[i].ToString() + '\n';
            return result;
        }
    }
    class Program
    {
        static Bank_Account[] accounts = new Bank_Account[0];
        static Client[] clients = new Client[0];
        static void Main(string[] args)
        {
            string readLine = "start";
            while (readLine != "end")
            {
                Console.Write("Enter 1 to create new client OR 2 if client exists: ");
                string code = Console.ReadLine(); 
                while ((code != "1") && (code != "2"))
                { 
                    Console.Write("ERROR: Wrong code. Enter 1 to create new client OR 2 if client exists: "); 
                    code = Console.ReadLine(); 
                }
                Console.Write("Enter first name: ");
                string first_name = Console.ReadLine();
                Console.Write("Enter last name: ");
                string last_name = Console.ReadLine();
                Console.Write("Enter father name: ");
                string father_name = Console.ReadLine();
                Console.Write("Enter year of birth: ");
                int year = 0;
                while (!(int.TryParse(Console.ReadLine(), out year)))
                    Console.WriteLine("ERROR: Wrong number. Enter year of birth again:");
                Console.Write("Enter job: ");
                string job = Console.ReadLine();

                switch (code)
                {
                    case "1": {
                            Client cl = new Client(first_name, last_name, father_name, year, job);
                            Array.Resize(ref clients, clients.Length + 1);
                            clients[clients.Length - 1] = cl;
                            Console.WriteLine("### CLIENT HAS CREATED ###");
                            work_with_client(clients.Length - 1);
                            break; 
                        }
                    case "2":
                        {
                            int i;
                            for (i = 0; i < clients.Length; i++)
                            {
                                if (clients[i].ToString() == (first_name + ' ' + last_name + ' ' + father_name + ' ' + year.ToString() + job))
                                    break;
                            }
                            if (i == clients.Length)
                                Console.WriteLine("### CLIENT DIDN'T EXIST ###");
                            else
                            {
                                Console.WriteLine("### CLIENT HAS FOUNDED ###");
                                work_with_client(i);
                            }
                            break;
                        }
                }
                Console.WriteLine("\nEnter 'end' to finish OR something else to change client.");
                readLine = Console.ReadLine();
            }
        }
        static void work_with_client(int num)
        {
            string readLine = "start";
            while (readLine != "end")
            {
                int[] accountsArray = clients[num].GetAccounts();
                int numOfAccs = accountsArray.Length;
                string menuWithAccounts = $"Client has {numOfAccs} accounts. Enter:\n1 - to create new account";
                int max_i = 0, code = 0;
                for (max_i = 0; max_i < numOfAccs; max_i++)
                {
                    menuWithAccounts += $"\n{max_i + 2} - to work with account {accountsArray[max_i]}";
                }
                Console.WriteLine(menuWithAccounts);
                while (true) 
                {
                    while (!(int.TryParse(Console.ReadLine(), out code)))
                        Console.WriteLine("### ERROR: WRONG NUMBER ###");
                    if ((code < 0) || (code >= max_i + 2))
                        Console.WriteLine("### ERROR: WRONG CODE ###\n" + menuWithAccounts);
                    else
                        break; 
                }
                int accNum = 0;
                if (code == 1)
                {
                    Bank_Account ba = new Bank_Account();
                    Array.Resize(ref accounts, accounts.Length + 1);
                    accounts[accounts.Length - 1] = ba;
                    clients[num].addAccount(ba.GetNumber());
                    Console.WriteLine("### BANK ACCOUNT HAS CREATED ###");
                    accNum = ba.GetNumber();
                }
                else
                    accNum = accountsArray[code - 2];

                Console.WriteLine("Enter 'end' to change account OR something else to continue.");
                while (Console.ReadLine() != "end")
                {
                    string menuWithFunctions = "Enter: \n1 - to open bank account\n2 - to close bank account\n3 - to put in\n4 - to put out\n5 - to see balance\n6 - to see history";
                    Console.WriteLine(menuWithFunctions);
                    string str = Console.ReadLine();
                    switch(str)
                    {
                        case "1": accounts[accNum].OpenAccount(); break;
                        case "2": accounts[accNum].CloseAccount(); break;
                        case "3":
                            {
                                if (accounts[accNum].GetState())
                                {
                                    Console.WriteLine("Enter sum to input: ");
                                    double sum;
                                    while (true)
                                    {
                                        while (!(double.TryParse(Console.ReadLine(), out sum)))
                                            Console.WriteLine("### ERROR: WRONG NUMBER ###\nEnter sum to input again: ");
                                        if (sum < 0)
                                            Console.WriteLine("### ERROR: WRONG SUM ###\nEnter sum to input again: ");
                                        else
                                            break;
                                    }
                                    accounts[accNum].in_money(sum);
                                }
                                else
                                    Console.WriteLine("### BANK ACCOUNT IS CLOSED ###");
                                break;
                            }
                        case "4":
                            {
                                if (accounts[accNum].GetState())
                                {
                                    Console.WriteLine("Enter sum to output: ");
                                    double sum;
                                    while (true)
                                    {
                                        while (!(double.TryParse(Console.ReadLine(), out sum)))
                                            Console.WriteLine("### ERROR: WRONG NUMBER ###\nEnter sum to output again: ");
                                        if ((sum > 0) && (sum < accounts[accNum].getBalance()))
                                            break;
                                        if (sum < 0)
                                            Console.WriteLine("### ERROR: WRONG SUM ###\nEnter sum to output again: ");
                                        if (sum > accounts[accNum].getBalance())
                                            Console.WriteLine("### ERROR: NOT ENOUGH MONEY ON BALANCE ###\nEnter sum to output again: ");
                                    }
                                    accounts[accNum].out_money(sum);
                                }
                                else
                                    Console.WriteLine("### BANK ACCOUNT IS CLOSED ###");
                                break;
                            }
                        case "5": Console.WriteLine($"### BALANCE: {accounts[accNum].getBalance()} ###"); break;
                        case "6": Console.WriteLine($"### HISTORY: ###\n{accounts[accNum].getHistory()}"); break;
                    }
                    Console.WriteLine("Enter 'end' to change account OR something else to continue.");  
                }
                Console.WriteLine("\nEnter 'end' to change client OR something else to continue.");
                readLine = Console.ReadLine();
            }
        }
    }
}

