using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
   public static class Application
    {
       static public int InputID()
        {
            int number;
            Console.WriteLine("Введите ID");
            var input = Console.ReadLine();
            while(int.TryParse(input,out number))
            {
                Console.WriteLine("Введите коректый ID");
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }
      static public string InputName()
        {
            Console.WriteLine("Введите название");
            return Console.ReadLine();
        }
      static public string InputSize()
        {

        }
    }
}
