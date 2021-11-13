using Shop.CLI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.CLI.Commands.ProductCommands
{
    class RemoveProductCommand : ICommand
    {
        private readonly Store _store;

        public RemoveProductCommand(Store store)
        {
            _store = store;
        }
        public string Name => "8) Для удаления товара с витрины\n";

        public ConsoleKey Key => ConsoleKey.D8;

        public void Run()
        {
            var productId = Input.Id("продукта");
            if (_store.Products.TryGetValue(productId, out var product) == false)
            {
                Console.WriteLine($"Не найден продукт с идентификатором: {productId}");
                return;
            }

            var showcaseId = Input.Id("витрины");
            if (_store.Showcases.TryGetValue(showcaseId, out var showcase) == false)
            {
                Console.WriteLine($"Не найдена витрина с идентификатором: {showcaseId}");
                return;
            }
            showcase.Products.Remove(product);
        }
    }
}
