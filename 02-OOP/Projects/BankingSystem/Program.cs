using System;

// base Class : encapsulates shared data and logic 
abstract class BankAccount 
{
    public string AccountNumber { get; protected set; }
    public string Owner { get; protected set; }
    public decimal Balance { get; protected set; }

    public BankAccount(string number, string owner, decimal balance) 
    {
        AccountNumber = number;
        Owner = owner;
        Balance = balance;
    }

    // Virtual: Can be overridden by child classes
    public virtual void Deposit(decimal amount) 
    {
        Balance += amount;
        Console.WriteLine($"{Owner} deposited {amount:C}. New Balance: {Balance:C}");
    }

    // Virtual method Logic for a standard withdrawal
    public virtual void Withdraw(decimal amount) 
    {
        if (amount <= Balance) {
            Balance -= amount;
            Console.WriteLine($"{Owner} withdrew {amount:C}. Remaining: {Balance:C}");
        } else {
            Console.WriteLine("Insufficient funds!");
        }
    }

    // abstract method means every child implement their own version
    public abstract void PrintSummary();
}


class SavingsAccount : BankAccount 
{
    public decimal InterestRate = 0.05m;

    public SavingsAccount(string num, string name, decimal bal) : base(num, name, bal) { }

    public void AddInterest() 
    {
        decimal interest = Balance * InterestRate;
        Deposit(interest);
    }

    public override void PrintSummary() => 
        Console.WriteLine($"[Savings] {Owner} | {AccountNumber} | Balance: {Balance:C}");
}

// child class 
class CheckingAccount : BankAccount 
{
    private decimal fee = 2.00m;

    public CheckingAccount(string num, string name, decimal bal) : base(num, name, bal) { }

    // overridig Withdraw to include a fee
    public override void Withdraw(decimal amount) 
    {
        Console.WriteLine($"Applying {fee:C} fee...");
        base.Withdraw(amount + fee); 
    }

    public override void PrintSummary() => 
        Console.WriteLine($"[Checking] {Owner} | {AccountNumber} | Balance: {Balance:C}");
}

// main program
class Program 
{
    static void Main() 
    {

        BankAccount[] accounts = new BankAccount[2];
        accounts[0] = new SavingsAccount("S101", "Hailemeskel ", 1000);
        accounts[1] = new CheckingAccount("C202", "Esayas", 500);


        Console.WriteLine("--- Account Status ---");
        foreach (BankAccount acc in accounts) 
        {
            acc.PrintSummary();

        }

        Console.WriteLine("\n--- Processing Transactions ---");
        accounts[0].Deposit(200); // Standard deposit
        accounts[1].Withdraw(100); // Checking withdrawal (with fee)

        // Downcasting: Accessing child-specific methods
        if (accounts[0] is SavingsAccount sa) {
            sa.AddInterest();
        }

        Console.WriteLine("\n--- Final Status ---");
        foreach (BankAccount acc in accounts) acc.PrintSummary();
    }
}
