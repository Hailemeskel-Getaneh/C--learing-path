using System.Threading.Tasks;

namespace Examples.Services
{
    public class ProcessingService
    {
        public async Task ProcessAsync()
        {
            Console.WriteLine("Step 1");
            await Task.Delay(1000);

            Console.WriteLine("Step 2");
            await Task.Delay(1000);

            Console.WriteLine("Step 3");
        }
    }
}