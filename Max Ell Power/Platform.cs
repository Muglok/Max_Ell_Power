using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Platform : StaticSprite
{
    public short floorMargin;

    public Platform(int n)
    {
        if(n == 1)
        {
            SPRITE_WIDTH = 150;
            SPRITE_HEIGHT = 103;
            floorMargin = 30;
            SpriteImage = new Image("imgs/platform1.png", SPRITE_WIDTH,
                SPRITE_HEIGHT);
        }

        if(n == 2)
        {
            SPRITE_WIDTH = 176;
            SPRITE_HEIGHT = 80;
            floorMargin = 30;
            SpriteImage = new Image("imgs/platform2.png", SPRITE_WIDTH,
                SPRITE_HEIGHT);
        }
    }
}

