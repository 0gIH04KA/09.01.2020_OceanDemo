using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    class OceanUI
    {
        public void DisplayCells(Ocean ocean)
        {
            Clean(ocean);
            Console.CursorVisible = false;

            for (ushort i = 0; i < ocean.NumRows; i++)
            {
                for (ushort j = 0; j < ocean.NumCols; j++)
                {
                    if (ocean[i, j] != null)
                    {
                        Console.SetCursorPosition(j, i);

                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write(ocean[i, j]);
                    }

                }
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        public void Clean(Ocean ocean)
        {
            for (ushort i = 0; i < ocean.NumRows; i++)
            {
                for (ushort j = 0; j < ocean.NumCols; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(' ');
                }
            }
        }

    }
}
