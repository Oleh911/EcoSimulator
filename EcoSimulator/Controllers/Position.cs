using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSimulator.Controllers
{
    public struct Position(int x, int y, int z)
    {
        public int X = x;
        public int Y = y;
        public int Z = z;

        public static bool operator ==(Position This, Position Other)
        {
            if(This.X != Other.X)
            {
                return false;
            }
            if(This.Y != Other.Y)
            {
                return false;
            }
            if(This.Z != Other.Z)
            {
                return false;
            }
            
            return true;
        }
        public static bool operator != (Position This, Position Other)
        {
            if (This.X != Other.X)
            {
                return true;
            }
            if (This.Y != Other.Y)
            {
                return true;
            }
            if (This.Z != Other.Z)
            {
                return true;
            }

            return false;
        }
        public Position GetPos() { return new Position(X, Y, Z); }
    }
}
