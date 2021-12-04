using System;
using System.Net.Http;

namespace Shop.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            while (true)
            {
                menu.StoreMenu();
            }
        }
    }
}
