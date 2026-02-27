# Unit 05 — Async and Advanced Concepts

This section covers the patterns that separate junior C# from senior C#. Once I understand async, generics, and delegates — I can read and write real-world .NET code without getting lost.

## What's in here

- 01-Async.md — async/await and how Tasks work
- 02-Generics.md — writing reusable, type-safe code
- 03-Delegates.md — delegates, events, and lambda expressions

## Async/Await

The biggest shift in thinking here is understanding that `await` doesn't block the thread. It suspends the current method and gives control back to the caller while something (a network call, a file read) is happening in the background.

```csharp
public async Task<string> GetDataAsync() {
    string result = await httpClient.GetStringAsync("https://api.example.com/data");
    return result;
}
```

Without async, that `GetStringAsync` call would freeze the app while waiting.

## Generics

Instead of writing a method that works only for `int` or only for `string`, generics let you write it once for any type:

```csharp
T GetFirst<T>(List<T> items) => items[0];
```

This is how `List<T>`, `Dictionary<TKey, TValue>`, and most of .NET's collections are built.

---

*Reference: [Async programming in C#](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/)*
