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

        public int Id { get; set ; }

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

        private bool IsAuthenticId(int id)
        {
            if(_products.Any(x=>x.Id==id))
            {
                Console.WriteLine("Такой Id уже существует");
                return false;
            }
            return true;
        }

        private bool IsPlace(int quantity, int capacity)
        {
            int AllOccupiedSize = OccupiedSize() + (quantity * capacity);
            if (AllOccupiedSize > Size)
                return false;
            return true;
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
            while(!IsAuthenticId(NewId))
                NewId =Application.InputId();
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
            if (IsPlace(AlterableShowcase.Capacity, NewQuantity))
            {
                AlterableShowcase.Quantity = NewQuantity; ;
            }
            else
            {
                Console.WriteLine("Продукт не помещается!");
                EditQuantity();
            }
            
        }

        public void EditCapacity()
        {
            Product AlterableShowcase = FindProduct();
            int NewCapacity = Application.InputSize();
            if (IsPlace(AlterableShowcase.Quantity, NewCapacity))
            {
                AlterableShowcase.Capacity = NewCapacity;
            }
            else
            {
                Console.WriteLine("Продукт не помещается!");
                EditCapacity();
            }

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
            if (!IsAuthenticId(id))
                id = Application.InputId();
            string name = Application.InputName();
            int capacity = Application.InputSize();
            int quantity = Application.InputQuanity();
            double price = Application.InputPrice();
            Product AddedProduct = new Product(id, name, capacity, price, quantity);
            if(IsPlace(capacity, quantity))
                _products.Add(AddedProduct);
            else
            {
                Console.WriteLine("Продукт не помещается!");
                AddProduct();
            }

        }

        public void PrintProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine("Id:" + product.Id +
                    "\nНазвание:" + product.Name + 
                    "\nКоличество:" + product.Quantity + 
                    "\nРазмер:" + product.Capacity +
                    "\nЦена:" + product.Price);
            }
        }

        public void RemoveProduct()
        {
            PrintProducts();
            _products.Remove(FindProduct());
        }
    }
}
