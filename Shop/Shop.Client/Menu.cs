using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Client
{
    class Menu
    {
        public void FirstMenu()
        {
           
            Console.WriteLine("1)Создать новую витрину");
            Console.WriteLine("2)Показать витрины");
            Console.WriteLine("3)Удалить витрины");
            Console.WriteLine("4)Создать новый товар");
            Console.WriteLine("5)Удалить продукт");
            Console.WriteLine("1)Разметить товар на витрине");
            Console.WriteLine("8)Удалить товар с витрины");
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
                    DeleteShowcase();
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.D7:
                    break;
                case ConsoleKey.D8:
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
            var response = httpclient.PostAsync("http://localhost:21857/Store",null).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
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
            var response = httpClinet.DeleteAsync("http://localhost:21857/Store").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

    }
}
