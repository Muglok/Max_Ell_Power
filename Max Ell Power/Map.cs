using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    /*
     * This class contains all the diferent elements in the map, draw the map and 
     * check colisions with diferent objects.
     * */
    class Map
    {
        public List<Sprite> Walls { get; }
        public List<Enemy> Enemies { get; }
        public List<EnemiesGenerator> Generators { get; }
        public List<DangerousFloor> DangerousFloors { get; }
        public List<Treasure> Treasures { get; }
        public List<Trap> Traps { get; }
        public List<Ladder> Ladders { get; }
        public List<CheckPoint> CheckPoints { get; }
        public StartPoint Start { get; set; }
        public StartPoint Exit { get; set; }
        

        public short Width { get; set; }
        public short Height { get; set; }
        public short XMap { get; set; }
        public short YMap { get; set; }

        public void AddWall()
        {
            //TO DO
        }

        public void CollidesCharacterWithTreasure()
        {
            //TO DO
        }

        public void CollidesCharacterWithScoreItems()
        {
            //TO DO
        }

        public void CollidesCharacterWithWalls()
        {
            //TO DO
        }

        public void CollidesCharacterWithEnemies()
        {
            //TO DO
        }
    }
}
