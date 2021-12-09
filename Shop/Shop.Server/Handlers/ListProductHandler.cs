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
    class ListProductHandler
    {
        private Store _store;

        public ListProductHandler(Store store)
        {
            _store = store;
        }

        public string PathAndQuery => "/Product";

        public Dictionary<Guid, Product> Run()
        {
            return _store.Products;
        }

    }
}
