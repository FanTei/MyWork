using Shop.CLI.Models;
using System;

namespace Shop.CLI
{
    public class Application
    {
        private Store _store;
        private Menu _menu;

        public Application()
        {
            _store = new Store();

            _menu = new Menu();
            _menu.AddCommand(new PrintShowcasesCommand(_store));
            _menu.AddCommand(new CreateProductCommand(_store));
            _menu.AddCommand(new PlaceProductCommand(_store));
        }

        public void Run()
        {

            const ConsoleKey End = ConsoleKey.Escape;
            ConsoleKey input;

            do
            {
                _menu.Print();
                input = Console.ReadKey(true).Key;
                _menu.InvokeCommand(input);

            } while (input != End);

        }
    }
}
