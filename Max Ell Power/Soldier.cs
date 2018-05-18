using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    class Soldier : MainCharacter
    {
        //TO DO
        public Soldier() : base()
        {
            Sprites[(int)SpriteDirections.RIGHT] = new Image[]{
                new Image("imgs/bearRight1.png", 138, 129),
            new Image("imgs/bearRight2.png", 138, 129),
            new Image("imgs/bearRight3.png", 138, 129),
            new Image("imgs/bearRight4.png", 138, 129)};

            Sprites[(int)SpriteDirections.LEFT] = new Image[]{
                new Image("imgs/bearLeft1.png", 138, 129),
            new Image("imgs/bearLeft2.png", 138, 129),
            new Image("imgs/bearLeft3.png", 138, 129),
            new Image("imgs/bearLeft4.png", 138, 129)};

            UpdateSpriteCoordinates();
        }
    }
}
