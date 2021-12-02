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
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:21857/");
            httpListener.Start();
            while (true)
            {
                byte[] bytes;
                var requestContext = httpListener.GetContext();
                var request = requestContext.Request;
                var responseValue = "";
                var inStream = request.InputStream;
                bytes = new byte[request.ContentLength64];
                inStream.Read(bytes, 0, (int)request.ContentLength64);
                inStream.Close();
                var jsonContent = Encoding.UTF8.GetString(bytes);
                var content = (JObject)JsonConvert.DeserializeObject(jsonContent);
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
                            new CreateShowcaseHandler(store).Run(content);
                            responseValue = "Продукт добавлен";
                            break;
                        case "PUT":
                            requestContext.Response.StatusCode = 200;
                            new EditShowcaseHandler(store).Run(content);
                            break;
                        case "PATCH":
                            requestContext.Response.StatusCode = 200;
                            new DeleteShowcaseHandler(store).Run(content);
                            break;
                        default:
                            break;
                    }   
                }
                if (request.Url.PathAndQuery == "/Product")
                {
                    switch (request.HttpMethod)
                    {
                        case "POST":
                            requestContext.Response.StatusCode = 200;
                            new CreateProductHandler(store).Run(content);
                            break;
                        case "GET":
                            requestContext.Response.StatusCode = 200;
                            var products = new ListProductHandler(store).Run();
                            responseValue = JsonConvert.SerializeObject(products, Formatting.Indented);
                            break;
                        case "PATCH":
                            requestContext.Response.StatusCode = 200;
                            new DeleteProductHandler(store).Run(content);
                            break;
                        case "PUT":
                            requestContext.Response.StatusCode = 200;
                            new EditProductHandler(store).Run(content);
                            break;
                    }
                }
                var stream = requestContext.Response.OutputStream;
                bytes = Encoding.UTF8.GetBytes(responseValue);
                stream.Write(bytes, 0, bytes.Length);
                requestContext.Response.Close();
            }
        }
    }
}
