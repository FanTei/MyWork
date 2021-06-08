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
        const string Back = "X";
        private bool IsContinue = true;
        private Product _product;
        private Showcase _showcase;
        private Market _market;
        public Application()
        {

        }
       
        public Application(Market market,Product product,Showcase showcase)
        {
            _market = market;
            _showcase = showcase;
            _product = product;
        }

        private static double ValidatePrice()
        {
            var input = Console.ReadLine();
            double num;
            var x = double.TryParse(input, out num);
            while (!double.TryParse(input, out num))
            {
                Console.Write("Введите число больше нуля:");
                input = Console.ReadLine();
            }
            return double.Parse(input);
        }
        private static int Validate()
        {
            var input = Console.ReadLine();
            int num;
            var x = int.TryParse(input, out num);
            while (!int.TryParse(input, out num))
            { 
                Console.Write("Введите целое число больше нуля:");
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }
        public void Start()
        {
            while (IsContinue)
                InterectsMarket();
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
            Console.WriteLine("Введите 1 для изменения Name \nВведите 2 для изменени Capacity\nВведите X для выхода");
            var input = Console.ReadLine().ToUpper();
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
                        var capacity = Validate();
                        _product.EditCapacity(id, capacity);
                        break;
                    }
                case Back:
                    {
                        InterectsProduct();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого дейтсвия не сущесвует");
                        input = Console.ReadLine().ToUpper();
                        EditProduct(id);
                        break;
                    }
            }
        }

        public void InterectsProduct()
        {
            const string Create = "1";
            Console.WriteLine("Введите:\n1)Для добавления\n2)Для редактирования\n3)Для удаления\n0)Для отабражения продуктов\nВведите X для выхода");
            var input = Console.ReadLine().ToUpper();
            switch(input)
            {
                case Create:
                    {
                        Console.Write("Введите название:");
                        var name = Console.ReadLine();
                        Console.Write("Введите занимаемый обьем:");
                        var capacity =Validate();
                        _product.Create(name, capacity);
                        Console.Clear();
                        break;
                    }
                case Edit:
                    {
                        _product.Print();
                        Console.Write("Введите ID товара:");
                        var id= Validate();
                        _product.CheckId(id);
                        EditProduct(id);
                        Console.Clear();
                        break;
                    }
                case Remove:
                    {
                        _product.Print();
                        Console.Write("Введите ID товара:");
                        var id = Validate();
                        _product.Remove(id);
                        Console.Clear();
                        break;
                    }
                case Print:
                    {
                        _product.Print();
                        break;
                    }
                case Back:
                    {
                        InterectsMarket();
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
            Console.WriteLine("Введите:\n1) для изменения Title \n2) для изменени Size\nВведите X для выхода");
            var input = Console.ReadLine().ToUpper();
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
                        var size = Validate();
                        _showcase.EditSize(id, size);
                        break;
                    }
                case Back:
                    {
                        InterectsShowcase();
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
            Console.WriteLine("Введите:\n1)Для добавления\n2)Для редактирования\n3)Для удаления\n0)Для отабражения витрин\nВведите X для выхода");
            var input = Console.ReadLine().ToUpper();
            switch(input)
            {
                case Add:
                    {
                        Console.Clear();
                        Console.Write("Введите название:");
                        var title = Console.ReadLine();
                        Console.Write("Введите размер витрины:");
                        var size = Validate();
                        _showcase.Add(title, size);
                        break;
                    }
                case Edit:
                    {
                        Console.Clear();
                        _showcase.Print();
                        Console.Write("Введите ID витрины:");
                        var id = Validate();
                        _showcase.CheckId(id);
                        EditShowCase(id);
                        break;
                    }
                case Remove:
                    {
                        Console.Clear();
                        _showcase.Print();
                        Console.Write("Введите ID витрины:");
                        var id = Validate();
                        _showcase.CheckId(id);
                        _showcase.Remove(id);
                        Console.Clear();
                        break;
                    }
                case Print:
                    {
                        Console.Clear();
                        _showcase.Print();
                        break;
                    }
                case Back:
                    {
                        InterectsMarket();
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
            Console.WriteLine("Введите:\n1)Для управления витринами\n2)Для управления продуктами\n3)Для управления магазином\nВведите X для выхода");
            var input = Console.ReadLine().ToUpper();
            switch(input)
            {
                case ShowcaseMenu:
                    {
                        Console.Clear();
                        InterectsShowcase();
                        InterectsMarket();
                        break;
                    }
                case ProductMenu:
                    {
                        Console.Clear();
                        InterectsProduct();
                        InterectsMarket();
                        break;
                    }
                case ShopMenu:
                    {
                        Console.Clear();
                        InterectShowcasesItems();
                        InterectsMarket();
                        break;
                    }
                case Back:
                    {
                        IsContinue = false;
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
            _showcase.Print();
            Console.Write("Введите ID витрины:");
            var showcaseId = Validate();
            _showcase.CheckId(showcaseId);
            var useShowcase = _showcase.FindShowcase(showcaseId);
            _market.PrintShowcasesItems(showcaseId);
            Console.Write("Введите ID продукта:");
            var productId = Validate();
            useShowcase.CheckProductID(productId);
            Console.WriteLine("Введите:\n1) для изменения Price \n2) для изменени Count\nВведите X для выхода");
            var input = Console.ReadLine().ToUpper();
            switch(input)
            {
                case Price:
                    {
                        Console.Write("Введите Price:");
                        var price = ValidatePrice();
                        _market.EditPrice(useShowcase, productId, price);
                        break;
                    }
                case Count:
                    {
                        Console.Write("Введите Count:");
                        var count = Validate();
                        _market.EditCount(useShowcase, productId, count);
                        break;
                    }
                case Back:
                    {
                        InterectShowcasesItems();
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
            Console.WriteLine("Введите:\n1)Для добавления товаров на витрину\n2)Для редактирования\n3)Для удаления товаров с витрины\n0)Для отаброжения продуктов на витрине\nВведите X для выхода");
            var input = Console.ReadLine().ToUpper();
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
                        var showcaseId = Validate();
                        _showcase.CheckId(showcaseId);
                        _product.Print();
                        Console.Write("Введите ID продукта:");
                        var newproduct = Validate();
                        _product.CheckId(newproduct);
                        Console.Write("Введите цену товара:");
                        var price = ValidatePrice();
                        Console.Write("Введите количество продуктов:");
                        var count = Validate();
                        _market.AddOnShowcase(showcaseId, newproduct, price, count);
                        Console.Clear();
                        break;
                    }
                case Remove:
                    {
                        _showcase.Print();
                        Console.Write("Введите ID витрины:");
                        var showcaseId = Validate();
                        _showcase.CheckId(showcaseId);
                        _market.PrintShowcasesItems(showcaseId);
                        Console.Write("Введите ID проддукта:");
                        var productid = Validate();
                        _showcase.CheckProductID(productid);
                        _market.RemoveToShowcase(showcaseId, productid);
                        Console.Clear();
                        break;                    
                    }
                case Print:
                    {
                        Console.Write("Введите ID витрины:");
                        var showcaseId = Validate();
                        _showcase.CheckId(showcaseId);
                        _market.PrintShowcasesItems(showcaseId);
                        break;
                    }
                case Back:
                    {
                        InterectsMarket();
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
                