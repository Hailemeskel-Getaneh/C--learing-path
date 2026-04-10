# 🧠 Async / Await in C#

Last Updated: April 9, 2026 5:20 PM
Module: 1. C# Essentials
Note type: Snippet
Status: In progress

## 🔹 1. Why Async/Await Exists

In normal (synchronous) programming, code runs **line by line**, and each line must finish before the next starts.

```csharp
Console.WriteLine("Start");
SlowOperation(); // takes 5 seconds
Console.WriteLine("End");
```

👉 Problem:

- The program **stops (blocks)** at `SlowOperation()`
- Nothing else can happen during that time

---

### 🚨 Real Problems Caused by Blocking

- UI freezes (desktop/mobile apps)
- Slow web servers
- Poor performance when handling many users

---

## 🔹 2. The Idea Behind Async

Async programming solves this by:

👉 “Start the operation → don’t wait → continue → come back later”

Instead of blocking:

- The method **pauses**
- The thread is **freed**
- Execution **resumes later**

---

## 🔹 3. What is `async`?

`async` is a keyword used in method declarations.

```csharp
public async void MyMethod()
{
}
```

### 🔍 What `async` does:

- Allows the use of `await`
- Changes how the method is compiled
- Turns the method into a **state machine internally**

👉 Important:
`async` **does NOT make the method run in background automatically**

---

## 🔹 4. What is `await`?

`await` is used inside an `async` method.

```csharp
await SomeOperation();
```

### 🔍 What `await` does:

- Pauses the method execution
- Does NOT block the thread
- Returns control to caller
- Resumes when operation completes

---

## 🔹 5. First Example (Understanding Behavior)

```csharp
public async void Test()
{
    Console.WriteLine("A");

    await System.Threading.Tasks.Task.Delay(2000);

    Console.WriteLine("B");
}
```

### 🧠 Execution Flow:

1. Prints `"A"`
2. Reaches `await`
3. Method **pauses**
4. Thread becomes free
5. After 2 seconds → resumes
6. Prints `"B"`

---

## 🔹 6. Key Difference: Pause vs Block

| Concept | Meaning |
| --- | --- |
| Block | Thread is stuck (cannot do anything) |
| Pause | Method stops, but thread is free |

---

### ❌ Blocking Example

```csharp
Thread.Sleep(2000);
```

- Thread is locked
- Nothing else can run

---

### ✅ Async Pause

```csharp
await Task.Delay(2000);
```

- Method pauses
- Thread is free

---

## 🔹 7. Important Rule

👉 `await` can ONLY be used inside `async` methods

```csharp
public async void Example()
{
    await Something(); // ✅ valid
}
```

---

## 🔹 8. Async Does NOT Mean Parallel

This is very important:

👉 `async` ≠ running multiple things at same time

It means:

- Non-blocking
- Not necessarily parallel

---

## 🔹 9. Real-Life Analogy

### Synchronous:

- You go to restaurant
- Order food
- Stand there until it’s ready

---

### Asynchronous:

- Order food
- Sit down
- Wait for notification

👉 You didn’t block yourself

---

## 🔹 10. Method Execution Flow (Very Important)

When an async method runs:

1. Starts executing normally
2. Runs until first `await`
3. Pauses and returns control
4. Continues later from same point

---

### Example

```csharp
public async void Flow()
{
    Console.WriteLine("1");

    await Task.Delay(1000);

    Console.WriteLine("2");
}
```

👉 Output order:

```
1
(wait)
2
```

---

## 🔹 11. Async Method Without Await

```csharp
public async void NoAwait()
{
    Console.WriteLine("Hello");
}
```

👉 This runs synchronously

⚠️ Warning:

- Compiler gives warning
- No benefit of async

---

## 🔹 12. Where Async is Used

Common real-world usage:

- API calls
- File reading/writing
- Database operations
- Network communication

---

## 🔹 13. Misconception to Avoid

❌ “async makes code faster”

👉 Not exactly

✔ It makes code:

- More responsive
- More scalable

---

## 🔹 14. What Happens Internally (Simplified)

When you write:

```csharp
await Something();
```

👉 Compiler transforms it into:

- Split method into parts
- Save current state
- Register continuation
- Resume later

👉 This is called a **state machine**

---

## 🔹 15. Sequential Async Flow

```csharp
await A();
await B();
```

👉 Execution:

1. Run A
2. Wait
3. Run B
4. Wait

---

## 🔹 16. Key Mental Model

Think of async as:

👉 “Pause the method, not the program”

---


## 🔹 17. Another Important Behavior

```csharp
public async void Example()
{
    Console.WriteLine("Start");

    await Task.Delay(2000);

    Console.WriteLine("End");
}

Console.WriteLine("Outside");
```

👉 Output:

```
Start
Outside
End
```


💡 Why?

- Method pauses at `await`
- Control returns immediately
- Outer code continues

---


## 🔹 18. Async and Thread

Important clarification:

👉 `async/await` does NOT create threads

- It uses existing threads efficiently
- It frees threads instead of blocking them

---

## 🔹 19. When NOT to Use Async

- Simple calculations
- Very fast operations
- Pure CPU logic (unless heavy)

---

## 🔹 20. some points to remember

- `async` enables asynchronous behavior
- `await` pauses without blocking
- Execution is split into stages
- Thread is freed during wait
- Async improves responsiveness, not raw speed
- Does NOT automatically mean parallel execution

---

## 🔹 21. Async Method Return Types (Behavior-Focused)

Even without going deep into `Task`, you must understand how async methods behave when returning values.

### Common forms:

```csharp
public async void MethodA() { }     // mainly for events
public async Task MethodB() { }     // no return value
public async Task<int> MethodC() { } // returns value
```

---

### 🔍 Key Understanding:

- `async void`
👉 Fire-and-forget
👉 Cannot be awaited
👉 Hard to handle errors
- `async Task`
👉 Can be awaited
👉 Safe and recommended
- `async Task<T>`
👉 Returns a value after completion

---

### ⚠️ Important Rule

👉 Avoid `async void` except for **event handlers**

```csharp
// GOOD (event handler)
button.Click += async (s, e) =>
{
    await DoSomething();
};
```

---

## 🔹 22. Execution Order & Flow Control

Understanding execution order is critical.

---

### Example

```csharp
public async void Example()
{
    Console.WriteLine("1");

    await Task.Delay(2000);

    Console.WriteLine("2");
}

Console.WriteLine("3");
Example();
Console.WriteLine("4");
```

---

### 🧠 Output

```
3
1
4
(wait)
2
```

---

### 🔍 Why This Happens

- `Example()` starts
- Runs until `await`
- Pauses
- Control returns immediately
- Outer code continues
- Later resumes

---

## 🔹 23. Multiple `await` Points

```csharp
public async void Multi()
{
    Console.WriteLine("A");

    await Task.Delay(1000);

    Console.WriteLine("B");

    await Task.Delay(1000);

    Console.WriteLine("C");
}
```

---

### Flow:

1. A prints
2. Pause
3. Resume → B prints
4. Pause again
5. Resume → C prints

---

👉 Each `await` = **checkpoint**

---

## 🔹 24. Await Inside Expressions

You can use `await` in assignments:

```csharp
int result = await GetValueAsync();
```

---

Or directly:

```csharp
Console.WriteLine(await GetValueAsync());
```

---

👉 Meaning:

- Wait for value
- Then continue

---

## 🔹 25. Async Without Await (Revisited Deeply)

```csharp
public async void Test()
{
    Console.WriteLine("Hello");
}
```

---

### 🔍 What actually happens:

- Runs synchronously
- No pause
- No async benefit

---

👉 Compiler warning:

> “This async method lacks 'await'”
> 

---

## 🔹 26. Mixing Sync and Async (Danger Zone)

### ❌ Wrong

```csharp
var result = GetDataAsync().Result;
```

---

### ❌ Also wrong

```csharp
GetDataAsync().Wait();
```

---

### 🚨 Problems:

- Can cause **deadlocks**
- Blocks thread
- Defeats async purpose

---

### ✅ Correct

```csharp
var result = await GetDataAsync();
```

---

## 🔹 27. Exception Handling in Async

```csharp
try
{
    await DoWorkAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

---

### 🔍 Important Behavior:

- Errors are captured
- Thrown when `await` happens
- Must use `try/catch` around `await`

---

### ⚠️ Special Case: `async void`

- Exceptions cannot be caught normally
- Can crash application

---

## 🔹 28. Async in Conditional Logic

```csharp
if (await CheckConditionAsync())
{
    Console.WriteLine("True");
}
```

---

👉 Meaning:

- Wait for condition result
- Then evaluate

---

## 🔹 29. Async in Loops (Behavior Only)

```csharp
foreach (var item in items)
{
    await ProcessAsync(item);
}
```

---

### 🔍 Behavior:

- Each iteration waits before next
- Runs sequentially

---

👉 Important:

- Not parallel
- Can be slow

---

## 🔹 30. Method Chaining with Await

```csharp
await MethodA();
await MethodB();
await MethodC();
```

---

👉 Execution:

- A → wait → B → wait → C

---

## 🔹 31. Async Call Stack Behavior

Normal call stack:

- Method A → Method B → Method C

---

Async call stack:

- Broken into pieces
- Resumes later

👉 Debugging may feel different

---

## 🔹 32. Context Switching (Important Concept)

When `await` finishes:

👉 The method may resume:

- On same thread (UI apps)
- On different thread (backend apps)

---

💡 This is managed automatically

---

## 🔹 33. UI Behavior (Very Important)

In UI apps (WPF, WinForms):

- UI thread must stay free
- Async prevents freezing

---

### Without async:

- UI freezes

### With async:

- UI stays responsive

---

## 🔹 34. Async Does Not Mean Immediate Execution

```csharp
await Task.Delay(0);
```

👉 Still asynchronous behavior

---

💡 Even small delays can change execution flow

---

## 🔹 35. Fire-and-Forget Pattern

```csharp
DoWorkAsync(); // not awaited
```

---

### 🔍 Behavior:

- Starts execution
- Caller does not wait

---

⚠️ Risks:

- Errors may be lost
- No control over completion

---

## 🔹 36. Await vs Continue Execution

```csharp
await Operation();
NextStep();
```

👉 `NextStep()` runs AFTER completion

---

```csharp
Operation();
NextStep();
```

👉 Runs immediately (no waiting)

---

## 🔹 37. Key Patterns to Remember

### Pattern 1: Wait then continue

```csharp
await Work();
Next();
```

---

### Pattern 2: Conditional wait

```csharp
if (await Check())
{
    Run();
}
```

---

### Pattern 3: Sequential async

```csharp
await A();
await B();
```

---

## 🔹 38. Mental Model Upgrade

From Part 1:

👉 “Pause the method”

Now extend it:

👉 “Pause → Save state → Resume exactly where left”

---

## 🔹 39. Common Mistakes (Extended)

- ❌ Using `async void`
- ❌ Forgetting `await`
- ❌ Blocking async code
- ❌ Assuming parallel execution
- ❌ Ignoring execution order

---

## 🔹 40. Summary 
- Async methods return control early
- Execution resumes after `await`
- Order of execution is non-linear
- Errors happen at `await`
- Async in loops is sequential
- Mixing sync & async is dangerous

---

