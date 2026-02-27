# Unit 02 — Object-Oriented Programming

OOP is where C# development really starts to click. Instead of writing a long list of instructions, you start modeling real things — a bank account, a user, a vehicle — as objects with their own data and behavior.

## What's in here

Notes are in the `Notes/` folder:

- 01-Classes.md
- 02-Encapsulation.md
- 03-Inheritance.md
- 04-Abstraction.md

The practice project is in `Projects/BankingSystem/` — a simple bank account sim that demonstrates all four OOP pillars.

## The four pillars (short version)

**Encapsulation** — hide the internal details. Only expose what's necessary.

**Inheritance** — one class can extend another. A `SavingsAccount` can inherit from a general `BankAccount`.

**Polymorphism** — same method name, different behavior depending on the object type.

**Abstraction** — define a contract (interface or abstract class) and let the implementation be separate.

## Why it matters

Once OOP clicks, code becomes much easier to reason about. You stop asking "where does this code go?" because the answer is usually clear — it belongs to the class that owns that data.

---

*Reference: [OOP in C# — Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop)*
