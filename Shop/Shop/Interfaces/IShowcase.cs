using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    interface IShowcase
    {
        int Id { get; set; }

        string Name { get; set; }

        int Size { get; set; }

        DateTime CreateTime { get; set; }

        DateTime DeliteTime { get; set; }

        void PrintProducts();

        void AddProduct();

        void RemoveProduct();

    }

}
