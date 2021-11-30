using System;
using System.Collections.Generic;

namespace Shop.Server.Models
{
    public class Showcase
    {
        public Showcase()
        {
            Products = new List<Product>();
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            DeletedDate = DateTime.MinValue;
        }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public List<Product> Products { get; private set; }

    }
}

