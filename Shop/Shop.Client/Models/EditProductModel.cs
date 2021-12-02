using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Client.Models
{
    class EditProductModel
    {
        public string Name { get; set; }

        public string NewName { get; set; }

        public int NewQuantity { get; set; }

        public int NewCapacity { get; set; }

        public double NewPrice { get; set; }
    }
}
