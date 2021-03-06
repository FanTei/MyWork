using Shop.CLI.Commands;
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
        public ConsoleKey Key => ConsoleKey.D4;
        public string Name => "4) Для создания нового товара\n";

        public void Run()
        {
            var product = new Product();
            product.Name = Input.Name();
            product.Quantity = Input.Quanity();
            product.Capacity = Input.Capacity();
            product.Price = Input.Price();
            _store.Products.Add(product.Id, product);
        }
    }
}