﻿using System.Collections.Generic;
/*
* This class mange all the sprites in the game containing his coordenates
* and sprite coordenates
*/
class Sprite
{
    public short SPRITE_WIDTH;
    public short SPRITE_HEIGHT;
    public short SPRITE_BASE;

    public short X { get; set; }
    public short Y { get; set; }
       
    public Image SpriteImage { get; set; }

    public void MoveTo(short x, short y)
    {
        X = x;
        Y = y;
    }

    public bool CollidesWithImage(Image sp)
    {
         return (this.X + this.SPRITE_WIDTH > sp.X && X<sp.X + sp.ImageWidth &&
                 this.Y + this.SPRITE_HEIGHT> sp.Y && Y<sp.Y + sp.ImageHeight);
    }

    public bool CollidesWithImageShoot(Image sp)
    {
        return (this.SpriteImage.X + this.SPRITE_WIDTH > sp.X && this.SpriteImage.X < sp.X + sp.ImageWidth &&
                this.SpriteImage.Y + this.SPRITE_HEIGHT > sp.Y && this.SpriteImage.Y < sp.Y + sp.ImageHeight);
    }

    public bool IsOver(Image img)
    {
        return (this.CollidesWith(img, (short)(this.SPRITE_WIDTH - this.SPRITE_BASE), 
            this.SPRITE_HEIGHT,(short)(img.ImageWidth - this.SPRITE_BASE), img.ImageHeight) &&
        img.Y >= this.Y + this.SPRITE_HEIGHT * 0.8);
    }

    public bool CollidesWith(Image img, short w1, short h1, short w2, short h2)
    {
        return (X + w1 >= img.X && X <= img.X + w2 &&
                    Y + h1 >= img.Y && Y <= img.Y + h2);
    }

    public bool CollidesWith(Sprite sp)
    {
        return (this.X + this.SPRITE_WIDTH > sp.X && X < sp.X + sp.SPRITE_WIDTH &&
                 this.Y + this.SPRITE_HEIGHT > sp.Y && Y < sp.Y + sp.SPRITE_HEIGHT);
    }

    public bool CollidesWith(List<Wall> sprites)
    {
        foreach (Sprite sp in sprites)
            if (this.CollidesWith(sp))
                return true;
        return false;
    }
    public bool CollidesWith(List<Platform> sprites)
    {
        foreach (Sprite sp in sprites)
            if (this.CollidesWith(sp))
                return true;
        return false;
    }
}
