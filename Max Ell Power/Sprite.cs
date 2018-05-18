using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    /*
     * This class mange all the sprites in the game containing his coordenates
     * and sprite coordenates
     */
    class Sprite
    {
        public short X { get; set; }
        public short Y { get; set; }
        public short SpriteX { get; set; }
        public short SpriteY { get; set; }

        public void MoveTo(short x, short y)
        {
            X = x;
            Y = y;
        }

        public void CollidesWith()
        {
            //TO DO
        }
    }
}
