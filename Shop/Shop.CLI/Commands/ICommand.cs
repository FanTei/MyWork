using System;

namespace Shop.CLI
{
    public interface ICommand
    {
        string Name { get; }
        ConsoleKey Key { get; }

        void Run();
    }
}