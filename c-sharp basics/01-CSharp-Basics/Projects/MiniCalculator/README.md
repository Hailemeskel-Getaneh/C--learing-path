# Mini Calculator

A command-line calculator built to practice the basics from Unit 01.

## What it covers

- User input with `Console.ReadLine()`
- Parsing input safely with `double.TryParse`
- A `while` loop to keep the app running
- A `switch` statement for selecting the operation
- Separate methods for each math operation

## How to run

```powershell
cd 01-CSharp-Basics/Projects/MiniCalculator
dotnet run
```

## What I learned

`TryParse` is the safe way to convert user input to a number. Without it, the app would crash if someone types "abc" instead of a number. It returns a `bool` indicating whether the parse worked, and the out parameter gives you the result if it did.
