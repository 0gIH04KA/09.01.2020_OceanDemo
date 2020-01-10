using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    class Cell
    {
        public static Random _random;

        #region ---===   Protected   ===---

        protected readonly Ocean _ocean;

        protected Coordinate _offset;
        protected Images _image = Images.Empty;

        #endregion

        #region ---===   Get / Set   ===---

        public Coordinate Offset
        {
            get 
            { 
                return _offset;
            }
            set 
            { 
                _offset = value;
            }
        }

        #endregion

        #region ---===   Constructors   ===---

        public Cell(Coordinate coord)
        {
            if (_random == null)
            {
                _random = new Random();
            }

            _offset = coord;
        }

        public Cell(Coordinate coord, Ocean ocean)
           : this(coord)
        {
            _ocean = ocean;
        }

        public Cell(Cell source)
            : this(source._offset, source._ocean)
        {
        }

        #endregion

        #region ---===   Methods   ===---

            #region ---===   Virtual   ===---

            public virtual void Process()
            {
                throw new Exception("Class Cell !!");
            }

            public virtual Images Image
            {
                get
                {
                    return _image;
                }
            }

            public virtual Cell GetClone()
            {
                return new Cell(this);
            }

            public virtual object Clone()
            {
                return new Cell(this);
            }

            #endregion

            #region ---===   Override Method   ===---

            public override string ToString()
            {
                return ((char)_image).ToString();
            }

            #endregion

        #endregion

    }
}
