using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoggerApp
{
    internal class Program
    {

        private static async Task Main(string[] args)
        {
            ExampleClass exampleClass = new ExampleClass();
            ExampleClass2 exampleClass2 = new ExampleClass2();
            for (Int32 i = 0; i < 50; i++)
            {
                exampleClass.DevideAsync();
                exampleClass2.OutOfRange2();

            }
            Console.ReadKey();

        }
    }
}
