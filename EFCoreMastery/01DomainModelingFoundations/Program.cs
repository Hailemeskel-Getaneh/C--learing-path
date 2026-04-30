using System;

// Initialize Value Object and create entity
// var myAddress = new Address("123 university road", "Debre Berhan", "10101");
// var customer = new Customer("Ayalew", myAddress)

// another way without using variable just passing the object directly
var customer = new Customer("Haile Dev", new Address("123 university road", "Debre Berhan", "10101"));

// Establish Relationships
customer.Orders.Add(new Order(99.99m));
customer.Orders.Add(new Order(45.50m));

// Output
Console.WriteLine($"Customer: {customer.Name} (ID: {customer.Id})");
Console.WriteLine($"Lives at: {customer.HomeAddress.Street}, {customer.HomeAddress.City}");
Console.WriteLine($"Total Orders: {customer.Orders.Count}");