using Shop.CLI.Models;
using System;

namespace Shop.CLI
{
    public class PrintShowcasesCommand : ICommand
    {
        private Store _store;

        public PrintShowcasesCommand(Store store)
        {
            _store = store;
        }

        public string Name => "2) Для показа витрин\n";

        public ConsoleKey Key => ConsoleKey.D2;

        public void Run()
        {
            foreach (var showcase in _store.Showcases)
            {
                Console.WriteLine(showcase.Value.Name);
            }
        }
    }
}