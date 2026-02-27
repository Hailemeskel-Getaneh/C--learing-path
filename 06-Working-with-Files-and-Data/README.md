# Unit 06 — Working with Files and Data

This is where programs start having "memory." Instead of losing all data when the app closes, we learn how to write it to disk, read it back, and work with formats like JSON that are used everywhere.

## What's in here

- 01-FileSystem.md — reading and writing text files
- 02-JSON.md — serializing and deserializing objects
- 03-Streams.md — handling larger files efficiently

Practice project in `Projects/HabitTracker/`.

## Reading and writing files

```csharp
// Write
File.WriteAllText("data.txt", "Hello from C#");

// Read
string content = File.ReadAllText("data.txt");
```

For larger files, use `StreamReader` / `StreamWriter` so you don't load the whole file into memory at once.

## JSON

JSON is the standard format for data exchange. In .NET, `System.Text.Json` handles serialization and deserialization:

```csharp
// Object to JSON string
string json = JsonSerializer.Serialize(myObject);

// JSON string back to object
var obj = JsonSerializer.Deserialize<MyClass>(json);
```

The Habit Tracker project saves habits to a local `.json` file and loads them back on startup — a common real-world pattern.

---

*Reference: [File I/O in .NET](https://learn.microsoft.com/en-us/dotnet/standard/io/)*
