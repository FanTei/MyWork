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

        public string PathAndQuery => "Store";

        public void Run(JObject content)
        {
            Showcase showcase = new Showcase() { Name = (string)content["Name"], Size = (int)content["Size"] };
            _store.Showcases.Add(showcase.Id, showcase);
        }
    }
}
