using System;
using System.Collections.Generic;

// Banking System — Practice project for OOP concepts
// Covers: classes, inheritance, encapsulation, interfaces

// --- Interface: defines the contract all accounts must follow ---
interface IAccount
{
    string AccountNumber { get; }
    decimal Balance { get; }
    void Deposit(decimal amount);
    bool Withdraw(decimal amount);
    void PrintSummary();
}

// --- Base class: shared logic for all account types ---
abstract class BankAccount : IAccount
{
    public string AccountNumber { get; }
    public string Owner { get; }
    private decimal _balance;
    public decimal Balance => _balance;

    public BankAccount(string accountNumber, string owner, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        _balance = initialBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0) { Console.WriteLine("Deposit amount must be positive."); return; }
        _balance += amount;
        Console.WriteLine($"Deposited {amount:C}. New balance: {_balance:C}");
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (amount <= 0) { Console.WriteLine("Amount must be positive."); return false; }
        if (_balance < amount) { Console.WriteLine("Insufficient funds."); return false; }
        _balance -= amount;
        Console.WriteLine($"Withdrew {amount:C}. New balance: {_balance:C}");
        return true;
    }

    public abstract void PrintSummary();
}

// --- Savings Account: inherits from BankAccount, adds interest logic ---
class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; }

    public SavingsAccount(string number, string owner, decimal balance, decimal rate)
        : base(number, owner, balance)
    {
        InterestRate = rate;
    }

    public void ApplyMonthlyInterest()
    {
        decimal interest = Balance * InterestRate;
        Deposit(interest);
    }

    public override void PrintSummary()
    {
        Console.WriteLine($"[Savings] {AccountNumber} | {Owner} | Balance: {Balance:C} | Rate: {InterestRate:P}");
    }
}

// --- Checking Account: inherits from BankAccount, charges a fee per withdrawal ---
class CheckingAccount : BankAccount
{
    private const decimal WithdrawalFee = 2.00m;

    public CheckingAccount(string number, string owner, decimal balance)
        : base(number, owner, balance) { }

    // Overrides base Withdraw to add fee logic
    public override bool Withdraw(decimal amount)
    {
        Console.WriteLine($"Note: A {WithdrawalFee:C} withdrawal fee applies.");
        return base.Withdraw(amount + WithdrawalFee);
    }

    public override void PrintSummary()
    {
        Console.WriteLine($"[Checking] {AccountNumber} | {Owner} | Balance: {Balance:C}");
    }
}

// --- Main program ---
class Program
{
    static void Main()
    {
        var accounts = new List<BankAccount>
        {
            new SavingsAccount("SAV-001", "Haile", 2000m, 0.04m),
            new CheckingAccount("CHK-002", "Meskel", 800m)
        };

        Console.WriteLine("=== Current Accounts ===");
        foreach (var acc in accounts) acc.PrintSummary();

        Console.WriteLine("\n=== Transactions ===");
        accounts[0].Withdraw(300);
        accounts[1].Withdraw(300);   // checking account charges a fee

        Console.WriteLine("\n=== Applying Monthly Interest to Savings ===");
        if (accounts[0] is SavingsAccount savings)
            savings.ApplyMonthlyInterest();

        Console.WriteLine("\n=== Updated Accounts ===");
        foreach (var acc in accounts) acc.PrintSummary();
    }
}
