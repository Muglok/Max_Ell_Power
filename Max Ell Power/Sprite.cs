/*
* This class mange all the sprites in the game containing his coordenates
* and sprite coordenates
*/
class Sprite
{
    public const short SPRITE_WIDTH = 138;
    public const short SPRITE_HEIGHT = 129;

    public short X { get; set; }
    public short Y { get; set; }
       
    public Image SpriteImage { get; set; }

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
