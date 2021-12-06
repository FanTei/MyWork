using System;
using System.Net.Http;

namespace Shop.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstMenu menu = new FirstMenu();
            while (true)
            {
                menu.Menu();
            }
        }
    }
}
