using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    class Ocean
    {
        #region ---===   Private   ===---

        private static Random _random;
        private Cell[,] _cells;

        private int _numRows;       //количество строк
        private int _numCols;       //количество столбцов

        private int _numPrey;       //количество добычи
        private int _numPredators;  //количество хищников
        private int _numObstecles;  //количество преград
        private int _numIterations; //количество итераций
        private int _size;          //количество элементов Cell

        #endregion

        #region ---===   Get / Set   ===---

        public int NumRows
        {
            get
            {
                return _numRows;
            }
            set
            {
                if (value < 0 || value > Constant.MAX_ROWS)
                {
                    _numRows = Constant.MAX_ROWS;

                    return;
                }

                _numRows = value;
            }
        }

        public int NumCols
        {
            get
            {
                return _numCols;
            }
            set
            {
                if (value < 0 || value > Constant.MAX_COLS)
                {
                    _numCols = Constant.MAX_COLS;

                    return;
                }

                _numCols = value;
            }
        }

        public int NumPrey
        {
            get
            {
                return _numPrey;
            }
            set
            {
                if (value < 0 || value > Constant.MAX_PREYS)
                {
                    _numPrey = Constant.MAX_PREYS;

                    return;
                }

                _numPrey = value;
            }
        }

        public int NumPredators
        {
            get
            {
                return _numPredators;
            }
            set
            {
                if (value < 0 || value > Constant.MAX_PREDATORS)
                {
                    _numPredators = Constant.MAX_PREDATORS;

                    return;
                }

                _numPredators = value;
            }
        }

        public int NumObstecles
        {
            get
            {
                return _numObstecles;
            }
            set
            {
                if (value < 0 || value > Constant.MAX_OBSTACLES)
                {
                    _numObstecles = Constant.MAX_OBSTACLES;

                    return;
                }

                _numObstecles = value;
            }
        }

        public int NumIterations
        {
            get
            { 
                return _numIterations;
            }
            set
            {
                _numIterations = value;
            }
        }

        #endregion

        #region ---===   Indexator   ===---

        public string this[int y, int x]
        {
            get
            {
                if (_cells[y, x] != null)
                {
                    return _cells[y, x].ToString();
                }
                else
                {
                    return ((char)Images.Empty).ToString();
                }
            }
        }

        public Cell this[Coordinate c]
        {
            get
            {
                return _cells[c.Y, c.X];
            }
            set
            {
                _cells[c.Y, c.X] = value;
            }
        }

        protected Coordinate this[Coordinate c, Direction direction]
        {
            get
            {
                Coordinate coord;

                switch (direction)
                {
                    case Direction.Up:
                        coord = GetUp(c);
                        break;

                    case Direction.Down:
                        coord = GetDown(c);
                        break;

                    case Direction.Left:
                        coord = GetLeft(c);
                        break;

                    case Direction.Right:
                        coord = GetRight(c);
                        break;

                    case Direction.Empty:
                    default:
                        coord = new Coordinate(c.X, c.Y);
                        break;
                }

                return coord;
            }
        }

        #region ---===   Get Direction   ===---

        protected Coordinate GetUp(Coordinate coord)
        {
            int index;

            if (coord.Y > 0)
            {
                index = coord.Y - 1;
            }
            else
            {
                index = _numRows - 1;
            }

            return new Coordinate(coord.X, index);
        }

        protected Coordinate GetDown(Coordinate coord)
        {
            int index;
            index = (coord.Y + 1) % -_numRows;

            return new Coordinate(coord.X, index);
        }

        protected Coordinate GetLeft(Coordinate coord)
        {
            int index;

            if (coord.X > 0)
            {
                index = coord.X - 1;
            }
            else
            {
                index = _numCols - 1;
            }

            return new Coordinate(index, coord.Y);
        }

        protected Coordinate GetRight(Coordinate coord)
        {
            int index;
            index = (coord.X + 1) % _numCols;

            return new Coordinate(index, coord.Y);
        }

        #endregion

        #endregion

        #region ---===   Constructors   ===---

        public Ocean(int numRows, int numCols, int numPrey, int numPredators, int numObstecles, int numIteration)
        {
            _random = new Random();

            NumRows = numRows;
            NumCols = numCols;

            NumPrey = numPrey;
            NumPredators = numPredators;
            NumObstecles = numObstecles;

            NumIterations = numIteration;

            _cells = new Cell[NumRows, NumCols];

            _size = _numRows * _numCols;
        }

        #endregion

        #region ---===   Methods   ===---

        public void InitCells()
        {
            AddEmptyCells();
            //AddPrey();
            //AddObctacles();
        }

        private void AddEmptyCells()
        {
            for (int row = 0; row < _numRows; row++)
            {
                for (int col = 0; col < _numCols; col++)
                {
                    _cells[row, col] = new Cell(new Coordinate(col, row), this);
                }
            }
        }

        //public void AddPrey()
        //{
        //    Coordinate empty;

        //    for (int i = 0; i < _numPrey; i++)
        //    {
        //        empty = GetEmptyCellCoord();
        //        _cells[empty.Y, empty.X] = new Prey(empty, this); //Создаем добычу и цепляем к нему океан
        //    }
        //}

        //public void AddObctacles()
        //{
        //    Coordinate empty;

        //    for (int i = 0; i < _numObstecles; i++)
        //    {
        //        empty = GetEmptyCellCoord();
        //        _cells[empty.Y, empty.X] = new Obstacle(empty, this); //Создаем препятствия и цепляем к нему океан
        //    }
        //}

        #endregion






    }
}
