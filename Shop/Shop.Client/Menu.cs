using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shop.Client.Models;

namespace Shop.Client
{
    class Menu
    {
        public void StoreMenu()
        {
            Console.WriteLine("1)Для работы с витринами");
            Console.WriteLine("2)Для работы с продуктами");
            var operation = Console.ReadKey();
            switch (operation.Key)
            {
                case ConsoleKey.D1:
                    ShowcaseMenu();
                    break;
                case ConsoleKey.D2:
                    ProductMenu();
                    break;
                default:
                    Console.WriteLine("Такой операции не существует");
                    break;
            }
        }

        public void ShowcaseMenu()
        {
            Console.WriteLine("1)Создать новую витрину");
            Console.WriteLine("2)Показать витрины");
            Console.WriteLine("3)Редактировать витрину");
            Console.WriteLine("4)Удалить витрину");
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
                default:
                    Console.WriteLine("Такой операции не существует");
                    break;
            }
        }

        public void ProductMenu()
        {
            Console.WriteLine("1)Создать продукт");
            Console.WriteLine("2)Показать продукты");
            Console.WriteLine("3)Удалить товар");
            Console.WriteLine("4)Редактировать продукт");
            var operation = Console.ReadKey();
            switch (operation.Key)
            {
                case ConsoleKey.D1:
                    AddNewProduct();
                    break;
                case ConsoleKey.D2:
                    PrintProducts();
                    break;
                case ConsoleKey.D3:
                    DeleteProduct();
                    break;
                case ConsoleKey.D4:
                    EditProduct();
                    break;
                default:
                    Console.WriteLine("Такой операции не существует");
                    break;
            }
        }

        private void AddNewShowcase()
        {
            var httpClient = new HttpClient();
            ShowcaseModel showcase = new ShowcaseModel();
            var name = Input.Name();
            showcase.Name = name;
            var size = Input.Size();
            showcase.Size = size;
            var jsonContent = JsonConvert.SerializeObject(showcase, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("http://localhost:21857/Store",httpContent).Result;
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
            var name = Input.Name();
            deleteShowcase.Name = name;
            var jsonContent = JsonConvert.SerializeObject(deleteShowcase, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = httpClinet.PatchAsync("http://localhost:21857/Store",httpContent).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private void EditShowcase()
        {
            var httpClient = new HttpClient();
            var showcase = new EditShowcaseModel();
            var name = Input.Name();
            Console.WriteLine("Введите новое название витрины");
            var newName =Console.ReadLine();
            Console.WriteLine("Введите новый размер витрины");
            var newSize = int.Parse(Console.ReadLine());
            showcase.Name = name;
            showcase.NewSize = newSize;
            showcase.NewName = newName;
            var jsonContent = JsonConvert.SerializeObject(showcase, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync("http://localhost:21857/Store", httpContent).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private void AddNewProduct()
        {
            var httpClient = new HttpClient();
            var productModel = new ProductModel();
            var name = Input.Name();
            var capacity = Input.Capacity();
            var quantity = Input.Quanity();
            var price = Input.Price();
            productModel.Name = name;
            productModel.Capacity = capacity;
            productModel.Quantity = quantity;
            productModel.Price = price;
            var jsonContent = JsonConvert.SerializeObject(productModel, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("http://localhost:21857/Product", httpContent).Result;
        }

        private void PrintProducts()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:21857/Product").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private void DeleteProduct()
        {
            var httpclient = new HttpClient();
            var name = Input.Name();
            var deleteProduct = new ProductModel();
            deleteProduct.Name = name;
            var jsonContent = JsonConvert.SerializeObject(deleteProduct, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = httpclient.PatchAsync("http://localhost:21857/Product",httpContent).Result;
        }

        private void EditProduct()
        {
            var httpclient = new HttpClient();
            Console.WriteLine("Введите название продукта");
            var name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("РЕДАКТИРОВАНИЕ:");
            var editProduct = new EditProductModel();
            var newName = Input.Name();
            var newCapacity = Input.Capacity();
            var newQuantity = Input.Quanity();
            var newPrice = Input.Price();
            editProduct.Name = name;
            editProduct.NewName= newName;
            editProduct.NewCapacity = newCapacity;
            editProduct.NewQuantity = newQuantity;
            editProduct.NewPrice = newPrice;
            var jsonContent = JsonConvert.SerializeObject(editProduct, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = httpclient.PutAsync("http://localhost:21857/Product", httpContent).Result;
        }
    }
}
