using EcoSimulator.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSimulator.Organisms.Animals
{
    internal class Fox : Animal
    {
        public Fox(int x, int y, uint size) : base(x, y, size)
        {
        }

        public override Position Pos { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

        public override void Eat(uint addEnergy)
        {
            throw new NotImplementedException();
        }

        public override void Move(Position newPos)
        {
            throw new NotImplementedException();
        }

        public override Animal Reproduce(Position childPos)
        {
            throw new NotImplementedException();
        }

        public override (Position oldPos, Position newPos, Cell? child) TakeStep(IUpdater visitor)
        {
            throw new NotImplementedException();
        }
    }
}
