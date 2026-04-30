//Exception handling


using System.Threading.Tasks;

namespace Examples.Services
{
    public class ErrorService
    {
        public async Task RunWithErrorAsync()
        {
            await Task.Delay(1000);
            throw new Exception("Something went wrong!");
        }
    }
}