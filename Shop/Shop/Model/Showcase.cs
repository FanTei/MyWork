using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    class Showcase : IShowcase
    {
        private List<Product> _products;
        public Showcase()
        {

        }
        public Showcase(int id,string name,int size)
        {
            Size = size;
            Name = name;
            Id = id;
            CreateTime = DateTime.Now;
            DeliteTime = DateTime.MinValue;
            _products = new List<Product>();
        }
        public int Id { get; set ; }

        public string Name { get; set ; }

        public int Size { get ; set ; }

        public DateTime CreateTime { get ; set; }

        public DateTime DeliteTime { get ; set; }

        public void Use()
        {
            Console.WriteLine("1-добавить");
            Console.WriteLine("2-показать");
            Console.WriteLine("3-удалить");
            Console.WriteLine("4-меню с митринами");
            string input = Console.ReadLine();
            if (input == "1")
                AddProduct();
            if (input == "2")
                PrintProducts();
            if (input == "3")
                RemoveProduct();
        }
        public void AddProduct()
        {
            int id = Application.InputID();
            string name = Application.InputName();
            Console.WriteLine("Введите размер товара:");
            int capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество товара:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите цену товара:");
            int price = int.Parse(Console.ReadLine());
            Product AddedProduct = new Product(id, name, capacity, price, quantity);
            _products.Add(AddedProduct);
        }

        public void PrintProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product.Id+ ") " + product.Name + " " +product.Quantity+ " " + product.Price);
            }
        }

        public void RemoveProduct()
        {
            PrintProducts();
            Console.WriteLine("Введите ID товара");
            int id = int.Parse(Console.ReadLine());
            foreach (var product in _products)
            {
                if (product.Id == id)
                    _products.Remove(product);  
            }
        }
    }
}
