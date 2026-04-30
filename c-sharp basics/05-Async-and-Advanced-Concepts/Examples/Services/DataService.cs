using System.Threading.Tasks;

namespace Examples.Services
{
    public class DataService
    {
        public async Task<string> GetDataAsync()
        {
            await Task.Delay(1500);
            return "Data loaded";
        }
    }
}