using EcoSimulator.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EcoSimulator
{
    abstract class Cell
    {
        public abstract Position Pos {get; protected set; }
        public abstract (Position oldPos, Position newPos, Cell? child) TakeStep(IUpdater visitor);
    }

}
