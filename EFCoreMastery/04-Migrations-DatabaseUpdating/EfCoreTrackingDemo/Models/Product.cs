namespace EfCoreTrackingDemo.Models{

    public class Product{
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;

        // new column to test migration
        public decimal Price {get; set;}
    }
}