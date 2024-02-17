using EcoSimulator.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSimulator.Organisms.Animals
{
    internal abstract class Animal: Cell
    {
        protected uint _size;
        protected uint _energy;
        protected uint _energyToReproduceNeed;
        public override Position Pos { get; protected set; }
        public uint Size { get { return _size; } }
        public uint Energy { get { return _energy; } }
        public float Species { get; }
        public uint EnergyToReproduceNeed { get { return _energyToReproduceNeed; } }
        public uint EnergyLimits { get { return _size * Constants.AnimalConst.EnergyLimitСoef; } }
        protected Animal(int x, int y, uint size)
        {
            _size = size;
            _energy = size / 2;
            _energyToReproduceNeed = size / 2;
            Pos = new(x, y, Constants.WorldLevel.Animals);
        }
        public abstract void Eat(uint addEnergy);
        public abstract Animal Reproduce(Position childPos);
        public abstract void Move(Position newPos);
    }
}
