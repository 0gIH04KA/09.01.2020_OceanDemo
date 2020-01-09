using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Ocean ocean = new Ocean(10, 25, 250, -10, 10, 10);
            ocean.InitCells();


            Console.ReadKey();

        }

    }
}
