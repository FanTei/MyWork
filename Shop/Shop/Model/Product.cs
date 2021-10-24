using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    class Product : IProduct
    {
        public int? Id { get ; set ; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double Price { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime DeliteTime { get; set; }

        public Product() { }

        public Product(int id,string name,int capacity,double price,int quantity)
        {
            Quantity = quantity;
            Id = id;
            Name = name;
            Capacity = capacity;
            Price = price;
            CreateTime = DateTime.Now;
            DeliteTime = DateTime.MinValue;
        }
    }                           
}
