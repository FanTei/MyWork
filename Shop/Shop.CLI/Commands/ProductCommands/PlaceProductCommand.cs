using Shop.CLI.Commands;
using Shop.CLI.Models;
using System;
using System.Linq;

namespace Shop.CLI
{
    public class PlaceProductCommand : ICommand
    {
        private Store _store;

        public PlaceProductCommand(Store store)
        {
            _store = store;
        }

        public string Name => "7) Разместить товар на ветрине\n";
        public ConsoleKey Key => ConsoleKey.D7;

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
            showcase.Products.Add(product);
            
        }
    }
}