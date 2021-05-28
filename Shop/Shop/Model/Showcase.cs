using Shop.Interafaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    class Showcase
    {
        List<Showcase> showcases = new List<Showcase>();
        private int _count =1;
        public int ID { get; set; }
        public string Title { get ; set; }
        public int Size { get;set ; }
        public DateTime CreateTime { get; set ;}
        public DateTime DaliteTime { get ; set;}
        public List<Product> products { get; set; }
        public int ProductID { get; set; }
        public Showcase() {}
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
        private Showcase FindShowcase(int id)
        {
            Showcase showcase = new Showcase();
            foreach (var item in showcases)
            {
                if (item.ID == id)
                {
                    showcase = item;
                    return showcase;
                }
            }
            return showcase;
        }
        private int Validate(string input)
        {
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
                var input = Console.ReadLine();
                id = Validate(input);
                CheckProductID(id);
            }
        }
        public void CheckId(int id)
        {
            if (id > _count-1)
            {
                Console.WriteLine("Такого ID не существует,введите другой ID");
                var input = Console.ReadLine();
                id = Validate(input);
                CheckId(id);
            }
        }
        public List<Showcase> ReturnListShowcases() { return showcases; }

        public void Add(string title,int size)
        {
            Showcase showcase = new Showcase(title,size);
            _count++;
            showcases.Add(showcase);
        }

        public void Print()
        {
            foreach(var x in showcases)
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
             showcases.Remove(showcase);
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
