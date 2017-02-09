using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sberbank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            string number  = Console.ReadLine();
            string [] INN = number.Split(' ');
            foreach (string arg in INN)
                list.Add(Int32.Parse(arg));
        }
    }
}
