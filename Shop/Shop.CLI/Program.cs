using System;
using System.Text;

namespace Shop.CLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var app = new Application();
            app.Run();
        }
    }
}
