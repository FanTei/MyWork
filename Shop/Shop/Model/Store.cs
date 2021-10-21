using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    class Store : IShop
    {
        private List<Showcase> _showcases;
        public Store()
        {
            _showcases = new List<Showcase>();
        }
        public void AddShowcase()
        {
            Console.WriteLine("Введите ID витрины:");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите название:");
            string Name = Console.ReadLine();
            Console.WriteLine("Введите размер витрины:");
            int Size = int.Parse(Console.ReadLine());
            var AddedShowcase = new Showcase(Id, Name, Size);
            _showcases.Add(AddedShowcase);
        }
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("1-добавить");
                Console.WriteLine("2-показать");
                Console.WriteLine("3-удалить");
                Console.WriteLine("4-меню с митринами");
                string input = Console.ReadLine();
                if (input == "1")
                    AddShowcase();
                if (input == "2")
                    PrintShowcases();
                if (input == "3")
                    RemoveShowcase();
                if (input == "4")
                {
                    PrintShowcases();
                    Console.WriteLine("Введите Id");
                    int id = int.Parse(Console.ReadLine());
                    Showcase Useshowcase =new Showcase();
                    foreach (var showcase in _showcases)
                    {
                        if (showcase.Id == id)
                        {
                            Useshowcase = showcase;
                        }
                        Useshowcase.Use();
                    }
                    

                }
            }
        }
        public void EditShowcase()
        {
            
        }

        public void PrintShowcases()
        {
            foreach (var showcase in _showcases)
            {
                Console.WriteLine(showcase.Id +") " + showcase.Name + " " +showcase.Size + " "+ showcase.CreateTime);
            }
        }

        public void RemoveShowcase()
        {
            PrintShowcases();
            Console.WriteLine("Введите Id витрины: ");
            int Id = int.Parse(Console.ReadLine());
            foreach (var showcase in _showcases)
            {
                if (showcase.Id == Id)
                {
                    _showcases.Remove(showcase);
                    return;
                }
            }
        }
    }
}
