using Shop.CLI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.CLI.Commands
{
    class PrintProductCommand : ICommand
    {
        private readonly Store _store;

        public PrintProductCommand(Store store)
        {
            _store = store;
        }
        public string Name => "6) Для показа продуктов\n";

        public ConsoleKey Key => ConsoleKey.D6;

        public void Run()
        {
            foreach(var product in _store.Products)
            {
                Console.WriteLine(product.Value.Name);
                Console.WriteLine(product.Value.Id);
                Console.WriteLine("\n");
            }
        }
    }
}
