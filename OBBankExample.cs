using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication31
{
    interface IAccount
    {
        bool WithdrawFunds(double Amount);
        void PayInFunds(double Amount);
        double Balance { get; }
        double AvailableFunds { get; }
    }

    abstract class TAccount : IAccount
    {
        private static int _NextID = 10000001;
        private int _AccountID;
        private double _Balance;
        private string _Name;

        public TAccount(string inName, double inBalance = 0)
        {
            _Balance = inBalance;
            _Name = inName;
            _AccountID = _NextID;
            _NextID++;
        }
        public bool WithdrawFunds(double Amount)
        {
            if (AvailableFunds < Amount)
            {
                return false;
            }
            else
            {
                _Balance -= Amount;
                return true;
            }
        }
        public void PayInFunds(double Amount)
        {
            _Balance += Amount;
        }
        public int AccountID
        {
            get { return _AccountID; }
        }
        public string Name
        {
            get { return _Name; }
        }
        public double Balance
        {
            get { return _Balance; }
        }
        public virtual double AvailableFunds //virtal gives permission for re-implementation in a derived class
        {
            get { return _Balance; }
        }
    }

    class TBasicAccount : TAccount
    {
        private static double _InterestRate = 0.01;
        public static double InterestRate
        {
            get { return _InterestRate; }
            set
            {
                if (value > 0 && value < 1)
                    _InterestRate = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public TBasicAccount(string inName, double inBalance = 0)
            : base(inName, inBalance)
        { }
    }

    class TOverdraftAccount : TAccount
    {
        private const int MIN_INCOME = 10000;
        private const int MIN_AGE = 18;
        private const int MIN_OVERDRAFT = 100;
        private const int MAX_OVERDRAFT = 5000;
        private static double _InterestRate = 0.01;
        private int _Overdraft;
        public TOverdraftAccount(string inName, double inBalance = 0, int inOverdraft = 100)
            : base(inName, inBalance)
        {
            Overdraft = inOverdraft;
        }
        public static double InterestRate
        {
            get { return _InterestRate; }
            set
            {
                if (value > 0 && value < 1)
                    _InterestRate = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public int Overdraft
        {
            get { return _Overdraft; }
            set
            {
                if (value >= MIN_OVERDRAFT && value <= MAX_OVERDRAFT)
                    _Overdraft = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public static bool AccountAllowed(decimal Income, int Age)
        {
            if ((Income >= MIN_INCOME) && (Age >= MIN_AGE))
                return true;
            else
                return false;
        }
        public override double AvailableFunds
        {
            get { return Balance + Overdraft; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TAccount TestAccount = null;

            int Choice;

            Console.WriteLine("BANK ACCOUNT TEST PROGRAM");
            do
            {
                Console.WriteLine("\n1. Create new account");
                Console.WriteLine("2. Pay in funds");
                Console.WriteLine("3. Withdraw funds");
                Console.WriteLine("4. Display account details");
                Console.WriteLine("5. Change overdraft");
                Console.WriteLine("6. Change interest rate");
                Console.WriteLine("0. Exit\n");
                Console.Write("Choice: ");
                Choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (Choice)
                {
                    case 1:
                        OpenAccount(out TestAccount);
                        break;
                    case 2:
                        Console.Write("Amount: ");
                        TestAccount.PayInFunds(double.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        Console.Write("Amount: ");
                        if (TestAccount.WithdrawFunds(double.Parse(Console.ReadLine())))
                            Console.WriteLine("Cash withdrawn.");
                        else
                            Console.WriteLine("Insufficient funds.");
                        break;
                    case 4:
                        if (TestAccount != null)
                        {
                            Console.WriteLine("Type: {0}", TestAccount.GetType().ToString());
                            Console.WriteLine("A/C Number: {0}", TestAccount.AccountID);
                            Console.WriteLine("Name: {0}", TestAccount.Name);
                            Console.WriteLine("Balance: £{0:0.00}", TestAccount.Balance);
                            Console.WriteLine("Available Funds: £{0:0.00}", TestAccount.AvailableFunds);
                            if (TestAccount is TOverdraftAccount)
                                Console.WriteLine("Overdraft limit: {0}", ((TOverdraftAccount)TestAccount).Overdraft);
                        }
                        else
                            Console.WriteLine("Test account is null.");
                        break;
                    case 5:
                        if (TestAccount is TOverdraftAccount)
                        {
                            Console.WriteLine("Current overdraft: {0}", ((TOverdraftAccount)TestAccount).Overdraft);
                            Console.Write("New overdraft: ");
                            try
                            {
                                ((TOverdraftAccount)TestAccount).Overdraft = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Invalid overdraft limit entered - not changed.");
                            }
                        }
                        else
                            Console.WriteLine("Cannot set overdraft for this type of account.");
                        break;
                    case 6:
                        Console.WriteLine("Current interest rate for Basic Account: {0}", TBasicAccount.InterestRate);
                        Console.Write("New interest rate: ");
                        try
                        {
                            TBasicAccount.InterestRate = double.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Invalid interest rate entered - not changed.");
                        }
                        Console.WriteLine("Current interest rate for Overdraft Account: {0}", TOverdraftAccount.InterestRate);
                        Console.Write("New interest rate: ");
                        try
                        {
                            TOverdraftAccount.InterestRate = double.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Invalid interest rate entered - not changed.");
                        }
                        break;
                }

            } while (Choice != 0);
        }

        static void OpenAccount(out TAccount Account)
        {
            Console.Write("Account type (S - Standard, O - Overdraft): ");
            string Type = Console.ReadLine().ToUpper();
            if (Type == "S" || Type == "O")
            {
                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Console.Write("Opening balance: ");
                double OpeningBalance = double.Parse(Console.ReadLine());
                if (Type == "S")
                    Account = new TBasicAccount(Name, OpeningBalance);
                else
                {
                    Console.Write("Salary: ");
                    int Salary = int.Parse(Console.ReadLine());
                    Console.Write("Age: ");
                    int Age = int.Parse(Console.ReadLine());
                    if (TOverdraftAccount.AccountAllowed(Salary, Age))
                        Console.WriteLine("Account opened.");
                    else
                        Console.WriteLine("Not Eligible. Account cannot be opened.");
                    Account = new TOverdraftAccount(Name, OpeningBalance);
                }
            }
            else
            {
                Console.WriteLine("Invalid account type selected.");
                Account = null;
            }
        }

    }

}