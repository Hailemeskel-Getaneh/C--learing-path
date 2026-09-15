using ProductSupplier.Domain.Common;

namespace ProductSupplier.Domain.Entities {

    public class Product :BaseEntity {

        public string Name {get; private set;} = string.Empty;
        public decimal Price {get; private set;}
        public int QuantityInStock {get; private set;}
        // Foreing key
        public int SupplierId {get; private set;}
        // Navigation property
        public Supplier Supplier {get; private set;} = null!;

        public Product ( string name, decimal price, int quantity, int supplierId){
            setName(name);
            setPrice(price);
            setQuantity(quantity);

            SupplierId = supplierId;
            CreatedAt = DateTime.UtcNow;
        }

        // Private constructor : Required by EF core to bypass and rehydartion
        private Product(){

        }

        // Business Methods

        public void setName( string name){

            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be Empty");
            if(name.Length > 100)
                 throw new ArgumentException("Name is too long");

                 Name = name;
        }

        public void setPrice(decimal price){

            if(price < 0)
                    throw new ArgumentException("Price cannot be negative");

            Price = price;
        }

        public void setQuantity( int quantity){

            if(quantity <= 0)
                    throw new ArgumentException("Quantity cannot be negative");

            QuantityInStock = quantity;
        }

       public void IncreaseInStock(int amount){

            if(amount <= 0)
                    throw new ArgumentException("Increase stock cannot be negative");
                
            QuantityInStock += amount;
       }

       public void DecreaseInStock(int amount){

            if(amount <= 0)
                    throw new ArgumentException("Increase in stock cannot be Negative");
            
            if(QuantityInStock - amount < 0)
                    throw  new ArgumentException("Insufficient stock");

            QuantityInStock -= amount;
       }

    }



}