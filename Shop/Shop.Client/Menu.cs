using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Shop.Client
{
    class Menu
    {
        public void FirstMenu()
        {
           
            Console.WriteLine("1)Создать новую витрину");
            Console.WriteLine("2)Показать витрины");
            Console.WriteLine("3)Редактировать витрину");
            Console.WriteLine("4)Удалить витрину");
            Console.WriteLine("5)Создать продукт");
            Console.WriteLine("6)Показать продукты");
            Console.WriteLine("7)Удалить товар");
            var operation = Console.ReadKey();
            switch (operation.Key)
            {
                case ConsoleKey.D1:
                    AddNewShowcase();
                    break;
                case ConsoleKey.D2:
                    PrintShowcases();
                    break;
                case ConsoleKey.D3:
                    EditShowcase();
                    break;
                case ConsoleKey.D4:
                    DeleteShowcase();
                    break;
                case ConsoleKey.D5:
                    AddNewProduct();
                    break;
                case ConsoleKey.D6:
                    PrintProducts();
                    break;
                case ConsoleKey.D8:
                    EditProduct();
                    break;
                case ConsoleKey.D7:
                    DeleteProduct();
                    break;
                case ConsoleKey.D9:
                    break;
                default:
                    break;
            }
        }

        
        private void AddNewShowcase()
        {
            var httpclient = new HttpClient();
            ShowcaseModel showcase = new ShowcaseModel();
            Console.WriteLine("Введите название витрины:");
            var name = Console.ReadLine();
            showcase.Name = name;
            Console.WriteLine("Введите размер витрины");
            var size = int.Parse(Console.ReadLine());
            showcase.Size = size;
            var jsoncontent = JsonConvert.SerializeObject(showcase, Formatting.Indented);
            var httpcontent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            var response = httpclient.PostAsync("http://localhost:21857/Store",httpcontent).Result;
            var content = response.Content.ReadAsStringAsync().Result;
        }
        private void PrintShowcases()
        {
            var httpclient = new HttpClient();
            var response = httpclient.GetAsync("http://localhost:21857/Store").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }
        private void DeleteShowcase()
        {
            var httpClinet = new HttpClient();
            var deleteShowcase = new ShowcaseModel();
            Console.WriteLine("Введите название витрины");
            var name = Console.ReadLine();
            var jsoncontent = JsonConvert.SerializeObject(deleteShowcase, Formatting.Indented);
            var httpcontent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            var response = httpClinet.PatchAsync("http://localhost:21857/Store",httpcontent).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }
        private void EditShowcase()
        {
            var httpClient = new HttpClient();
            var showcase = new EditShowcaseModel();
            Console.WriteLine("Введите название витрины");
            var name = Console.ReadLine();
            Console.WriteLine("Введите новое название витрины");
            var newName =Console.ReadLine();
            Console.WriteLine("Введите новый размер витрины");
            var newSize = int.Parse(Console.ReadLine());
            showcase.Name = name;
            showcase.NewSize = newSize;
            showcase.NewName = newName;
            var jsoncontent = JsonConvert.SerializeObject(showcase, Formatting.Indented);
            var httpcontent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync("http://localhost:21857/Store", httpcontent).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private void AddNewProduct()
        {
            var httpClient = new HttpClient();
            var productModel = new ProductModel();
            Console.WriteLine("Введите название продукта");
            var name = Console.ReadLine();
            Console.WriteLine("Введите обьем продукта");
            var capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество продукта");
            var quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите цену продукта");
            var price = double.Parse(Console.ReadLine());
            productModel.Name = name;
            productModel.Capacity = capacity;
            productModel.Quantity = quantity;
            productModel.Price = price;
            var jsoncontent = JsonConvert.SerializeObject(productModel, Formatting.Indented);
            var httpcontent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("http://localhost:21857/Product", httpcontent).Result;
        }

        private void PrintProducts()
        {
            var httpclient = new HttpClient();
            var response = httpclient.GetAsync("http://localhost:21857/Product").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private void DeleteProduct()
        {
            var httpclient = new HttpClient();
            Console.WriteLine("Введите название продукта");
            var name = Console.ReadLine();
            var deleteProduct = new ProductModel();
            deleteProduct.Name = name;
            var jsoncontent = JsonConvert.SerializeObject(deleteProduct, Formatting.Indented);
            var httpContent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            var response = httpclient.PatchAsync("http://localhost:21857/Product",httpContent).Result;
        }

        private void EditProduct()
        {
            var httpclient = new HttpClient();
            Console.WriteLine("Введите название продукта");
            var name = Console.ReadLine();
            var editProduct = new ProductModel();

        }

    }
}
