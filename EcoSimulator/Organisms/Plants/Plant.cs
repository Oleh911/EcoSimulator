using EcoSimulator.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSimulator
{
    internal abstract class Plant: Cell
    {
        protected uint _size;
        protected uint _energy;
        protected bool _seed;
        protected uint _energyToReproduceNeed;
        public override Position Pos { get; protected set; }
        public uint Size { get { return _size; } }
        public uint Energy { get { return _energy; } }
        public bool Seed { get { return _seed; } }
        public float Species { get; }
        public uint EnergyToReproduceNeed { get {  return _energyToReproduceNeed; } }
        public uint EnergyLimits { get { return _size * Constants.PlantsConst.EnergyLimitСoef; } }
        protected Plant(int x, int y, uint size)
        {
            _size = size;
            _energy = size / 2;
            _seed = true;
            _energyToReproduceNeed = size / 2;
            Pos = new(x, y, Constants.WorldLevel.Plants);
        }
        public abstract void Eat();
        public abstract Plant Reproduce(Position childPos);
    }
}
