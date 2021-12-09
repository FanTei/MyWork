using Newtonsoft.Json.Linq;
using Shop.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Server.Handlers
{
    class CreateProductHandler : IHandaler
    {
        private Store _store;

        public CreateProductHandler(Store store)
        {
            _store = store;
        }
        public string PathAndQuery => "/Product";

        public void Run(JObject content)
        {
            var product = new Product()
            {
                Name = (string)content["Name"],
                Capacity = (int)content["Capacity"],
                Quantity = (int)content["Quantity"],
                Price = (double)content["Price"]
            };
            _store.Products.Add(product.Id, product);
        }
    }
}
