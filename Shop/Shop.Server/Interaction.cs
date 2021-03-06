using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shop.Server.Handlers;
using Shop.Server.Models;
using System.Net;
using System.Text;


namespace Shop.Server
{
    class Interaction
    {
        private readonly Store _store;
        private HttpListener _httpListener;

        public Interaction(Store store)
        {
            _store = store;
            _httpListener = new HttpListener();
        }

        public void Install(string prefix)
        {
            _httpListener.Prefixes.Add(prefix);
            _httpListener.Start();
        }

        private string ShowcaseInteraction(HttpListenerContext requestContext,HttpListenerRequest request ,JObject content)
        {

            var responseValue = "";
            switch (request.HttpMethod)
            {
                case HttpMethod.GET:
                    requestContext.Response.StatusCode = 200;
                    var showcases = new ListShowcasesHandler(_store).Run();
                    responseValue = JsonConvert.SerializeObject(showcases, Formatting.Indented);
                    break;
                case HttpMethod.POST:
                    requestContext.Response.StatusCode = 200;
                    new CreateShowcaseHandler(_store).Run(content);
                    responseValue = "Витрина добавлена";
                    break;
                case HttpMethod.PUT:
                    requestContext.Response.StatusCode = 200;
                    new EditShowcaseHandler(_store).Run(content);
                    responseValue = "Витрина отредактирована";
                    break;
                case HttpMethod.PATCH:
                    requestContext.Response.StatusCode = 200;
                    new DeleteShowcaseHandler(_store).Run(content);
                    responseValue = " Витрина удалена";
                    break;
                default:
                    break;
            }
            return responseValue;
        }

        private string ProductInteraction(HttpListenerContext requestContext, HttpListenerRequest request, JObject content)
        {
            var responseValue = "";
            switch (request.HttpMethod)
            {
                case HttpMethod.POST:
                    requestContext.Response.StatusCode = 200;
                    new CreateProductHandler(_store).Run(content);
                    responseValue = "Продукт добавлен";
                    break;
                case HttpMethod.GET:
                    requestContext.Response.StatusCode = 200;
                    var products = new ListProductHandler(_store).Run();
                    responseValue = JsonConvert.SerializeObject(products, Formatting.Indented);
                    break;
                case HttpMethod.PATCH:
                    requestContext.Response.StatusCode = 200;
                    new DeleteProductHandler(_store).Run(content);
                    responseValue = "Продукт удален";
                    break;
                case HttpMethod.PUT:
                    requestContext.Response.StatusCode = 200;
                    new EditProductHandler(_store).Run(content);
                    responseValue = "Продукт отредактирован";
                    break;
            }
            return responseValue;
        }

        public void Work()
        {
            string responseValue="";
            byte[] bytes;
            var requestContext = _httpListener.GetContext();
            var request = requestContext.Request;
            var inStream = request.InputStream;
            bytes = new byte[request.ContentLength64];
            inStream.Read(bytes, 0, (int)request.ContentLength64);
            inStream.Close();
            var jsonContent = Encoding.UTF8.GetString(bytes);
            var content = (JObject)JsonConvert.DeserializeObject(jsonContent);
            if (request.Url.PathAndQuery == "/Store")
            {
                responseValue = ShowcaseInteraction(requestContext, request, content);
            }
            if (request.Url.PathAndQuery == "/Product")
            {
                responseValue = ProductInteraction(requestContext, request, content);
            }
            var stream = requestContext.Response.OutputStream;
            bytes = Encoding.UTF8.GetBytes(responseValue);
            stream.Write(bytes, 0, bytes.Length);
            requestContext.Response.Close();
        }
    }
}
