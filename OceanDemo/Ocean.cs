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
                if (value < 0 || value > Constant.MaxRows)
                {
                    _numRows = Constant.MaxRows;

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
                if (value < 0 || value > Constant.MaxCols)
                {
                    _numCols = Constant.MaxCols;

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
                if (value < 0 || value > Constant.MaxPreys)
                {
                    _numPrey = Constant.MaxPreys;

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
                if (value < 0 || value > Constant.MaxPredators)
                {
                    _numPredators = Constant.MaxPredators;

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
                if (value < 0 || value > Constant.MaxObstacle)
                {
                    _numObstecles = Constant.MaxObstacle;

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
       
        public Coordinate[] GetNeighborsWithImage(Coordinate c, Images image)
        {
            Coordinate[] neighbors = new Coordinate[Constant.NumDirection];
            byte count = 0;

            if (!IsEmptyCoordinate(this[c, Direction.Up])
                && this[this[c, Direction.Up]].Image == image)
            {
                neighbors[count++] = this[c, Direction.Up];
            }

            if (!IsEmptyCoordinate(this[c, Direction.Down])
                && this[this[c, Direction.Down]].Image == image)
            {
                neighbors[count++] = this[c, Direction.Down];
            }

            if (!IsEmptyCoordinate(this[c, Direction.Left])
                && this[this[c, Direction.Left]].Image == image)
            {
                neighbors[count++] = this[c, Direction.Left];
            }

            if (!IsEmptyCoordinate(this[c, Direction.Right])
                && this[this[c, Direction.Right]].Image == image)
            {
                neighbors[count++] = this[c, Direction.Right];
            }

            Coordinate[] resNeighbors;
            if (count == 0)
            {
                resNeighbors = new Coordinate[1];
                resNeighbors[count] = c;
            }
            else
            {
                resNeighbors = new Coordinate[count];
                Array.Copy(neighbors, 0, resNeighbors, 0, count);
            }

            return resNeighbors;
        }

        public Coordinate[] GetNeighborsEmpty(Coordinate cord)
        {
            Coordinate[] neighbors = new Coordinate[Constant.NumDirection];
            int count = 0;

            if (this[this[cord, Direction.Up]] == null)
            {
                neighbors[count++] = this[cord, Direction.Up];
            }

            if (this[this[cord, Direction.Down]] == null)
            {
                neighbors[count++] = this[cord, Direction.Down];
            }

            if (this[this[cord, Direction.Left]] == null)
            {
                neighbors[count++] = this[cord, Direction.Left];
            }

            if (this[this[cord, Direction.Right]] == null)
            {
                neighbors[count++] = this[cord, Direction.Right];
            }

            Coordinate[] resNeighbors;

            if (count == 0)
            {
                resNeighbors = new Coordinate[1];
                resNeighbors[count] = cord;
            }
            else
            {
                resNeighbors = new Coordinate[count];
                Array.Copy(neighbors, 0, resNeighbors, 0, count - 1);
            }

            return resNeighbors;
        }

        public bool AddCell(Cell newCell)
        {
            bool res = false;

            if (IsBoundedCoordinate(newCell.Offset) 
                && IsEmptyCoordinate(newCell.Offset))
            {
                this[newCell.Offset] = newCell.GetClone();
                res = true;
            }

            return res;
        }

        public bool IsBoundedCoordinate(Coordinate cord)
        {
            return ((cord.Y >= 0 && cord.Y < _cells.GetLength(0))
                 && (cord.X >= 0 && cord.X < _cells.GetLength(1)));
        }

        public bool IsEmptyCoordinate(Coordinate cord)
        {
            return (_cells[cord.Y, cord.X] == null);
        }

        public void MoveFrom(Coordinate from, Coordinate to)
        {
            Cell temp = this[from];
            temp.Offset = to;

            this[from] = null;
            this[to] = temp;
        }

        public bool Run()
        {
            if (--_numIterations > 0 
                && (GetCountItems(Images.Prey) > 0 
                || GetCountItems(Images.Predators) > 0))
            {
                for (ushort row = 0; row < _numRows; row++)
                {
                    for (ushort col = 0; col < _numCols; col++)
                    {
                        if (_cells[row, col] != null)
                        {
                            _cells[row, col].Process();
                        }
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCountItems(Images images)
        {
            int count = 0;

            for (int row = 0; row < _cells.GetLength(0); row++)
            {
                for (int col = 0; col < _cells.GetLength(1); col++)
                {
                    if (_cells[row, col] != null 
                        && _cells[row, col].Image == images)
                    {
                        ++count;
                    }
                }
            }

            return count;
        }

        #endregion

    }
}
