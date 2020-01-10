using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    /// <summary>
    /// 
    /// Не ENUM но пусть остается в этой папке xD
    /// 
    /// </summary>
    class Constant
    {
        #region  ---===   Public Const   ===---

        public const int TIME_TO_REPRODUCE = 6;
        public const int TIME_TO_EAT = 6;

        #endregion

        #region ---===   Private   ===---

        private const int MAX_PREYS = 150;
        private const int MAX_PREDATORS = 20;
        private const int MAX_OBSTACLES = 75;

        private const int MAX_COLS = 70;
        private const int MAX_ROWS = 25;

        private const int MIN_ITERATIONS = 10;
        private const int MAX_ITERATIONS = 100;

        private const int NUM_DIRECTIONS = 4;

        #endregion

        #region ---===   Get / Set   ===---

        public static int MaxPreys
        {
            get
            {
                return MAX_PREYS;
            }
        }

        public static int MaxPredators
        {
            get
            {
                return MAX_PREDATORS;
            }
        }

        public static int MaxObstacle
        {
            get
            {
                return MAX_OBSTACLES;
            }
        }

        public static int MaxCols
        {
            get
            {
                return MAX_COLS;
            }
        }

        public static int MaxRows
        {
            get
            {
                return MAX_ROWS;
            }
        }

        public static int TimeToReproduce
        {
            get
            {
                return TIME_TO_REPRODUCE;
            }
        }

        public static int TimeToEat
        {
            get
            {
                return TIME_TO_EAT;
            }
        }

        public static int MinIteration
        {
            get
            {
                return MIN_ITERATIONS;
            }
        }

        public static int MaxIteration
        {
            get
            {
                return MAX_ITERATIONS;
            }
        }

        public static int NumDirection
        {
            get
            {
                return NUM_DIRECTIONS;
            }
        }

        #endregion

    }
}
