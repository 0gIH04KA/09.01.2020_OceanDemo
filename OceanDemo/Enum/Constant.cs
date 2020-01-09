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
        public const int MAX_PREYS = 150;
        public const int MAX_PREDATORS = 20;
        public const int MAX_OBSTACLES = 75;
       
        public const int MAX_COLS = 70;
        public const int MAX_ROWS = 25;

        #region MyRegion

        public const int TIME_TO_REPRODUCE = 6;
        public const int TIME_TO_EAT = 6;

        #endregion

        public const int MAX_NEIHGB_COUNT = 4;
        

        public const int MAX_ITERATIONS = 50;

    }
}
