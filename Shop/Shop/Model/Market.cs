using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    class Market
    {
        public List<Showcase> Showcases { get; set;}
        public List<Product> Products { get; set;}
        Application application = new Application();
        Showcase showcase = new Showcase();
        Product product = new Product();
        public Product FindShowCaseItem(Showcase showcase,int productId)
        {
            var product = new Product();
            foreach (var item in showcase.products)
            {
                if (item.ID == productId)
                   product = item;
            }
            return product;
        }
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
        public void AddOnShowcase(int showcaseId,int producId,int price,int count)
        {
            var useShowcase = showcase.FindShowcase(showcaseId);
            var NewProduct = product.FindProduct(producId);  
            NewProduct.Price = price;
            NewProduct.Count = count;
            //ChecSize(count, producToAdd, thisShowcase);
            useShowcase.products.Add(NewProduct);
        }
        public void EditToShowCase(int showcaseId)
        {
            //var showcases = showcase.ReturnListShowcases();
            showcase.Print();            
            var useShowcase = showcase.FindShowcase(showcaseId);
            PrintShowcasesItems(showcaseId);
            Console.Write("Введите ID продукта:");
            var input = Console.ReadLine();
            var productId = Validate(input);
            useShowcase.CheckProductID(productId);
            var editingProduct = useShowcase.FindShowcase(productId);
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
        public void RemoveToShowcase(int showcaseId,int productId)
        {
            var showcases = showcase.ReturnListShowcases();
            PrintShowcasesItems(showcaseId);
            var useshowcase = showcase.FindShowcase(showcaseId);
            var productToRemove = product.FindProduct(productId);
            useshowcase.products.Remove(productToRemove);
        }
        public void PrintShowcasesItems(int showcaseId)
        {
            var useShowcase = showcase.FindShowcase(showcaseId);
            foreach (var x in useShowcase.products)
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
                            application.InterectShowcasesItems();
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
    }
}
