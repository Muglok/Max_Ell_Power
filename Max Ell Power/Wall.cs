/*
* One of the diferent items that contains the map
*/
class Wall : StaticSprite
{
    public Wall()
    {
        SPRITE_WIDTH = 50;
        SPRITE_HEIGHT = 50;

        Image wall = new Image("imgs/brick.png", SPRITE_WIDTH, SPRITE_HEIGHT);
    }

    public Wall(short x, short y) : this()
    {
        X = x;
        Y = y;
    }
}

