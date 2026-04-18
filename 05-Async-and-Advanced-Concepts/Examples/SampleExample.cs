namespace Examples;


public class TestExample{

        public static async Task Test()
        {
            Console.WriteLine("A");

            await System.Threading.Tasks.Task.Delay(2000);

            Console.WriteLine("B");
        }

}
