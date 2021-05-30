using System;
using Shop.Model;
namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market();
            while (true)
                market.Start();
        }
    }
}