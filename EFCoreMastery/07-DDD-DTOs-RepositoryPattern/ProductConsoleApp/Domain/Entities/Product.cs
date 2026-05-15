namespace ProductConsoleApp.Domain.Entities{

   public class Product {

        public int Id {get; private set;}
        public string Name { get; private set;}
        public decimal Price {get; private set;}

        // Main constructor
        public Product(int id, string name, decimal price){
            Id = id;

            UpdateDetails(name, price); // uses this method for validation and setting values
        }

        public void UpdateDetails(string name, decimal price){

            if(price < 0)
                    throw new ArgumentException("Price Must be postive");
            if(string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Name Cannot be Empty");

             Name = name;
             Price = price;
        }

        // another method if updating price only is need

        public void UpdatePrice(decimal price){

            if(price < 0)
                    throw new Exception("Price cannot be negative");
            Price = price;
        }

        // Private constructor for fallback and lazy loading
        private Product(){ }
   }
}