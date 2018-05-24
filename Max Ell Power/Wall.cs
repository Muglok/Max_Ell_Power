/*
* One of the diferent items that contains the map
*/
class Wall : StaticSprite
{
    public Wall()
    {
        SPRITE_WIDTH = 50;
        SPRITE_HEIGHT = 50;

        SpriteImage = new Image("imgs/brick.png", SPRITE_WIDTH, SPRITE_HEIGHT);
    }
}

