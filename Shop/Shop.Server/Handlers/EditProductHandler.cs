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
    class EditProductHandler : IHandaler
    {
        private Store _store;

        public EditProductHandler(Store store)
        {
            _store = store;
        }

        public string PathAndQuery => "/Product";

        public void Run(JObject content)
        {
            var name = (string)content["Name"];
            var editProduct = _store.Products.FirstOrDefault(x => x.Value.Name == name).Value;
            var newName = (string)content["NewName"];
            var newQuantity = (int)content["NewQuantity"];
            var newCapacity = (int)content["NewCapacity"];
            var newPrice = (double)content["NewPrice"];           
            editProduct.Name = newName;
            editProduct.Capacity = newQuantity;
            editProduct.Quantity = newQuantity;
            editProduct.Price = newPrice;
        }


    }
}
