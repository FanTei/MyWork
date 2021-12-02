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
    class EditShowcaseHandler : IHandaler
    {
        private Store _store;

        public EditShowcaseHandler(Store store)
        {
            _store = store;
        }
        public HttpMethod HttpMethod => HttpMethod.Put;

        public string PathAndQuery => "/Store";

        public void Run(JObject content)
        {
            var newName = (string)content["NewName"];
            var newSize = (int)content["NewSize"];
            var name = (string)content["Name"];
            var editShowcase = _store.Showcases.FirstOrDefault(x => x.Value.Name == name).Value;
            editShowcase.Name = newName;
            editShowcase.Size = newSize;
            }
        }
    }
}
