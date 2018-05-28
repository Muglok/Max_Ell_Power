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
        Points = 0;
        Weapons = new List<Weapon>();
    }

    public abstract void AddWeapon();

    public void AddWeapon(Weapon w)
    {
        w.X = this.X;
        w.Y = this.Y;
        w.CurrentDirection = this.CurrentDirection;
        w.UpdateSpriteCoordinates();
        Weapons.Add(w);
    }
    public void RemoveWeapon(int index)
    {
        Weapons.RemoveAt(index);
    }
}

