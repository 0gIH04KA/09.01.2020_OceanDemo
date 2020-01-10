using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    class Obstacle : Cell
    {
        #region ---===   Constructors   ===--- 

        public Obstacle(Coordinate coord, Ocean ocean = null)
           : base(coord, ocean)
        {
            _image = Images.Obstacle;
        }

        #endregion

        #region ---===   Override Methods   ===--- 

        public override Images Image
        {
            get
            {
                return _image;
            }
        }

        public override string ToString()
        {
            return ((char)_image).ToString();
        }

        public override Cell GetClone()
        {
            return new Obstacle(_offset, _ocean);
        }

        public override object Clone()
        {
            return new Obstacle(_offset, _ocean);
        }

        public override void Process()
        {
        }

        #endregion

    }
}
