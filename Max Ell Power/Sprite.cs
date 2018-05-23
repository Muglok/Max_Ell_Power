using System.Collections.Generic;
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

    public bool CollidesWith(Image image, short w1, short h1, short w2, short h2)
    {
        return (X + w1 >= image.X && X <= image.X + w2 &&
                   Y + h1 >= image.Y && Y <= image.Y + h2);
    }

   /* public bool CollidesWithImage(Image sp)
    {
        return (this.X + this.SPRITE_WIDTH > sp.X && X < sp.X + this.SPRITE_WIDTH &&
                this.Y + this.SPRITE_HEIGHT > sp.Y && Y < sp.Y + this.SPRITE_HEIGHT);
    }

    public bool CollidesWith(List<Sprite> sprite)
    {
        foreach (Sprite sp in sprite)
            if (this.CollidesWith(sprite))
                return true;
            return false;
    }*/

    public bool IsOver(Image img)
    {
        return (this.CollidesWith(img, this.SPRITE_WIDTH, this.SPRITE_HEIGHT,
        img.ImageWidth, img.ImageHeight) &&
        img.Y >= this.Y + this.SPRITE_HEIGHT * 0.9);
    }
}
