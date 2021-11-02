using Shop.CLI.Models;
using System;

namespace Shop.CLI
{
    public class PlaceProductCommand : ICommand
    {
        private Store _store;

        public PlaceProductCommand(Store store)
        {
            _store = store;
        }

        public string Name => "3) Разместить товар на ветрине";
        public ConsoleKey Key => ConsoleKey.D3;

        public void Run()
        {
            var productId = Guid.NewGuid();

            if (_store.Products.TryGetValue(productId, out var product) == false)
            {
                Console.WriteLine($"Не найден продукт с идентификатором: {productId}");
            }

            var showcaseId = Guid.NewGuid();

            if (_store.Showcases.TryGetValue(showcaseId, out var showcase) == false)
            {
                Console.WriteLine($"Не найдена витрина с идентификатором: {showcaseId}");
            }

            showcase.Products.Add(product);
        }
    }
}