# Generics in C#

Generics are a powerful feature in C# that allow you to define classes, interfaces, methods, and delegates with a placeholder for the data type. This enables you to write code that is reusable, type-safe, and efficient.

## Why Use Generics?

1.  **Type Safety**: Generics provide compile-time type checking. If you try to use an incompatible type, the compiler will catch it, preventing runtime errors.
2.  **Performance**: Generics avoid the overhead of **boxing** and **unboxing** when working with value types (like `int`, `double`, etc.). This is much faster than using the `object` type.
3.  **Code Reusability**: You can write a single class or method that works with any data type, reducing code duplication.

---

## Generic Classes

A generic class is defined with a type parameter in angle brackets `<T>`.

```csharp
public class Box<T>
{
    private T _content;

    public void Pack(T item)
    {
        _content = item;
        Console.WriteLine($"Packed: {item}");
    }

    public T Unpack()
    {
        return _content;
    }
}

// Usage:
Box<int> intBox = new Box<int>();
intBox.Pack(123);

Box<string> stringBox = new Box<string>();
stringBox.Pack("Hello Generics");
```

---

## Generic Methods

Methods can also be generic, even if the class they belong to is not.

```csharp
public class Utility
{
    public static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp = lhs;
        lhs = rhs;
        rhs = temp;
    }
}

// Usage:
int a = 5, b = 10;
Utility.Swap<int>(ref a, ref b);

string s1 = "world", s2 = "hello";
Utility.Swap(ref s1, ref s2); // Type inference handles this automatically
```

---

## Constraints on Type Parameters

You can restrict the types that can be used as arguments for a generic type using the `where` keyword.

| Constraint | Description |
| :--- | :--- |
| `where T : struct` | `T` must be a value type (int, bool, etc.). |
| `where T : class` | `T` must be a reference type (string, class, etc.). |
| `where T : new()` | `T` must have a public parameterless constructor. |
| `where T : <base class>` | `T` must be or derive from the specified base class. |
| `where T : <interface>` | `T` must implement the specified interface. |

Example:
```csharp
public class Repository<T> where T : class, new()
{
    public T CreateInstance()
    {
        return new T(); // Allowed because of the new() constraint
    }
}
```

---

## The `default` Keyword

In generic code, you might not know the default value of `T` (e.g., `0` for `int`, `null` for `string`). The `default(T)` (or just `default` in newer C# versions) keyword provides the correct default value.

```csharp
public T GetDefaultValue<T>()
{
    return default(T);
}
```

---

## Common Generic Collections

The `System.Collections.Generic` namespace provides several built-in generic types:

-   `List<T>`: A dynamic array.
-   `Dictionary<TKey, TValue>`: A collection of key/value pairs.
-   `Queue<T>`: A first-in, first-out (FIFO) collection.
-   `Stack<T>`: A last-in, first-out (LIFO) collection.
-   `HashSet<T>`: A collection of unique elements.

---

## Summary

Generics are essential for modern C# development. They allow you to create flexible, high-performance, and type-safe components that can adapt to different data types without sacrificing code quality or safety.
