using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OceanDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            OceanUI oceanUI = new OceanUI();
            Ocean ocean = OceanTest.CreateOcean(20, 20, 20, 20, 10, 100);

            while (ocean.Run())
            {
                oceanUI.DisplayCells(ocean);
               


                Thread.Sleep(2000);
            }

            Console.ReadKey();
        }
    }
}
