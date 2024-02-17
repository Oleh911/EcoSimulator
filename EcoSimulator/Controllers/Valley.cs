using EcoSimulator.Controllers;
using EcoSimulator.Organisms.Animals;
namespace EcoSimulator
{
    internal class Valley
    {
        private Cell[,,] _valley;
        private Updater Visitor;
        private int _rows;
        private int _cols;

        public Valley(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
            _valley = new Cell[rows, cols, Constants.WorldLevel.Max];
            Visitor = new Updater(rows, cols, new List<Position>());
        }

        public void Initialize(int carrotNum, int rabbitNum, int foxNum)
        {
            List<Position> firstCreatures = new();
            for (int x = 0; x < _rows; x++)
            {
                for (int y = 0; y < _cols; y++)
                {
                    for (int z = 0; z < Constants.WorldLevel.Max; z++)
                    {
                        _valley[x, y, z] = null;
                        if (carrotNum > 0 && z == Constants.WorldLevel.Plants && Constants.Random.Next(Constants.PlantsConst.CreationPossibility) == 0)
                        {
                            _valley[x, y, Constants.WorldLevel.Plants] = new Carrot(x, y, Constants.PlantsConst.BasicSize);
                            firstCreatures.Add(_valley[x, y, Constants.WorldLevel.Plants].Pos);
                            carrotNum--;
                        }
                        if (rabbitNum > 0 && z == Constants.WorldLevel.Animals && Constants.Random.Next(Constants.AnimalConst.CreationPossibility) == 1)
                        {
                            _valley[x, y, Constants.WorldLevel.Animals] = new Rabbit(x, y, Constants.PlantsConst.BasicSize);
                            firstCreatures.Add(_valley[x, y, Constants.WorldLevel.Animals].Pos);
                            rabbitNum--;
                        }
                    }
                }
            }
            Visitor = new Updater(_rows, _cols, firstCreatures);
            firstCreatures.Clear();
        }

        public void UpdateValley()
        {
            for (int x = 0; x < _rows; x++)
            {
                for (int y = 0; y < _cols; y++)
                {
                    for (int z = 0; z < Constants.WorldLevel.Max; z++)
                    {
                        if (_valley[x, y, z] != null)
                        {
                            var result = _valley[x, y, z].TakeStep(Visitor);
                            Position oldPos = result.oldPos;
                            Position newPos = result.newPos;
                            Cell? child = result.child;
                            if (oldPos != newPos)
                            {
                                _valley[newPos.X, newPos.Y, newPos.Z] = _valley[x, y, z];
                                _valley[x, y, z] = null;
                            }
                            if (child != null)
                            {
                                _valley[child.Pos.X, child.Pos.Y, child.Pos.Z] = child;
                                Visitor.AddNewOrganism(child.Pos);
                            }
                            Visitor.Checked(_valley[x, y, z].Pos);
                        }

                    }
                }
            }
        }

        public Cell GetCell(int x, int y, int z)
        {
            return _valley[x, y, z];
        }
    }
}
