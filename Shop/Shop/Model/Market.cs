using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    class Market
    {
        private List<Showcase> Showcases { get; set;}
        private List<Product> Products { get; set;}
       private Application _application;
       private Showcase _showcase;
       private Product _product;
        public Market()
        {
            Showcases = new List<Showcase>();
            Products = new List<Product>();

        }
        public List<Showcase> GetShowcases() { return Showcases;}

        public List<Product> GetProducts() { return Products;}

        private void Generate()
        {
            _product = new Product(this);
            _showcase = new Showcase(this);
            _application = new Application(this,_product,_showcase);
        }
        public void Start()
        {
            Generate();
            _application.Start();
        }
        
        public void AddOnShowcase(int showcaseId,int producId,double price,int count)
        {
            var useShowcase = _showcase.FindShowcase(showcaseId);
            var NewProduct = _product.FindProduct(producId);
            _application.CheSize(count, NewProduct, useShowcase);
            NewProduct.Price = price;
            NewProduct.Count = count;
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
