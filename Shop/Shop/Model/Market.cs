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
       private Application _application;
       private Showcase _showcase;
       private Product _product;
        public Market()
        {
            Showcases = new List<Showcase>();
            Products = new List<Product>();

        }
        
        public void Start()
        {
            _product = new Product(this);
            _showcase = new Showcase(this);
            _application = new Application(this,_product,_showcase);
            _application.InterectsMarket();
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

        /*private void ChecSize (int count,Product product,Showcase showcase)
        //{
        //    var sum = showcase.SumProductCapacity();
        //    var capacity = product.Capacity;
        //    if(sum<capacity*count)
        //    {
        //        Console.WriteLine("Продукт не помещается на витрине");
        //        ShopUsing();
        //    }
         */


        //}
        //private double ValidatePrice(string input)
        //{
        //    double num = 0;
        //    var x = double.TryParse(input, out num);
        //    while (!double.TryParse(input, out num))
        //    {
        //        Console.Write("Введите число больше нуля:");
        //        input = Console.ReadLine();
        //    }
        //    return double.Parse(input);
        //}

        public void AddOnShowcase(int showcaseId,int producId,int price,int count)
        {
            var useShowcase = _showcase.FindShowcase(showcaseId);
            var NewProduct = _product.FindProduct(producId);  
            NewProduct.Price = price;
            NewProduct.Count = count;
            //ChecSize(count, producToAdd, thisShowcase);
            useShowcase.products.Add(NewProduct);
        }

        public void RemoveToShowcase(int showcaseId,int productId)
        {
            PrintShowcasesItems(showcaseId);
            var useshowcase = _showcase.FindShowcase(showcaseId);
            var productToRemove = _showcase.FindShowCaseItem(useshowcase,productId);
            useshowcase.products.Remove(productToRemove);
        }

        public void PrintShowcasesItems(int showcaseId)
        {
            var useShowcase = _showcase.FindShowcase(showcaseId);
            foreach (var x in useShowcase.products)
                Console.WriteLine(x.ID + ")" + "Name:" + x.Name + " Price:" + x.Price + " Count:" + x.Count);
        }

    }
}
