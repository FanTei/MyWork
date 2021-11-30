using Shop.Server.Handlers;
using Shop.Server.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Shop.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:21857/");
            httpListener.Start();
            while (true)
            {
                var requestContext = httpListener.GetContext();
                var request = requestContext.Request;
                var responseValue = "";
                if (request.Url.PathAndQuery == "/Store")
                {
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            requestContext.Response.StatusCode = 200;
                            var showcases = new ListShowcasesHandler(store).Run();
                            responseValue = JsonConvert.SerializeObject(showcases, Formatting.Indented);
                            break;
                        case "POST":
                            requestContext.Response.StatusCode = 200;
                            responseValue = "Продукт добавлен";
                            new CreateShowcaseHandler(store).Run();
                            break;
                        default:
                            break;
                    }
                    var stream = requestContext.Response.OutputStream;
                    var bytes = Encoding.UTF8.GetBytes(responseValue);
                    stream.Write(bytes, 0, bytes.Length);
                    requestContext.Response.Close();
                }
            }
        }
    }
}
