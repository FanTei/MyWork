using System;

namespace Shop.CLI.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public int Quantity { get; set; }


        public int Capacity { get; set; }

        public double Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}
