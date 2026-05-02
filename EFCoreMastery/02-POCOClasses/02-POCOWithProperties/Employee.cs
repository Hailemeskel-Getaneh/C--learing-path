
namespace MyApp.Properties
{
    public class Employee
    {
        // Auto-implemented properties
        public int Id { get; set; }
        public string FullName { get; set; }

        // Property with logic (Encapsulation)
        private decimal _salary;
        
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0) throw new ArgumentException("Salary cannot be negative!");
                _salary = value;
            }
        }
    }
}