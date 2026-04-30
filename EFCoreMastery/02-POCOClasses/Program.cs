using MyApp.Basic;
using MyApp.Properties;

// 1. Using Basic POCO (Fields)
var item = new Product();
item.Id = 101;
item.Name = "Mechanical Keyboard";
item.Price = 89.99m;

// 2. Using POCO with Properties
var emp = new Employee
{
    Id = 1,
    FullName = "Jane Doe",
    Salary = 55000m
};

Console.WriteLine($"[Basic POCO] Product: {item.Name} costs ${item.Price}");
Console.WriteLine($"[Property POCO] Employee: {emp.FullName}, Salary: ${emp.Salary}");

// Demonstrating the benefit of Properties:
try {
    emp.Salary = -100; // This will trigger our logic gate
} catch (Exception ex) {
    Console.WriteLine($"[Validation] Error: {ex.Message}");
}