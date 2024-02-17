using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Constants
{
    public static class WorldLevel
    {
        public static int Max => 2;
        public static int Animals => 1;
        public static int Plants => 0;
    }
    public static class PlantsConst
    {
        public static int CreationPossibility => 25;
        public static uint BaseEnergyForSeed => BasicSize/2;
        public static uint BasicSize => 5;
        public static int EvolutionToChange => 2;
        public static uint EnergyLimitСoef => 4;
    }
    public static class AnimalConst
    {
        public static int CreationPossibility => 25;
        public static uint EnergyLimitСoef => 4;
        public static uint BasicSize => 8;
        public static int EvolutionToChange => 2;

    }
    public static Random Random = new();
    public static int ImageSize => 32;
}
