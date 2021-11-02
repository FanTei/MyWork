using Shop.CLI.Models;
using System;

namespace Shop.CLI
{
    public class CreateProductCommand : ICommand
    {
        private readonly Store _store;

        public CreateProductCommand(Store store)
        {
            _store = store;
        }

        public ConsoleKey Key => ConsoleKey.D1;
        public string Name => "1) Для создания нового товара\n";

        public void Run()
        {
            var product = new Product();
            _store.Products.Add(product.Id, product);
        }
    }
}