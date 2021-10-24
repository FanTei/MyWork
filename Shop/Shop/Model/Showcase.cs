   using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
   public class Showcase : IShowcase
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

        public int? Id { get; set ; }

        public string Name { get; set ; }

        public int Size { get ; set ; }

        public DateTime CreateTime { get ; set; }

        public DateTime DeliteTime { get ; set; }

        private int OccupiedSize()
        {
            int sum = 0;
            foreach (var product in _products)
            {
                sum += product.Capacity * product.Quantity;
            }
            return sum;
        }


        private Product FindProduct()
        {
            int Id = Application.InputId();
            foreach (var product in _products)
            {
                if (product.Id == Id)
                    return product;
            }
            Console.WriteLine("Такого id не существует!");
            FindProduct();
            return new Product();
        }

        public void EditId()
        {
            Product AlterableShowcase = FindProduct();
            int NewId = Application.InputId();
            AlterableShowcase.Id = NewId;
        }

        public void EditName()
        { 
            Product AlterableShowcase = FindProduct();
            string NewName = Application.InputName();
            AlterableShowcase.Name = NewName;
        }

        public void EditQuantity()
        {
            Product AlterableShowcase = FindProduct();
            int NewQuantity = Application.InputQuanity();
            AlterableShowcase.Quantity = NewQuantity;
        }

        public void EditCapacity()
        {
            Product AlterableShowcase = FindProduct();
            int NewCapacity = Application.InputSize();
            AlterableShowcase.Capacity = NewCapacity;
        }

        public void EditPrice()
        {
            Product AlterableShowcase = FindProduct();
            double NewPrice = Application.InputPrice();
            AlterableShowcase.Price = NewPrice;
        }

        public void AddProduct()
        {
            int id = Application.InputId();
            string name = Application.InputName();
            int capacity = Application.InputSize();
            int quantity = Application.InputQuanity();
            double price = Application.InputPrice();
            Product AddedProduct = new Product(id, name, capacity, price, quantity);
            _products.Add(AddedProduct);
        }

        public void PrintProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine("Id: " + product.Id +
                    "Название: "+product.Name + 
                    "Количество: " +product.Quantity + 
                    "Цена: " + product.Price);
            }
        }

        public void RemoveProduct()
        {
            PrintProducts();
            _products.Remove(FindProduct());
        }
    }
}
