using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    class Cell
    {
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

        public virtual Images Image
        {
            get
            {
                return _image;
            }
        }

        #endregion

        #region ---===   Abstract?   ===---

        public virtual void Process()
        {
            throw new Exception();
        }

        #endregion

        #endregion

        public override string ToString()
        {
            return ((char)_image).ToString();
        }






    }
}
