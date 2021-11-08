using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientationYearTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            double WithdrawAmount = 0;
            double DepositAmount = 0;
            double OpeningBalance = 0;
            double OverdraftAmount = 0;
            int Response = -1;
            string AccountName;
            string AccountType = "";
            //TAccount Test = new TAccount(100); // Test is an object.

            TAccount TestBasic = null;
            TAccount TestOverdraft = null;

            while (Response != 5)
            {
                Console.WriteLine("Bank of Mediocrity");
                Console.WriteLine("[0] New Account");
                Console.WriteLine("[1] Withdraw");
                Console.WriteLine("[2] Deposit");
                Console.WriteLine("[3] View Account Information");
                Console.WriteLine("[4] Balance");
                Console.WriteLine("[5] Exit");
                Response = int.Parse(Console.ReadLine());

                if (Response == 0)
                {
                    Console.WriteLine("What type of Account would you like?\n[O]verdraft\n[S]tandard");
                    AccountType = Console.ReadLine().ToUpper();
                    if (AccountType == "O")
                    {
                        Console.WriteLine("Enter Account Name: ");
                        AccountName = Console.ReadLine();
                        Console.WriteLine("Opening Balance: ");
                        OpeningBalance = double.Parse(Console.ReadLine());
                        Console.WriteLine("Overdraft Amount: ");
                        OverdraftAmount = double.Parse(Console.ReadLine());
                        TestOverdraft = new TOverdraftAccount(AccountName, OpeningBalance, OverdraftAmount);
                    }
                    else if (AccountType == "S")
                    {
                        Console.WriteLine("Enter Account Name: ");
                        AccountName = Console.ReadLine();
                        Console.WriteLine("Opening Balance: ");
                        OpeningBalance = double.Parse(Console.ReadLine());
                        TestBasic = new TBasicAccount(AccountName, OpeningBalance);

                    }
                }
                else if (Response == 1)
                {
                    Console.WriteLine("How much do you want to withdraw.");
                    WithdrawAmount = double.Parse(Console.ReadLine());
                    if (AccountType == "O")
                    {
                        TestOverdraft.Withdraw(WithdrawAmount);
                    }
                    else if (AccountType == "S")
                    {
                        TestBasic.Withdraw(WithdrawAmount);
                        Console.WriteLine("Balance: {0}", TestBasic.PBalance);
                    }

                }
                else if (Response == 2)
                {
                    Console.WriteLine("How much do you want to deposit.");
                    DepositAmount = double.Parse(Console.ReadLine());
                    TestBasic.Payment(DepositAmount);
                    Console.WriteLine("Balance: {0}", TestBasic.PBalance);

                }
                else if (Response == 3)
                {
                    Console.WriteLine("Account Number: {0}", TestBasic._GetAccountNumber);
                    Console.WriteLine(TestBasic._GetAccountName);
                }
                else if (Response == 4)
                {
                    if (AccountType == "O")
                    {
                        Console.WriteLine("Available balance: {0}",TestOverdraft.AvailibleBalance);
                    }
                    if(AccountType == "S")
                    {
                        Console.WriteLine("Balance: {0}", TestBasic.AvailibleBalance);
                    }
                }
            }
        }
    }

    class TBasicAccount : TAccount
    {
        public TBasicAccount(string inAccountName, double inBalance = 0)
        : base(inAccountName, inBalance) { }
    }

    class TOverdraftAccount : TAccount
    {
        private double _Overdraft;
        private double _AvailableBalance;
        public TOverdraftAccount(string inAccountName, double inBalance = 0, double inOverdraftAmount = 0) : base(inAccountName, inBalance)
        {
            _Overdraft = inOverdraftAmount;
            _AvailableBalance = AvailibleBalance;
        }

        public double Overdraft
        {
            get { return _Overdraft; }
            set
            {
                if (value < 1000) value = _Overdraft;
                else throw new Exception("Overdraft is over allowed amount.");
            }
        }
        public override double AvailibleBalance
        {
            get
            {
                return _AvailableBalance + Overdraft;
            }
        }
        public override void Withdraw(double WithdrawAmount)
        {
            _AvailableBalance = AvailibleBalance - WithdrawAmount; 
        }
    }
}

abstract class TAccount //T stands for type as this is a type class.
{
    private double _Balance;//_ signifies that it is an class attribute. 
    private int _AccountNumber;
    static private int _NextAccountNumber = 10000000;//only statics can be assigned here as it does not work in a constructor.
    private string _AccountName;
    //constructors assign values only.
    public TAccount(string inName, double inBalance = 0)//constructor, always use. now when you instanciate if no value is supplied then it is set to what you set in the constructor().
    {
        _Balance = inBalance;
        _AccountNumber = ++_NextAccountNumber;//++ as a prefix is preincrement. ++ as a suffix is post increment.
        _AccountName = inName;
    }

    public double GetBalance()
    {
        return _Balance;
    }

    public double PBalance//getter, setter. this is a property. if statements can be added to validate.
    {
        get { return _Balance; }// only gets the value.
                                //set { _Balance = value; } // set up validation in here.
    }

    public int _GetAccountNumber
    {
        get { return _AccountNumber; }
    }

    public string _GetAccountName
    {
        get { return _AccountName; }
    }

    public void Payment(double inPayAmount)
    {
        _Balance = _Balance + inPayAmount;
    }

    public virtual void Withdraw(double WithdrawAmount)
    {
        if (WithdrawAmount > _Balance) throw new Exception("Insufficient funds.");
        else _Balance = _Balance - WithdrawAmount;
    }

    public virtual double AvailibleBalance
    { 
        get { return _Balance; }
    }
}
