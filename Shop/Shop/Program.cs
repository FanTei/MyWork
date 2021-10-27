using System;
using Shop.Model;
namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            Store store = new Store();
            while(true)
            {
                Application.StoreMenu(store);
            }
        }
    }
}
