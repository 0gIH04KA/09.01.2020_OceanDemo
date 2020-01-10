using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    class Predator : Prey
    {
        #region ---===   Protected   ===---

        protected readonly int _initTimeToEat;
        protected int _timeToEat;

        #endregion

        #region ---===   Get / Set   ===---

        public int TimeToEat
        {
            get
            {
                return _timeToEat;
            }
            set
            {
                if (value <= 0 || value > Constant.TimeToEat)
                {
                    _timeToEat = Constant.TimeToEat;

                    return;
                }

                _timeToEat = value;
            }
        }

        #endregion

        #region ---===   Constructors   ===---

        public Predator(Coordinate coord, Ocean ocean = null,
            int timeToReproduce = Constant.TIME_TO_REPRODUCE,
            int timeToEat = Constant.TIME_TO_EAT)
           : base(coord, ocean, timeToReproduce)
        {
            TimeToEat = timeToEat;
            _initTimeToEat = _timeToEat;

            _image = Images.Predators;
        }

        public Predator(Predator source)
            : this(source._offset, source._ocean, 
                source._timeToReproduce, source._timeToEat)
        {

        }

        #endregion

        #region ---===   Methods   ===---

            #region ---===    Override Method   ===---

        public override Images Image
        {
            get
            {
                return _image;
            }
        }

        public override void Process()
        {
            if (--_timeToEat > 0)
            {
                Coordinate[] arrCoord = _ocean.GetNeighborsWithImage(_offset, Images.Prey);
                Coordinate toCoord = arrCoord[_random.Next(0, arrCoord.Length - 1)];

                if (toCoord != _offset) 
                {
                    _ocean.MoveFrom(_offset, toCoord); 
                    _offset = toCoord;               
                    _timeToEat = _initTimeToEat;    
                }
                else
                {
                    base.Process();
                }
            }
            else
            {
                _ocean[_offset] = null;     //death
            }
        }

        public override Cell Reproduce(Coordinate anOffset)
        {
            Predator temp = new Predator(anOffset, _ocean); 

            return temp;
        }

        public override string ToString()
        {
            return ((char)Image).ToString();
        }

        public override Cell GetClone()
        {
            return new Predator(this);
        }

        #endregion

        #endregion

    }
}
