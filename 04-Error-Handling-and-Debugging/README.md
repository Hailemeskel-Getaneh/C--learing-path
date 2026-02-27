# Unit 04 — Error Handling and Debugging

Code breaks. The question is whether it breaks gracefully or takes everything down with it. This section is about writing code that handles failure properly and knowing how to find bugs when they happen.

## What's in here

- 01-Exceptions.md — try, catch, finally, and throw
- 02-Exception-Practices.md — what to catch, what to let bubble up
- 03-Debugging.md — using the VS Code debugger

Practice project in `Projects/RobustProcessor/`.

## The basics of exception handling

```csharp
try {
    // code that might fail
} catch (Exception ex) {
    // handle the failure
} finally {
    // always runs, even if an exception occurred
}
```

The `finally` block is useful for cleanup — closing a file, releasing a database connection, etc.

## What to catch, what to ignore

A common mistake is catching everything. That looks like this:

```csharp
catch (Exception ex) { } // silently swallowing errors
```

This hides real bugs and makes debugging painful. Catch only what you can actually handle and recover from. Let everything else propagate so it fails loudly and clearly.

## The debugger

The VS Code debugger is underrated. Set a breakpoint (click the red dot on a line), run in debug mode with F5, and you can step through your code line by line, inspect variable values, and watch what's actually happening at runtime.

---

*Reference: [Exception handling in C#](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/)*
