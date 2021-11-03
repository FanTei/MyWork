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
        public string Name => "3) Удалить витрину";

        public ConsoleKey Key => ConsoleKey.D3;

        public void Run()
        {
            var name = Input.Name();
            var deleteShowcase = _store.Showcases.FirstOrDefault(x => x.Value.Name == name).Value;
            _store.Showcases.Remove(deleteShowcase.Id,out deleteShowcase);
        }
    }
}
