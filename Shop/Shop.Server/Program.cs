using Shop.Server.Handlers;
using Shop.Server.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Shop.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            var interaction = new Interaction(store);
            interaction.Install("http://localhost:21857/");
            while (true)
                interaction.Work();
            
        }
    }
}
