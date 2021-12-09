using Newtonsoft.Json;
using Shop.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Client
{
    class ShowcaseMenu
    {
        private string _adress = "http://localhost:21857/Store";
        private HttpClient _httpClient;

        public ShowcaseMenu(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private void Print()
        {
            Console.WriteLine("1)Создать новую витрину");
            Console.WriteLine("2)Показать витрины");
            Console.WriteLine("3)Редактировать витрину");
            Console.WriteLine("4)Удалить витрину");
        }

        public void Menu()
        {
            Print();
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

        private void AddNewShowcase()
        {
            ShowcaseModel showcase = new ShowcaseModel();
            var name = Input.Name();
            showcase.Name = name;
            var size = Input.Size();
            showcase.Size = size;
            var jsonContent = JsonConvert.SerializeObject(showcase, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(_adress, httpContent).Result;
            var content = response.Content.ReadAsStringAsync().Result;
        }

        private void PrintShowcases()
        {
            var response = _httpClient.GetAsync(_adress).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private void DeleteShowcase()
        {
            var deleteShowcase = new ShowcaseModel();
            var name = Input.Name();
            deleteShowcase.Name = name;
            var jsonContent = JsonConvert.SerializeObject(deleteShowcase, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = _httpClient.PatchAsync(_adress, httpContent).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private void EditShowcase()
        {
            var showcase = new EditShowcaseModel();
            var name = Input.Name();
            Console.WriteLine("Введите новое название витрины");
            var newName = Console.ReadLine();
            Console.WriteLine("Введите новый размер витрины");
            var newSize = int.Parse(Console.ReadLine());
            showcase.Name = name;
            showcase.NewSize = newSize;
            showcase.NewName = newName;
            var jsonContent = JsonConvert.SerializeObject(showcase, Formatting.Indented);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = _httpClient.PutAsync(_adress, httpContent).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }
    }
}
