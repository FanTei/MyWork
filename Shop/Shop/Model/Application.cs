using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    public  class Application
    {
        private const string Error = "Введите кореткое значение!";
        private const ConsoleKey Id = ConsoleKey.D1;
        private const ConsoleKey Name = ConsoleKey.D2;
        private const ConsoleKey Size = ConsoleKey.D3;
        private const ConsoleKey Add = ConsoleKey.D1;
        private const ConsoleKey Print = ConsoleKey.D2;
        private const ConsoleKey Remove = ConsoleKey.D3;
        private const ConsoleKey Edit = ConsoleKey.D4;

        public static int InputId()
        {
            int number;
            Console.WriteLine("Введите ID");
            var input = Console.ReadLine();
            while (!int.TryParse(input, out number))
            {
                Console.WriteLine(Error);
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }

        public static string InputName()
        {
            Console.WriteLine("Введите название");
            return Console.ReadLine();
        }

        public static int InputSize()
        {
            int number;
            Console.WriteLine("Введите размер");
            var input = Console.ReadLine();
            while (!int.TryParse(input, out number))
            {
                Console.WriteLine(Error);
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }

        public static int InputQuanity()
        {
            int number;
            Console.WriteLine("Введите количество");
            var input = Console.ReadLine();
            while (!int.TryParse(input, out number))
            {
                Console.WriteLine(Error);
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }

        public static double InputPrice()
        {
            double number;
            Console.WriteLine("Введите цену");
            var input = Console.ReadLine();
            while (!double.TryParse(input, out number))
            {
                Console.WriteLine(Error);
                input = Console.ReadLine();
            }
            return double.Parse(input);
        }

        private static void StoreEditMenu(Store store)
        {
            Console.WriteLine("Нажмите:\n" +
                "1)Для редактирования id\n" +
                "2)Для редактирования имениn\n" +
                "3)Для редактирования размера");
            var input = Console.ReadKey().Key;
            Console.Clear();
            store.PrintShowcases();
            switch (input)
            {
                case Id:
                    {
                        store.EditIdShowcase();
                        break;
                    }
                case Name:
                    {
                        store.EditNameShowcase();
                        break;
                    }
                case Size:
                    {
                        store.EditSizeShowcase();
                        break;
                    }
                default:
                    {
                        Console.WriteLine(Error);
                        break;
                    }
            }

        }

        public static void StoreMenu(Store store)
        {
            const ConsoleKey ShowcaseInteraction = ConsoleKey.D5;
            Console.WriteLine("Нажмите\n" +
                "1)Для добавления витрины\n" +
                "2)Для показа витрин\n" +
                "3)Для удаления витрины\n" +
                "4)Для редактирования витрины\n" +
                "5)Для работы с витринами");
            var input = Console.ReadKey().Key;
            Console.Clear();
            switch (input)
            {
                case Add:
                    {
                        store.AddShowcase();
                        break;
                    }
                case Print:
                    {
                        store.PrintShowcases();
                        break;
                    }
                case Remove:
                    {
                        store.RemoveShowcase();
                        break;
                    }
                case Edit:
                    {
                        StoreEditMenu(store);
                        break;
                    }
                case ShowcaseInteraction:
                    {
                        store.PrintShowcases();
                        ShowcaseMenu(store.FindShowcase());
                        break;
                    }
                default:
                    {
                        Console.WriteLine(Error);
                        break;
                    }
            }    
        }

        public static void ShowcaseEditMenu(Showcase showcase)
        {
            const ConsoleKey Quantity = ConsoleKey.D4;
            const ConsoleKey Price = ConsoleKey.D5;
            Console.WriteLine("Нажмите:\n" +
                "1) Для редактировния id\n" +
                "2) Для редактировния имени\n" +
                "3) Для редактировния размера\n" +
                "4) Для редактировния количества\n" +
                "5) Для редактировния цены\n");
            var input = Console.ReadKey().Key;
            switch (input)
            {
                case Id:
                    {
                        showcase.EditId();
                        break;
                    }
                case Name:
                    {
                        showcase.EditName();
                        break;
                    }
                case Size:
                    {
                        showcase.EditCapacity();
                        break;
                    }
                case Quantity:
                    {
                        showcase.EditQuantity();
                        break;
                    }
                case Price:
                    {
                        showcase.EditPrice();
                        break;
                    }           
                default:
                    {
                        Console.WriteLine(Error);
                        break;
                    }
            }
        }

        public static void ShowcaseMenu(Showcase showcase)
        {
            Console.WriteLine("Нажмите:\n" +
                "1)Для добавления продуктов\n" +
                "2)Для показа продуктов\n" +
                "3)Для удаления продуктов\n" +
                "4)Для редактирования продуктов\n");
            var input = Console.ReadKey().Key;
            switch (input)
            {
                case Add:
                    {
                        showcase.AddProduct();
                        break;
                    }
                case Print:
                    {
                        showcase.PrintProducts();
                        break;
                    }
                case Remove:
                    {
                        showcase.RemoveProduct();
                        break;
                    }
                case Edit:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine(Error);
                        break;
                    }
            }
        }

    }
}
