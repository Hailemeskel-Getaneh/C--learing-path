using System;
using System.Threading.Tasks;
using Examples.Services;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Program started\n");

        var delayService = new DelayService();
        await delayService.RunAsync();

        var dataService = new DataService();
        var data = await dataService.GetDataAsync();
        Console.WriteLine(data);

        var processingService = new ProcessingService();
        await processingService.ProcessAsync();

        var loopService = new LoopService();
        await loopService.RunLoopAsync();

        var errorService = new ErrorService();
        try
        {
            await errorService.RunWithErrorAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught error: {ex.Message}");
        }

        Console.WriteLine("\nProgram finished");
    }
}