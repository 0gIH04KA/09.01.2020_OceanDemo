using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    class Prey : Cell
    {
        #region ---===   Protected   ===---

        protected readonly int _initTimeToReproduce;
        protected int _timeToReproduce;
       
        #endregion

        #region ---===   Get / Set   ===---

        public int TimeToReproduce
        {
            get 
            {
                return _timeToReproduce;
            }
            set 
            {
                if (value <= 0 || value > Constant.TimeToReproduce)
                {
                    _timeToReproduce = Constant.TimeToReproduce;

                    return;
                }

                _timeToReproduce = value;
            }
        }

        #endregion

        #region ---===   Constructors   ===---

        public Prey(Coordinate aCoord, Ocean ocean = null, int timeToReproduce = Constant.TIME_TO_REPRODUCE)
            : base(aCoord, ocean)
        {
            TimeToReproduce = timeToReproduce;
            _initTimeToReproduce = _timeToReproduce;

            _image = Images.Prey;
        }

        public Prey(Prey source)
            : this(source._offset, source._ocean, source._initTimeToReproduce)
        {

        }

        #endregion

        #region ---===   Methods   ===---

            #region ---===   Virtual   ===---

            public virtual Cell Reproduce(Coordinate anOffset)
            {
                Prey temp = new Prey(anOffset, _ocean);

                return temp;
            }

            #endregion

            #region ---===   Override Method   ===---

            public override Images Image
            {
                get
                {
                    return _image;
                }
            }

            public override void Process()
            {
                --_timeToReproduce;

                Coordinate[] arrCoord = _ocean.GetNeighborsEmpty(_offset);
                Coordinate toCoord = arrCoord[_random.Next(0, arrCoord.Length - 1)];

                if (toCoord != _offset)
                {
                    _ocean.MoveFrom(_offset, toCoord);

                    if (_timeToReproduce <= 0)
                    {
                        _timeToReproduce = _initTimeToReproduce;
                        _ocean.AddCell(Reproduce(_offset));
                    }

                    _offset = toCoord;
                }
            }

            public override string ToString()
            {
                return ((char)Image).ToString();
            }

            public override Cell GetClone()
            {
                return new Prey(this);
            }

            public override object Clone()
            {
                return new Prey(this);
            }

        #endregion

        #endregion

    }
}
