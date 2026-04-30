// using async in Looops

using System.Threading.Tasks;

namespace Examples.Services
{
    public class LoopService
    {
        public async Task RunLoopAsync()
        {
            for (int i = 1; i <= 3; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine($"Loop step {i}");
            }
        }
    }
}