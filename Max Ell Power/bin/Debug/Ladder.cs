/*
* One of the diferent items that contains the map
*/
class Ladder : StaticSprite
{
    public Ladder()
    {
        SPRITE_WIDTH = 50;
        SPRITE_HEIGHT = 50;

        SpriteImage = new Image("imgs/ladder.png",
            SPRITE_WIDTH, SPRITE_HEIGHT);
    }

    public Ladder(short x, short y) : this()
    {
        this.SpriteImage.X = x;
        this.SpriteImage.Y = (short)(y);
    }
}

