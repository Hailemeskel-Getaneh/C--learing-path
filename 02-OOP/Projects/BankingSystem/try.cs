// using System;

// abstract class BankAccount {

//     public string AccountNumber{get; protected set;}
//     public string Owner {get; protected set;}
//     public decimal Balance {get; protected set;}

//     public BankAccount(string account, string owner , decimal balance){
//         AccountNumber = account;
//         Owner = owner;
//         Balance = balance;
//     }

//     public virtual void deposit(decimal amout){
//         Balance += amount;
//         Console.WriteLine($"Owner {Owner} deposted {amount:c}. New Balance {Balance:c}");
//     }

//     public virtual void withdraw(decimal amount){

//         if(amount <= Balance){
//             Balance -= amount;
//             Console.WriteLine($"Owner {Owner} withdraw {amount:c}. Current Balance {Balance:c}");
//         }

//         else{
//             Console.WriteLine("Insufficient Balance");
//         }

//     }

//     public abstract void PrintSummary();

// }

// class SavingsAccount : BankAccount {

//      public decimal InterestRate = 0.02m;

//     public SavingsAccount(string owner, string account, decimal balance) : base(owner, account, balance){}

//     public void AddInterest(){
//         decimal interest = Balance*InterestRate;
//         deposit(interest);

//     }

//     public override void PrintSummary(){
//         Console.WriteLine($"[Savings] {Owner} | {AccountNumber} | Balance {Balance:c}");
//     }
// }

// class CheckingAccount: BankAccount {

//    public decimal fee = 2.0m;
//    public CheckingAccount(string owner, string account, decimal balance): base(owner, account, balance){}

//     public override void withdraw(decimal amount){

//         Console.WriteLine("Checking for balance ....");
//         base.withdraw(amount + fee);
//     }

//     public override void PrintSummary(){
//         Console.WriteLine($"[Checking] {Owner} | {AccountNumber} | Balance {Balance:c}");
//     }

// }

// class Program {

//     public void Main(){

//         BankAccount accounts = new BankAccount(3);
//         accounts[0] = 


//     }



// }