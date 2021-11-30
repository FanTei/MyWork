using Shop.CLI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.CLI.Commands
{
    class CreateShowcaseHandler : ICommand
    {
        private readonly Store _store;

        public CreateShowcaseHandler(Store store)
        {
            _store = store;
        }
        public string Name => "1) Создать новую витрину\n";

        public ConsoleKey Key => ConsoleKey.D1;

        public void Run()
        {
            var showcase = new Showcase();
            showcase.Name = Input.Name();
            showcase.Size = Input.Size();
            _store.Showcases.Add(showcase.Id, showcase);
        }
    }
}
