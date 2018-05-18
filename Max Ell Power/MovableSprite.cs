using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    /*
     * This class manage the sprites that will move in the game screen
     */
    class MovableSprite : Sprite
    {
        const byte TOTAL_MOVEMENTS = 2;
        //Spites posible direcctions, without use for now
        public enum SpriteDirections { LEFT, RIGHT, UP, DOWN, RIGHT_UP, LEFT_UP,
            RIGHT_DOWN, LEFT_DOWN };
        public SpriteDirections CurrentDirection { get; set; }
        public byte CurrentSprite { get; set; }

        byte currentSpriteChange;

        public Image[] Sprites = new Image[TOTAL_MOVEMENTS];

        
        public MovableSprite()
        {
            CurrentSprite = 0;
            CurrentDirection = SpriteDirections.LEFT;
            currentSpriteChange = 0;
        }

        public void Animate()
        {
            //TO DO
        }

        public void UpdateSpriteCoordinates()
        {
            //TO DO
        }
    }
}
