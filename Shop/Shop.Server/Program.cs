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
            Store store = new Store();
            Interaction interaction = new Interaction(store);
            interaction.Instal("http://localhost:21857/");
            while (true)
                interaction.Work();
            
        }
    }
}
