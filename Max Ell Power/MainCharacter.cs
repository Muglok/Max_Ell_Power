using System.Collections.Generic;
/*
* This class is used to define the attributes of the main character 
*/
abstract class MainCharacter : MovableSprite
{
    public byte STEP_LENGHT = 4;
    public short Lives { get; set; }
    public short Points { get; set; }
    public List<Weapon> Weapons { get; }

    public MainCharacter()
    {
        Lives = 5;
        Points = 0;
        Weapons = new List<Weapon>();
    }

    public abstract void AddWeapon();

    public void AddWeapon(Weapon w)
    {
        w.CurrentDirection = this.CurrentDirection;
        if(w.CurrentDirection == MovableSprite.SpriteDirections.LEFT)
            w.SpriteImage.X = (short)(this.X - 30);
        else if(w.CurrentDirection == MovableSprite.SpriteDirections.RIGHT)
            w.SpriteImage.X = (short)(this.X + 150);

        w.SpriteImage.Y = (short)(this.Y + this.SPRITE_HEIGHT/2);
        
        //w.UpdateSpriteCoordinates();
        Weapons.Add(w);
    }
    public void RemoveWeapon(int index)
    {
        Weapons.RemoveAt(index);
    }
}

