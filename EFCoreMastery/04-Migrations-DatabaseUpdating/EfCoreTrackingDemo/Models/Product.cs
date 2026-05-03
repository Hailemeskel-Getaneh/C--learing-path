namespace EfCoreTrackingDemo.Models{

    public class Product{
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;

        // add another property to test migration again
        public decimal Price { get; set;}

    }
}