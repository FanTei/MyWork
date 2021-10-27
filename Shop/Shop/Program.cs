using System;
using Shop.Model;
namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            Application.StoreMenu(store);
        }
    }
}
