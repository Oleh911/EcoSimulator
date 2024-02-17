using EcoSimulator.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSimulator
{
    internal class Carrot : Plant, IPlant
    {

        public Carrot(int x, int y, uint size) : base(x, y, size)
        {
        }
        public override void Eat()
        {
            if (_seed)
            {
                _energy++;
                if(_energy >= _size)
                {
                    _seed = false;
                }
            }
            else
            {
                _energy += _size;
            }
        }
        public override (Position oldPos, Position newPos, Cell? child) TakeStep(IUpdater updater)
        {
            return updater.Update(this);
        }
        public override Plant Reproduce(Position childPos)
        {
            uint newSize = 1;
            int sizeChange = Constants.Random.Next(-Constants.PlantsConst.EvolutionToChange, Constants.PlantsConst.EvolutionToChange + 1);
            if ((_size + sizeChange) > 0)
            {
                newSize = (uint)(_size + sizeChange);
            }
            _energy -= _energyToReproduceNeed;

            return new Carrot(childPos.X, childPos.Y, newSize);
        }
    }
}
