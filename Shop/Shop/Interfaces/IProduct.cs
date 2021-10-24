using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    interface IProduct
    {
        int? Id { get; set; }

        string Name { get; set; }

        int Capacity { get; set; }

        double Price { get; set; }

        public int Quantity { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime DeliteTime { get; set; }

    }
}
