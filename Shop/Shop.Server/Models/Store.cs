using System;
using System.Collections.Generic;

namespace Shop.Server.Models
{
    public class Store
    {
        public Store()
        {
            Showcases = new Dictionary<Guid, Showcase>();
            Products = new Dictionary<Guid, Product>();
        }

        public Dictionary<Guid, Showcase> Showcases;
        public Dictionary<Guid, Product> Products;
    }
}
