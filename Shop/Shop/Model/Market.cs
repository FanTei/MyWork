using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    class Market
    {
        Application application = new Application();
        Showcase showcase = new Showcase();
        Product product = new Product();
       
        private int Validate(string input)
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
        private void ChecSize (int count,Product product,Showcase showcase)
        {
            var sum = showcase.SumProductCapacity();
            var capacity = product.Capacity;
            if(sum<capacity*count)
            {
                Console.WriteLine("Продукт не помещается на витрине");
                ShopUsing();
            }
           
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
        public void AddOnShowcase()
        {

            var products = product.ListProduct(); 
            var showcases = showcase.ReturnListShowcases();
            showcase.Print();
            Console.Write("Введите ID витрины:");
            var thisShowcase = new Showcase();
            var input = Console.ReadLine();
            var showcaseId = Validate(input);
            showcase.CheckId(showcaseId);
            foreach (var item in showcases)
            {
                if (item.ID == showcaseId)
                    thisShowcase = item;
            }
            product.Print();
            Console.Write("Введите ID продукта:");
            input = Console.ReadLine();
            var productId = Validate(input);
            product.CheckId(productId);
            Product producToAdd =new Product();
            foreach (var x in products)
            {
                if (x.ID == productId)
                {
                   producToAdd =x;
                    break;
                }
            }
            Console.Write("Введите цену товара:");
            input = Console.ReadLine();
            var price = ValidatePrice(input);
            while(price<0)
            {
                Console.WriteLine("Цена должна быть больше 0");
                input = Console.ReadLine();
                price = ValidatePrice(input);
            }
            producToAdd.Price = price;
            Console.Write("Введите цену количество:");
            input = Console.ReadLine();
            var count = Validate(input);
            producToAdd.Count = count;
            ChecSize(count, producToAdd, thisShowcase);
            thisShowcase.products.Add(producToAdd);
        }
        public void EditToShowCase()
        {
            var showcases = showcase.ReturnListShowcases();
            showcase.Print();
            Console.Write("Введите ID витрины:");
            var input = Console.ReadLine();
            var showcaseId = Validate(input);
            showcase.CheckId(showcaseId);
            var thisShowCase = new Showcase();
            foreach(var item in showcases)
            {
                if (item.ID == showcaseId)
                    thisShowCase = item;
            }
            var editingProduct = new Product();
            PrintShowcasesItems(showcaseId);
            Console.Write("Введите ID продукта:");
            var productId = Validate(input);
            thisShowCase.CheckProductID(productId);
            foreach (var item in thisShowCase.products)
            {
                if (item.ID == productId)
                    editingProduct = item;
            }
            input = Console.ReadLine();
            Console.WriteLine("Введите:\n1) для изменения Price \n2) для изменени Count");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    {
                        Console.Write("Введите Price:");
                        input = Console.ReadLine();
                        var price = ValidatePrice(input);
                        editingProduct.Price = price;
                        break;
                    }
                case "2":
                    {
                        Console.Write("Введите Count:");
                        input = Console.ReadLine();
                        var count = Validate(input);
                        ChecSize(count, editingProduct, thisShowCase);
                        editingProduct.Count = count;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого дейтсвия не сущесвует");
                        input = Console.ReadLine();
                        break;
                    }
            }
        }
        public void RemoveToShowcase()
        {
            showcase.Print();
            Console.Write("Введите ID витрины:");
            var showcases = showcase.ReturnListShowcases();
            var input = Console.ReadLine();
            var showcaseId = Validate(input);
            showcase.CheckId(showcaseId);
            PrintShowcasesItems(showcaseId);
            var thisShowcase = new Showcase();
            foreach (var item in showcases)
            {
                if (item.ID == showcaseId)
                    thisShowcase = item;
            }
            Console.Write("Введите ID проддукта:");
            input = Console.ReadLine();
            var productid = Validate(input);
            showcase.CheckProductID(productid);
            var producttoRemove = new Product();
            foreach (var item in thisShowcase.products)
            {
                if (item.ID == productid)
                {
                    producttoRemove = item;
                    thisShowcase.products.Remove(producttoRemove);
                }  
            }
           
            
        }
        public void PrintShowcasesItems(int Id)
        {
            var showcases = showcase.ReturnListShowcases();
            var thisShowcase = new Showcase();
            foreach (var item in showcases)
            {
                if (item.ID == Id)
                    thisShowcase = item;
            }
            foreach (var x in thisShowcase.products)
                Console.WriteLine(x.ID + ")" + "Name:" + x.Name + " Price:" + x.Price + " Count:" + x.Count);
        }
        public void ShopUsing()
        {
            Console.WriteLine("Введите:\n1)Для управления витринами\n2)Для управления продуктами\n3)Для управления магазином");
            var input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "1":
                        {
                            Console.Clear();
                            application.InterectsShowcase();
                            ShopUsing();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            application.InterectsProduct();
                            ShopUsing();
                            break;
                        }
                    case "3":
                        {
                            Interect();
                            ShopUsing();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Такого действия не существует");
                            ShopUsing();
                            break;
                        }
                }
            }
        }
        public void Interect()
        {
            Console.WriteLine("Введите:\n1)Для добавления товаров на витрину\n2)Для удаления товаров с витрины\n0)Для отаброжения продуктов на витрине");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    {
                        Console.Clear();
                        AddOnShowcase();
                        ShopUsing();
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        RemoveToShowcase();
                        ShopUsing();
                        break;
                    }
                case "0":
                    {
                        showcase.Print();
                        Console.Write("Введите Id витрины:");
                        input = Console.ReadLine();
                        var showcaseId = Validate(input);
                        showcase.CheckId(showcaseId);
                        PrintShowcasesItems(showcaseId);
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Такого действия не существует");
                        Interect();
                        break;
                    }
            }
        }
    }
}
