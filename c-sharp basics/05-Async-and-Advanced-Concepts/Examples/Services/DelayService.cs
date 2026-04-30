using System.Threading.Tasks;

namespace Examples.Services
{
    public class DelayService
    {
        public async Task RunAsync()
        {
            Console.WriteLine("Delay started...");
            await Task.Delay(2000);
            Console.WriteLine("Delay finished");
        }
    }
}