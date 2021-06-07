
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    class Showcase
    {
        Market _market;
        private int _count =1;
        public int ID { get; set; }
        public string Title { get ; set; }
        public int Size { get;set ; }
        public DateTime CreateTime { get; set ;}
        public DateTime DaliteTime { get ; set;}
        public List<Product> products { get; set; }
        public int ProductID { get; set; }
        private List<Showcase> _showcases;
        public Showcase(Market market) 
        {
            _market = market;
            _showcases = _market.GetShowcases();
        }
        public Showcase(string title,int size)
        {
            
            ProductID = 1;
            products = new List<Product>();
            CreateTime = DateTime.Now;
            DaliteTime = DateTime.MinValue;
            ID = _count;
            Size = size;
            Title = title;
        }
        public Product FindShowCaseItem(Showcase showcase, int productId)
        {
            var product = new Product(_market);
            foreach (var item in showcase.products)
            {
                if (item.ID == productId)
                    product = item;
            }
            return product;
        }
        public Showcase FindShowcase(int id)
        {
            Showcase showcase = new Showcase(_market);
            foreach (var item in _showcases)
            {
                if (item.ID == id)
                {
                    showcase = item;
                    return showcase;
                }
            }
            return showcase;
        }
        private int Validate()
        {
            var input = Console.ReadLine();
            var num = 0;
            var x = int.TryParse(input, out num);
            while (!int.TryParse(input, out num))
            {
                Console.Write("Введите целое число больше нуля:");
                input = Console.ReadLine();  
            }
            return int.Parse(input);
        }
        public void CheckProductID(int id)
        {
            if (id > ProductID - 1)
            {
                Console.WriteLine("Такого ID не существует,введите другой ID");
                id = Validate();
                CheckProductID(id);
            }
        }
        public void CheckId(int id)
        {
            if (id > _count-1)
            {
                Console.WriteLine("Такого ID не существует,введите другой ID");
                id = Validate();
                CheckId(id);
            }
        }

        public void Add(string title,int size)
        {
            Showcase showcase = new Showcase(title,size);
            _count++;
            _showcases.Add(showcase);
        }           

        public void Print()
        {
            foreach(var x in _showcases)
            {
                Console.WriteLine(x.ID+")"+"Title:"+x.Title+" Size:"+x.Size);
            }
        }

        public void Remove(int id)
        {
            var showcase = FindShowcase(id);
            //если на втирине продукт id!=1 то выйти из метода
            //if (thisShowcase.ProductID != 1)
            //    Interect();
             _showcases.Remove(showcase);
             showcase.DaliteTime = DateTime.Now;
             _count--;
        }

        public void EditTitle(int id,string title)
        {
            var showcase = FindShowcase(id);
            showcase.Title = title;
        }

        public void EditSize(int id,int size)
        {
            var showcase = FindShowcase(id);
            showcase.Size = size;
        }

        public int SumProductCapacity()
        {
            var sum = 0;
            foreach (var item in products)
                sum += item.Capacity * item.Count;
            return sum;
        }
    }
}
