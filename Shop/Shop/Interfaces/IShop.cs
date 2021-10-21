using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    interface IShop
    {
        public void PrintShowcases();

        public void EditShowcase();

        public void RemoveShowcase();

        public void AddShowcase();
    }
}
