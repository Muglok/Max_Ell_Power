/*
* This class mange all the sprites in the game containing his coordenates
* and sprite coordenates
*/
class Sprite
{
    public short SPRITE_WIDTH;
    public short SPRITE_HEIGHT;

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
