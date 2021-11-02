using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.CLI
{
    public class Menu
    {
        private readonly Dictionary<ConsoleKey, ICommand> _commands;

        public Menu()
        {
            _commands = new Dictionary<ConsoleKey, ICommand>();
        }

        public void Print()
        {
            var stringBuilder = new StringBuilder("Нажмите\n");

            foreach (var command in _commands)
            {
                stringBuilder.Append(command.Value.Name);
            }
            var message = stringBuilder.ToString();

            Console.WriteLine(message);
        }

        public void AddCommand(ICommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _commands.Add(command.Key, command);
        }

        public void InvokeCommand(ConsoleKey input)
        {
            if (_commands.TryGetValue(input, out var command) == false)
            {
                Console.WriteLine($"Не найден обработчик для команды: {input}");
                return;
            }

            command.Run();
        }
    }
}