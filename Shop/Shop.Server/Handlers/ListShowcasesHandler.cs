using Shop.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Server.Handlers
{
    class ListShowcasesHandler 
    {
        private Store _store;
        public ListShowcasesHandler(Store store)
        {
            _store = store;
        }
        public HttpMethod HttpMethod => HttpMethod.Post;

        public string PathAndQuery => "/Store";

        public Dictionary<Guid, Showcase> Run()
        {
            return _store.Showcases;
        }
    }
}
