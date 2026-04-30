// Customer : an Entity has a unique ID that stays the same even if other properties change.

public class Customer
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    
    // Value Object usage
    public Address HomeAddress { get; set; }

    // 03-RelationshipsBasics (One-to-Many)
    public List<Order> Orders { get; set; } = new();

    public Customer(string name, Address address)
    {
        Id = Guid.NewGuid();
        Name = name;
        HomeAddress = address;
    }
}