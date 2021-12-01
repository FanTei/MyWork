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
    class CreateShowcaseHandler : IHandaler
    {
        private Store _store;

        public CreateShowcaseHandler(Store store)
        {
            _store = store;
        }
        public HttpMethod HttpMethod => HttpMethod.Get;

        public string PathAndQuery => "Store";

        public void Run(JObject content)
        {
            var name = (string)content["Name"];
            var size = (int)content["Size"];
            Showcase showcase = new Showcase();
            showcase.Name = name;
            showcase.Size = size;
            _store.Showcases.Add(showcase.Id, showcase);
        }
    }
}
