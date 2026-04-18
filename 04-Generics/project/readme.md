# 📦 Generic Inventory Manager (C#) — Notes & Explanation

## 📌 Project Overview

This project is a simple **console-based inventory system** built using **C# Generics**.
It demonstrates how to write reusable, type-safe code that can work with different data types (like `Book`, `Medicine`) without duplication.

---

## 🎯 Learning Objectives

By completing this project, you will understand:

* What **generics** are and why they are useful
* How to create and use **generic classes**
* How to apply **generic constraints**
* How to write **generic methods**
* How to structure a clean and maintainable project

---

## 🧱 Project Structure

```
GenericInventoryApp
│
├── Interfaces
│   └── IEntity.cs
│
├── Models
│   ├── Book.cs
│   └── Medicine.cs
│
├── Services
│   └── Repository.cs
│
├── Helpers
│   └── Utility.cs
│
└── Program.cs
```

---

## 📄 Key Components Explained

### 1️⃣ IEntity (Interface)

```csharp
public interface IEntity
{
    int Id { get; set; }
}
```

### 💡 Purpose

* Defines a **common structure** for all models
* Ensures every object has an `Id`
* Used as a **constraint** in generics

---

### 2️⃣ Models (Book, Medicine)

Example:

```csharp
public class Book : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Title}";
    }
}
```

### 💡 Key Concepts

#### ✔ Interface Implementation

* `Book` and `Medicine` implement `IEntity`
* This allows them to be used in the generic repository

#### ✔ Method Override

* `ToString()` is overridden to control how objects are displayed
* Without override → prints type name
* With override → prints meaningful data

---

### 3️⃣ Repository<T> (Generic Class)

```csharp
public class Repository<T> where T : IEntity
```

### 💡 What is this?

A **generic class** that can work with any type `T`.

---

### 🔒 Generic Constraint

```csharp
where T : IEntity
```

#### ✔ Meaning:

* Only types that implement `IEntity` are allowed

#### ✔ Why needed:

* Ensures that `T` has an `Id` property
* Allows safe access like:

```csharp
x.Id
```

---

### 📦 Internal Storage

```csharp
private List<T> items = new List<T>();
```

* Stores all objects of type `T`
* Example:

  * `Repository<Book>` → stores books
  * `Repository<Medicine>` → stores medicines

---

### 🔍 Methods

#### ✔ Add

```csharp
public void Add(T item)
```

Adds an item to the list.

---

#### ✔ GetAll

```csharp
public List<T> GetAll()
```

Returns all stored items.

---

#### ✔ GetById

```csharp
public T? GetById(int id)
{
    return items.FirstOrDefault(x => x.Id == id);
}
```

##### 🔎 How it works:

* Uses a **lambda expression**:

  ```csharp
  x => x.Id == id
  ```
* Uses **FirstOrDefault()**:

  * Returns first match
  * Returns `null` if not found

---

#### ✔ Delete

Removes an item by ID if it exists.

---

### 4️⃣ Utility (Static Class)

```csharp
public static class Utility
```

### 💡 Why static?

* No object creation needed
* Used for helper methods only
* Called directly:

```csharp
Utility.PrintAll(...)
```

---

### 🔁 Generic Method

```csharp
public static void PrintAll<T>(List<T> items)
```

#### ✔ Works with ANY type

* `List<Book>`
* `List<Medicine>`
* Any other type

---

### 5️⃣ Program.cs (Entry Point)

```csharp
var bookRepo = new Repository<Book>();
var medicineRepo = new Repository<Medicine>();
```

### 💡 What’s happening?

* Creating **instances of generic class**
* Each instance is strongly typed:

| Variable     | Type                 |
| ------------ | -------------------- |
| bookRepo     | Repository<Book>     |
| medicineRepo | Repository<Medicine> |

---

## 🧠 Key Concepts Summary

### ✔ Generics

Write code once, reuse it for many types.

---

### ✔ Type Safety

The compiler ensures correct types are used.

---

### ✔ Reusability

Same repository works for different models.

---

### ✔ Separation of Concerns

Each folder has a clear responsibility:

* Models → Data
* Services → Logic
* Interfaces → Contracts
* Helpers → Utilities

---

## 🚀 Example Output

```
Books:
1 - C# Basics
2 - OOP Guide

Medicines:
1 - Paracetamol
```

---

## 🔥 Possible Improvements

* Add `Update()` method
* Add search with conditions
* Add file/database storage
* Build UI (WinForms/WPF)
* Add validation and error handling

---

## 🧩 Final Insight

This project is small, but it introduces **real-world software design ideas**:

* Repository pattern
* Abstraction using interfaces
* Clean architecture basics
* Scalable code design

---

## ✅ Conclusion

If you fully understand this project, you’ve built a strong foundation in:

* Generics
* OOP principles
* Code organization

From here, you can confidently move to more advanced systems like:

* Database-driven apps
* Desktop applications
* APIs

---
