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

        public HttpMethod HttpMethod => HttpMethod.Post;

        public string PathAndQuery => "/Product";

        public void Run(JObject content)
        {
            var name = (string)content["Name"];
            var capacity = (int)content["Capacity"];
            var quantity = (int)content["Quantity"];
            var price = (double)content["Price"];
            var product = new Product();
            product.Name = name;
            product.Capacity = capacity;
            product.Quantity = quantity;
            product.Price = price;
            _store.Products.Add(product.Id, product);
        }
    }
}
