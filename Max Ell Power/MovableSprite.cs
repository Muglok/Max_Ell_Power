using System;
/*
* This class manage the sprites that will move in the game screen
*/
class MovableSprite : Sprite
{
    const byte TOTAL_MOVEMENTS = 8;
    //Sprite speed control
    public byte SPRITE_CHANGE = 6;
    //Spites posible direcctions, without use for now
    public enum SpriteDirections { LEFT, RIGHT, UP, DOWN, RIGHT_UP, LEFT_UP,
        RIGHT_DOWN, LEFT_DOWN };
    public SpriteDirections CurrentDirection { get; set; }
    public byte CurrentSprite { get; set; }

    byte currentSpriteChange;

    public Image[][] Sprites = new Image[TOTAL_MOVEMENTS][];

    public MovableSprite()
    {
        CurrentSprite = 0;
        CurrentDirection = SpriteDirections.LEFT;
        currentSpriteChange = 0;
    }

    public void Animate(SpriteDirections movement)
    {
        if(CurrentDirection != movement)
        {
            CurrentDirection = movement;
            CurrentSprite = 0;
            currentSpriteChange = 0;
        }
        else
        {
            currentSpriteChange++;
            if(currentSpriteChange >= SPRITE_CHANGE)
            {
                currentSpriteChange = 0;
                //Control the sprite speed
                if(CurrentDirection != SpriteDirections.UP ||
                    CurrentDirection != SpriteDirections.DOWN)
                    CurrentSprite = (byte)((CurrentSprite + 1) % Sprites[(int)CurrentDirection].Length);
                else
                    CurrentSprite = (byte)((CurrentSprite + 4) % Sprites[(int)CurrentDirection].Length);
            }
        }
        UpdateSpriteCoordinates();
    }

    public void UpdateSpriteCoordinates()
    {
        SpriteImage = (Image)Sprites[(int)CurrentDirection][CurrentSprite];
    }

    public void Fall(float speed)
    {
        if (speed <= 0)
            speed = 7;
        if (speed % 2 == 1)
             speed++;
         this.Y += (short)(speed);
    }
}
