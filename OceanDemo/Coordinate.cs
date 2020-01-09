using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    class Coordinate
    {
        #region ---===   Private   ===--- 

        private int _x; 
        private int _y;

        #endregion

        #region ---===   Get / Set   ===---

        public int X
        {
            get 
            { 
                return _x;
            }
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Coordinate X < 0");
                }

                _x = value;
            }
        }

        public int Y
        {
            get 
            { 
                return _y;
            }
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Coordinate Y < 0");
                }

                _y = value;
            }
        }

        #endregion

        #region ---===   Constructors   ===---

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate(Coordinate cord)
            : this(cord._x, cord._y)
        {

        }

        #endregion
    }
}
