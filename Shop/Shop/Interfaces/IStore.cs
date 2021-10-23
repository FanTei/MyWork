using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    interface IStore
    {
        public void PrintShowcases();

        public void EditNameShowcase();

        public void EditSizeShowcase();

        public void EditIdShowcase();

        public void RemoveShowcase();

        public void AddShowcase();
    }
}
