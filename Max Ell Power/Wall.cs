/*
* One of the diferent items that contains the map
*/
class Wall : StaticSprite
{
    public Wall(int n)
    {
        SPRITE_WIDTH = 50;
        SPRITE_HEIGHT = 50;

        SpriteImage = new Image("imgs/Walls/SubWall" + n + ".png",
            SPRITE_WIDTH, SPRITE_HEIGHT);
    }

    public Wall(int n, short x, short y) : this(n)
    {
        this.SpriteImage.X = x;
        this.SpriteImage.Y = (short)(y);
    }
}

