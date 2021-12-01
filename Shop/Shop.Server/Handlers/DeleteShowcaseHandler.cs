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
    class DeleteShowcaseHandler : IHandaler
    {
        private Store _store;

        public DeleteShowcaseHandler(Store store)
        {
            _store = store;
        }
        public HttpMethod HttpMethod => HttpMethod.Patch;

        public string PathAndQuery => "/Store";

        public void Run(JObject content)
        {
            var name = (string)content["Name"];
            Showcase removeShowcase;
            foreach(var showcase in _store.Showcases)
            {
                if (showcase.Value.Name == name)
                {
                    removeShowcase = showcase.Value;
                    _store.Showcases.Remove(showcase.Key, out removeShowcase);
                }
            }
        }
    }
}
