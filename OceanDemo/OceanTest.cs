using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanDemo
{
    class OceanTest
    {
        private static Random random;

        #region ---===   Methods   ===---

            #region ---===   Create Ocean   ===---

            public static Ocean CreateOcean(int rows, int cols, int preys, int predators, int obstacle, int iteration)
            {
                random = new Random();
                Verification(ref rows, ref cols, ref preys, ref predators, ref obstacle, ref iteration);

                Ocean ocean = new Ocean(rows, cols, preys, predators, obstacle, iteration);

                InitInhabitance(ocean, Images.Obstacle);
                InitInhabitance(ocean, Images.Predators);
                InitInhabitance(ocean, Images.Prey);

                return ocean;

            }

            public static Ocean CreateOcean(int rows, int cols)
            {
                random = new Random();
                Verification(ref rows, ref cols);

                int preys = random.Next(1, Constant.MaxPreys);
                int predators = random.Next(1, Constant.MaxPredators);
                int obstacle = random.Next(0, Constant.MaxObstacle);
                int iteration = random.Next(Constant.MinIteration, Constant.MaxIteration);

                Ocean ocean = new Ocean(rows, cols, preys, predators, obstacle, iteration);

                InitInhabitance(ocean, Images.Obstacle);
                InitInhabitance(ocean, Images.Predators);
                InitInhabitance(ocean, Images.Prey);

                return ocean;
            }

            public static Ocean CreateOcean() //рандомное наполнение океана
            {
                random = new Random();

                int rows = random.Next(1, Constant.MaxRows);
                int cols = random.Next(1, Constant.MaxCols);
                int preys = random.Next(1, Constant.MaxPreys);
                int predators = random.Next(1, Constant.MaxPredators);
                int obstacle = random.Next(0, Constant.MaxObstacle);
                int iteration = random.Next(Constant.MinIteration, Constant.MaxIteration);

                Ocean ocean = new Ocean(rows, cols, preys, predators, obstacle, iteration);

                InitInhabitance(ocean, Images.Obstacle);
                InitInhabitance(ocean, Images.Predators);
                InitInhabitance(ocean, Images.Prey);

                return ocean;
            }

            #endregion

            #region ---===   Verification   ===---

            private static void Verification(ref int rows, ref int cols, ref int preys, ref int predators, ref int obstacle, ref int iteration)
            // ToDo добавить логирование изменений переменный (прошлое значение --> НОВОЕ)
            {
                if (rows <= 0 || rows > Constant.MaxRows)
                {
                    rows = random.Next(1, Constant.MaxRows);
                }

                if (cols <= 0 || cols > Constant.MaxCols)
                {
                    cols = random.Next(1, Constant.MaxCols);
                }

                if (preys < 0 || preys > Constant.MaxPreys)
                {
                    preys = random.Next(1, Constant.MaxPreys);
                }

                if (predators < 0 || predators > Constant.MaxPredators)
                {
                    predators = random.Next(1, Constant.MaxPredators);
                }

                if (obstacle < 0 || obstacle > Constant.MaxObstacle)
                {
                    obstacle = random.Next(0, Constant.MaxObstacle);
                }

                if (iteration < Constant.MinIteration || iteration > Constant.MaxIteration)
                {
                    iteration = random.Next(Constant.MinIteration, Constant.MaxIteration);
                }
            }

            private static void Verification(ref int rows, ref int cols)
            {
                if (rows <= 0 || rows > Constant.MaxRows)
                {
                    rows = random.Next(1, Constant.MaxRows);
                }

                if (cols <= 0 || cols > Constant.MaxCols)
                {
                    cols = random.Next(1, Constant.MaxCols);
                }
            }

        #endregion

        private static void InitInhabitance(Ocean ocean, Images image)
        {
            int count;

            switch (image)
            {
                case Images.Obstacle:
                    count = ocean.NumObstecles;
                    break;

                case Images.Predators:
                    count = ocean.NumPredators;
                    break;

                case Images.Prey:
                    count = ocean.NumPrey;
                    break;

                default:
                    count = 0;
                    break;
            }

            for (int i = 0; i < count; i++)
            {
                bool res = false;

                do
                {
                    Coordinate coord = new Coordinate()
                    {
                        X = random.Next(0, ocean.NumCols),
                        Y = random.Next(0, ocean.NumRows)
                    };

                    res = ocean.IsBoundedCoordinate(coord) && ocean.IsEmptyCoordinate(coord);

                    if (res)
                    {
                        Cell newCell = null;

                        switch (image)
                        {
                            case Images.Obstacle:
                                newCell = new Obstacle(coord, ocean);
                                break;

                            case Images.Predators:
                                newCell = new Predator(coord, ocean);
                                break;

                            case Images.Prey:
                                newCell = new Prey(coord, ocean);
                                break;

                            default:
                                count = 0;
                                break;
                        }

                        ocean.AddCell(newCell);
                    }

                } while (!res);
            }
        }

        #endregion

    }
}
