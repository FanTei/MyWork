using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.CLI.Commands
{
   public static class Input
    {
        private const string ERROR = "Введите кореткое значение!";

        public static string Name()
        {
            Console.WriteLine("Введите название");
            return Console.ReadLine();
        }

        public static int Size()
        {
            int number;
            Console.WriteLine("Введите размер");
            var input = Console.ReadLine();
            while (!int.TryParse(input, out number))
            {
                Console.WriteLine(ERROR);
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }

        public static int Capacity()
        {
            int number;
            Console.WriteLine("Введите размер");
            var input = Console.ReadLine();
            while (!int.TryParse(input, out number))
            {
                Console.WriteLine(ERROR);
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }

        public static int Quanity()
        {
            int number;
            Console.WriteLine("Введите количество");
            var input = Console.ReadLine();
            while (!int.TryParse(input, out number))
            {
                Console.WriteLine(ERROR);
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }

        public static double Price()
        {
            double number;
            Console.WriteLine("Введите цену");
            var input = Console.ReadLine();
            while (!double.TryParse(input, out number))
            {
                Console.WriteLine(ERROR);
                input = Console.ReadLine();
            }
            return double.Parse(input);
        }

    }
}
