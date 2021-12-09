using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Server.Handlers
{
    interface IHandaler
    {
        public string PathAndQuery { get;}

        public void Run(JObject content)
    }
}
