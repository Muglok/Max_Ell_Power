/*
* One of the diferent items that contains the map
*/
class Wall : StaticSprite
{
    public Wall()
    {
        SPRITE_WIDTH = 50;
        SPRITE_HEIGHT = 50;

        SpriteImage = new Image("imgs/SubWall5.png", SPRITE_WIDTH, SPRITE_HEIGHT);
    }

    public Wall(short x, short y) : this()
    {
        this.SpriteImage.X = x;
        this.SpriteImage.Y = (short)(y-720);
    }
}

