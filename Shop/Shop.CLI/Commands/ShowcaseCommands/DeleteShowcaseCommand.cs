using Shop.CLI.Models;
using System;
using System.Linq;

namespace Shop.CLI.Commands
{
    class DeleteShowcaseCommand : ICommand
    {
        private readonly Store _store;

        public DeleteShowcaseCommand(Store store)
        {
            _store = store;
        }
        public string Name => "3) Удалить витрину\n";

        public ConsoleKey Key => ConsoleKey.D3;

        public void Run()
        {
            var id = Input.Id("витрины");
            if (_store.Showcases.TryGetValue(id, out var showcase) == false)
            {
                Console.WriteLine($"Не найден продукт с идентификатором: {id}");
                return;
            }
            _store.Showcases.Remove(id, out showcase);
        }
    }
}
