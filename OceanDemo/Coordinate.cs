using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
#pragma warning disable CS0659, CS0660, CS0661 
    class Coordinate
#pragma warning restore CS0659, CS0660 , CS0661

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

        public Coordinate()
            : this(0, 0)
        {

        }

        public Coordinate(Coordinate cord)
            : this(cord._x, cord._y)
        {

        }

        #endregion

        #region ---===   Override Operator   ===---

        public static bool operator ==(Coordinate cord1, Coordinate cord2)
        {
            return ((cord1.X == cord2.X) && (cord1.Y == cord2.Y));
        }

        public static bool operator !=(Coordinate cord1, Coordinate cord2)
        {
            return !(cord1 == cord2);
        }

        #endregion

    }
}
