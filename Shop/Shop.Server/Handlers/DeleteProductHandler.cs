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
    class DeleteProductHandler : IHandaler
    {
        private Store _store;

        public DeleteProductHandler(Store store)
        {
            _store = store;
        }
        public HttpMethod HttpMethod => HttpMethod.Patch;

        public string PathAndQuery => "/Product";

        public void Run(JObject content)
        {
            var name = (string)content["Name"];
            Product removeProduct;
            foreach(var product in _store.Products)
            {
                if(product.Value.Name == name)
                {
                    removeProduct = product.Value;
                    _store.Products.Remove(product.Key, out removeProduct);
                }
            }
        }
    }
}
