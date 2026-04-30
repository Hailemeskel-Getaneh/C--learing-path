# Banking System

A simple bank account simulator built to practice OOP from Unit 02.

## What it covers

**Encapsulation** — The `_balance` field is private. The only way to change it is through `Deposit()` and `Withdraw()`, which both validate the input first.

**Inheritance** — `SavingsAccount` and `CheckingAccount` both extend `BankAccount`. They share the common logic (deposits, withdrawals) but each adds its own behavior.

**Polymorphism** — `Withdraw()` is declared `virtual` in the base class. `CheckingAccount` overrides it to add a flat fee. Same method call, different behavior depending on the object type.

**Abstraction** — `BankAccount` is abstract. You can't instantiate it directly — you have to use one of the concrete subtypes. `IAccount` defines what any account must be able to do.

## How to run

```powershell
cd 02-OOP/Projects/BankingSystem
dotnet run
```

## Notes

The `is` pattern check (`if (accounts[0] is SavingsAccount savings)`) is a clean way to cast and check type at the same time — no separate null check needed.
