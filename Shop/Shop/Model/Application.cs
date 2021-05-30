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
        private Product _product;
        private Showcase _showcase;
        private Market _market;
        public Application()
        {

        }
        private double ValidatePrice(string input)
        {
            double num = 0;
            var x = double.TryParse(input, out num);
            while (!double.TryParse(input, out num))
            {
                Console.Write("Введите число больше нуля:");
                input = Console.ReadLine();
            }
            return double.Parse(input);
        }

        public Application(Market market,Product product,Showcase showcase)
        {
            _market = market;
            _showcase = showcase;
            _product = product;
        }

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
        public int CheSize(int count, Product product, Showcase showcase)
        {
            var IsContinue = IsLegitSize(count, product, showcase);
            while(!IsContinue)
            {
                Console.WriteLine("Предмет не помезается на витрине");
                count = int.Parse(Console.ReadLine());
            }
            return count;
        }

        public bool IsLegitSize(int count, Product product, Showcase showcase)
        {
            var sum = showcase.SumProductCapacity();
            var capacity = product.Capacity;
            if (sum < capacity * count)
            {
                Console.WriteLine("Продукт не помещается на витрине");
                return false;
            }
            return true;
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
                        _product.EditName(id, name);
                        break;
                    }
                case EditCapcity:
                    {
                        Console.Write("Введите Capacity:");
                        input = Console.ReadLine();
                        var capacity = Validate(input);
                        _product.EditCapacity(id, capacity);
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
                        _product.Create(name, capacity);
                        break;
                    }
                case Edit:
                    {
                        Console.Write("Введите ID товара:");
                        input = Console.ReadLine();
                        var id= Validate(input);
                        _product.CheckId(id);
                        EditProduct(id);
                        break;
                    }
                case Remove:
                    {
                        Console.Write("Введите ID товара:");
                        input = Console.ReadLine();
                        var id = Validate(input);
                        _product.Remove(id);
                        break;
                    }
                case Print:
                    {
                        _product.Print();
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
                        _showcase.EditTitle(id, title);
                        break;
                    }
                case EditSize:
                    {
                        Console.Write("Введите Size:");
                        input = Console.ReadLine();
                        var size = Validate(input);
                        _showcase.EditSize(id, size);
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
                        _showcase.Add(title, size);
                        break;
                    }
                case Edit:
                    {
                        Console.Write("Введите ID витрины:");
                        input = Console.ReadLine();
                        var id = Validate(input);
                        _showcase.CheckId(id);
                        EditShowCase(id);
                        break;
                    }
                case Remove:
                    {
                        Console.Write("Введите ID витрины:");
                        input = Console.ReadLine();
                        var id = Validate(input);
                        _showcase.CheckId(id);
                        _showcase.Remove(id);
                        break;
                    }
                case Print:
                    {
                        _showcase.Print();
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

        public void InterectsMarket()
        {
            const string ShowcaseMenu = "1";
            const string ProductMenu = "2";
            const string ShopMenu = "3";
            Console.WriteLine("Введите:\n1)Для управления витринами\n2)Для управления продуктами\n3)Для управления магазином");
            var input = Console.ReadLine();
            switch(input)
            {
                case ShowcaseMenu:
                    {
                        InterectsShowcase();
                        InterectsMarket();
                        break;
                    }
                case ProductMenu:
                    {
                        InterectsProduct();
                        InterectsMarket();
                        break;
                    }
                case ShopMenu:
                    {
                        InterectShowcasesItems();
                        InterectsMarket();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого действия не существует");
                        break;
                    }
            }
        }

        public void EditShowcaseItem()
        {
            const string Price = "1";
            const string Count = "2";
            Console.Write("Введите ID витрины:");
           var input = Console.ReadLine();
            var showcaseId = Validate(input);
            _showcase.CheckId(showcaseId);
            var useShowcase = _showcase.FindShowcase(showcaseId);
            Console.Write("Введите ID продукта:");
            input = Console.ReadLine();
            var productId = Validate(input);
            useShowcase.CheckProductID(productId);
            Console.WriteLine("Введите:\n1) для изменения Price \n2) для изменени Count");
            input = Console.ReadLine();
            switch(input)
            {
                case Price:
                    {
                        Console.Write("Введите Price:");
                        input = Console.ReadLine();
                        var price = Validate(input);
                        _product.EditPrice(useShowcase, productId, price);
                        break;
                    }
                case Count:
                    {
                        Console.Write("Введите Price:");
                        input = Console.ReadLine();
                        var count = Validate(input);
                        _product.EditCount(useShowcase, productId, count);
                        break;
                    }
                default:
                    {
                         
                        Console.WriteLine("Такого действия не существует");
                        break;
                    }
            }

        }

        public void InterectShowcasesItems()
        {
            Console.WriteLine("Введите:\n1)Для добавления товаров на витрину\n2)Для редактирования\n3)Для удаления товаров с витрины\n0)Для отаброжения продуктов на витрине");
            var input = Console.ReadLine();
            switch(input)
            {
                case Edit:
                    {
                        break;
                    }
                case Add:
                    {
                        _showcase.Print();
                        Console.Write("Введите ID витрины:");
                        input = Console.ReadLine();
                        var showcaseId = Validate(input);
                        _showcase.CheckId(showcaseId);
                        Console.Write("Введите ID продукта:");
                        input = Console.ReadLine();
                        var newproduct = Validate(input);
                        _product.CheckId(newproduct);
                        Console.Write("Введите цену товара:");
                        input = Console.ReadLine();
                        var price = Validate(input);
                        input = Console.ReadLine();
                        var count = Validate(input);
                        _market.AddOnShowcase(showcaseId, newproduct, price, count);
                        break;
                    }
                case Remove:
                    {
                        _showcase.Print();
                        Console.Write("Введите ID витрины:");
                        input = Console.ReadLine();
                        var showcaseId = Validate(input);
                        _showcase.CheckId(showcaseId);
                        Console.Write("Введите ID проддукта:");
                        input = Console.ReadLine();
                        var productid = Validate(input);
                        _showcase.CheckProductID(productid);
                        _market.RemoveToShowcase(showcaseId, productid);

                        break;
                    }
                case Print:
                    {
                        Console.Write("Введите Id витрины:");
                        input = Console.ReadLine();
                        var showcaseId = Validate(input);
                        _showcase.CheckId(showcaseId);
                        _market.PrintShowcasesItems(showcaseId);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого действия не существует");
                        InterectShowcasesItems();
                        break;
                    }


            }
        }
    }
}
