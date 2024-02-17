using EcoSimulator.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSimulator.Organisms.Animals
{
    internal class Rabbit : Animal
    {
        public Rabbit(int x, int y, uint size) : base(x, y, size)
        {

        }
        public override (Position oldPos, Position newPos, Cell? child) TakeStep(IUpdater visitor)
        {
            return visitor.Update(this);
        }

        public override void Eat(uint addEnergy)
        {
            _energy+=addEnergy;
        }

        public override Animal Reproduce(Position childPos)
        {
            uint newSize = 1;
            int sizeChange = Constants.Random.Next(-Constants.AnimalConst.EvolutionToChange, Constants.AnimalConst.EvolutionToChange + 1);
            if ((_size + sizeChange) > 0)
            {
                newSize = (uint)(_size + sizeChange);
            }
            _energy -= _energyToReproduceNeed;

            return new Rabbit(childPos.X, childPos.Y, newSize); 
        }
        public override void Move(Position newPos)
        {
            Pos = newPos;
        }


    }
}
