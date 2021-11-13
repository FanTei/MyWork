using Shop.CLI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.CLI.Commands.ShowcaseCommands
{
    class PrintShowcasesItemsCommand : ICommand
    {
        private readonly Store _store;

        public PrintShowcasesItemsCommand(Store store)
        {
            _store = store;
        }

        public string Name => "9) Показать продукты на винтрине\n";

        public ConsoleKey Key => ConsoleKey.D9;

        public void Run()
        {
            var id = Input.Id("витрины");
            if (_store.Showcases.TryGetValue(id, out var showcase) == false)
            {
                Console.WriteLine($"Не найден продукт с идентификатором: {id}");
                return;
            }
            foreach (var product in showcase.Products)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Id);
                Console.WriteLine("\n");
            }

        }
    }
}
