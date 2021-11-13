using Shop.CLI.Models;
using System;
using System.Linq;

namespace Shop.CLI.Commands
{
    class DeleteProductCommand : ICommand
    {
        private readonly Store _store;

        public DeleteProductCommand(Store store)
        {
            _store = store;
        }
        public string Name => "5) Удалить продукт\n";

        public ConsoleKey Key => ConsoleKey.D5;

        public void Run()
        {
            var id = Input.Id("продукта");
            if (_store.Products.TryGetValue(id, out var product) == false)
            {
                Console.WriteLine($"Не найден продукт с идентификатором: {id}");
                return;
            }
            _store.Products.Remove(id, out product);
        }
    }
}
