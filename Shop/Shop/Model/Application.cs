using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Model
{
    class Application
    {
        const string Print = "0";
        const string Add = "1";
        const string Edit = "2";
        const string Remove = "3";
        private Product product;
        private Showcase showcase;
        private static int Validate(string input)
        {
            var num = 0;
            var x = int.TryParse(input, out num);
            while (!int.TryParse(input, out num))
            {
                Console.Write("Введите целое число больше нуля:");
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }
        
        private void EditProduct(int id)
        {
            const string EditName = "1";
            const string EditCapcity = "2";
            Console.WriteLine("Введите 1 для изменения Name \nВведите 2 для изменени Capacity");
            var input = Console.ReadLine();
            switch (input)
            {
                case EditName:
                    {
                        Console.Write("Введите Name:");
                        var name = Console.ReadLine();
                        product.EditName(id, name);
                        break;
                    }
                case EditCapcity:
                    {
                        Console.Write("Введите Capacity:");
                        input = Console.ReadLine();
                        var capacity = Validate(input);
                        product.EditCapacity(id, capacity);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого дейтсвия не сущесвует");
                        input = Console.ReadLine();
                        EditProduct(id);
                        break;
                    }
            }
        }

        public void InterectsProduct()
        {
            const string Create = "1";
            Console.WriteLine("Введите:\n1)Для добавления\n2)Для редактирования\n3)Для удаления\n0)Для отабражения продуктов");
            var input = Console.ReadLine();
            switch(input)
            {
                case Create:
                    {
                        Console.Write("Введите название:");
                        var name = Console.ReadLine();
                        Console.Write("Введите занимаемый обьем:");
                        input = Console.ReadLine();
                        var capacity =Validate(input);
                        product.Create(name, capacity);
                        break;
                    }
                case Edit:
                    {
                        Console.Write("Введите ID товара:");
                        input = Console.ReadLine();
                        var id= Validate(input);
                        product.CheckId(id);
                        EditProduct(id);
                        break;
                    }
                case Remove:
                    {
                        Console.Write("Введите ID товара:");
                        input = Console.ReadLine();
                        var id = Validate(input);
                        product.Remove(id);
                        break;
                    }
                case Print:
                    {
                        product.Print();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого действия не существует");
                        InterectsProduct();
                        break;
                    }
            }
        }

        private void EditShowCase(int id)
        {
            const string EditTitle = "1";
            const string EditSize = "2";
            Console.WriteLine("Введите:\n1) для изменения Title \n2) для изменени Size");
            var input = Console.ReadLine();
            switch(input)
            {
                case EditTitle:
                    {
                        Console.Write("Введите Title:");
                        var title = Console.ReadLine();
                        showcase.EditTitle(id, title);
                        break;
                    }
                case EditSize:
                    {
                        Console.Write("Введите Size:");
                        input = Console.ReadLine();
                        var size = Validate(input);
                        showcase.EditSize(id, size);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void InterectsShowcase()
        {
            Console.WriteLine("Введите:\n1)Для добавления\n2)Для редактирования\n3)Для удаления\n0)Для отабражения витрин");
            var input = Console.ReadLine();
            switch(input)
            {
                case Add:
                    {
                        Console.Write("Введите название:");
                        var title = Console.ReadLine();
                        Console.Write("Введите размер витрины:");
                        input = Console.ReadLine();
                        var size = Validate(input);
                        showcase.Add(title, size);
                        break;
                    }
                case Edit:
                    {
                        Console.Write("Введите ID витрины:");
                        input = Console.ReadLine();
                        var id = Validate(input);
                        showcase.CheckId(id);
                        EditShowCase(id);
                        break;
                    }
                case Remove:
                    {
                        Console.Write("Введите ID витрины:");
                        input = Console.ReadLine();
                        var id = Validate(input);
                        showcase.CheckId(id);
                        showcase.Remove(id);
                        break;
                    }
                case Print:
                    {
                        showcase.Print();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого действия не существуе");
                        InterectsShowcase();
                        break;
                    }
            }
        }
    }
}
