/*
 *This class manage the platforms 
 */

class Platform : StaticSprite
{
    public short floorMargin;

    public Platform(int n)
    {
        if(n == 1)
        {
            SPRITE_WIDTH = 150;
            SPRITE_HEIGHT = 103;
            floorMargin = 0;
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

    public Platform(int n, short x, short y) : this(n)
    {
        this.SpriteImage.X = x;
        this.SpriteImage.Y = (short)(y - 720 - this.floorMargin);
    }
}
