// This represents the link between a Customer and their purchases.

public class Order
{
    public Guid OrderId { get; private set; }
    public decimal Amount { get; set; }

    public Order(decimal amount)
    {
        OrderId = Guid.NewGuid();
        Amount = amount;
    }
}