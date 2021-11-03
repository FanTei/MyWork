using System;
using System.Collections.Generic;

namespace Shop.CLI.Models
{
    public class Showcase
    {
        public Showcase()
        {
            Products = new List<Product>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public List<Product> Products { get; private set; }

    }
}
