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
    class FirstMenu
    {
        ProductMenu _productMenu;
        ShowcaseMenu _showcaseMenu;
        public FirstMenu()
        {
            var httpClient = new HttpClient();
            _productMenu = new ProductMenu(httpClient);
            _showcaseMenu = new ShowcaseMenu(httpClient);
        }
        public void Menu()
        {
            Console.WriteLine("1)Для работы с витринами");
            Console.WriteLine("2)Для работы с продуктами");
            var operation = Console.ReadKey();
            Console.Clear();
            switch (operation.Key)
            {
                case ConsoleKey.D1:
                    _showcaseMenu.Menu();
                    break;
                case ConsoleKey.D2:
                    _productMenu.Menu();
                    break;
                default:
                    Console.WriteLine("Такой операции не существует");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }

     
    }
}
