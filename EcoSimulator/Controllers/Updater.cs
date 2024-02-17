using EcoSimulator.Organisms.Animals;

namespace EcoSimulator.Controllers
{
    internal interface IUpdater
    {
        public (Position oldPos, Position newPos, Cell? child) Update(Carrot carrot);
        public (Position oldPos, Position newPos, Cell? child) Update(Rabbit rabbit);
    }
    internal class Updater: IUpdater
    {
        private bool?[, ,] _canDoSteep;

        public Updater(int rows, int cols, List<Position> firstOrganisms)
        {
            _canDoSteep = new bool?[rows, cols, Constants.WorldLevel.Max];
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    for(int z = 0; z < Constants.WorldLevel.Max; z++)
                    {
                        _canDoSteep[x, y, z] = null;
                    }
                }
            }
            foreach (Position pos in firstOrganisms)
            {
                _canDoSteep[pos.X, pos.Y, pos.Z] = true;
            }
        }

        public bool CanDoSteep(Position pos)
        {
              return (bool)_canDoSteep[pos.X, pos.Y, pos.Z];
        }

        public void Checked(Position pos)
        {
            _canDoSteep[pos.X, pos.Y, pos.Z] = true;
        }

        public void AddNewOrganism(Position pos)
        {
            _canDoSteep[pos.X, pos.Y, pos.Z] = false;
        }
        //public void RelocateOrganism(int x, int y, int z)
        //{

        //}

        public void DeleteOrganism(Position pos)
        {
            _canDoSteep[pos.X, pos.Y, pos.Z] = null;
        }

        public (Position oldPos, Position newPos, Cell? child) Update(Carrot carrot)
        {
            (Position oldPos, Position newPos, Cell? child) returnedData = new(carrot.Pos, carrot.Pos, null);
            if (!carrot.Seed && carrot.Energy > carrot.EnergyToReproduceNeed)
            {
                List<Position> freeCells = new List<Position>();
                for (int x = carrot.Pos.X - 1; x <= carrot.Pos.X + 1; x++)
                {
                    for (int y = carrot.Pos.Y - 1; y <= carrot.Pos.Y + 1; y++)
                    {
                        try// needed to avoid ListOutOfRange exception
                        {
                            if (_canDoSteep[x, y, Constants.WorldLevel.Plants] == null)
                            {
                                freeCells.Add(new(x, y, Constants.WorldLevel.Plants));
                            }
                        }
                        catch { /* ignored */}
                    }
                }
                if (freeCells.Count > 0)
                {
                    returnedData.child = carrot.Reproduce(freeCells[Constants.Random.Next(freeCells.Count)]);
                    freeCells.Clear();

                    return returnedData;
                }
            }
            if (carrot.Energy < carrot.EnergyLimits)
            {
                carrot.Eat();
            }

            return returnedData;
        }
        public (Position oldPos, Position newPos, Cell? child) Update(Rabbit rabbit)
        {
            (Position oldPos, Position newPos, Cell? child) returnedData = new(rabbit.Pos, rabbit.Pos, null);

            return returnedData;
        }

    }


}
