using Newtonsoft.Json;
using Shop.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Client
{
    class ProductMenu
    {
        private string _address = "http://localhost:21857/Product";
        private HttpClient _httpClient;

        public ProductMenu(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private void Print()
        {
            Console.WriteLine("1)Создать продукт");
            Console.WriteLine("2)Показать продукты");
            Console.WriteLine("3)Удалить товар");
            Console.WriteLine("4)Редактировать продукт");
        }

        public void Menu()
        {
            Print();
            var operation = Console.ReadKey();
            switch (operation.Key)
            {
                case ConsoleKey.D1:
                    var name = Input.Name();
                    var capacity = Input.Capacity();
                    var quantity = Input.Quanity();
                    var price = Input.Price();
                    AddNewProduct(name, capacity, quantity, price);
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

        private void AddNewProduct(string name, int capacity, int quantity, double price)
        {
            var productModel = new ProductModel() 
            {
                Name = name, 
                Capacity = capacity, 
                Quantity = quantity, 
                Price = price 
            };
            var jsonContent = JsonConvert.SerializeObject(productModel, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(_address, httpContent).Result;
        }

        private void PrintProducts()
        {
            var response = _httpClient.GetAsync(_address).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private void DeleteProduct()
        {
            var name = Input.Name();
            var deleteProduct = new ProductModel();
            deleteProduct.Name = name;
            var jsonContent = JsonConvert.SerializeObject(deleteProduct, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = _httpClient.PatchAsync(_address, httpContent).Result;
        }

        private void EditProduct()
        { 
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
            editProduct.NewName = newName;
            editProduct.NewCapacity = newCapacity;
            editProduct.NewQuantity = newQuantity;
            editProduct.NewPrice = newPrice;
            var jsonContent = JsonConvert.SerializeObject(editProduct, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = _httpClient.PutAsync(_address, httpContent).Result;
        }
    }
}
