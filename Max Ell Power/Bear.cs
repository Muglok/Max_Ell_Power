using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    class Bear : MainCharacter
    {
        public Bear()
        {
            Sprites[(int)SpriteDirections.RIGHT] =
                new Image(@"imgs\bearspritesRight.png", 190, 234);
            Sprites[(int)SpriteDirections.LEFT] =
                new Image(@"imgs\bearspritesLeft.png", 190, 234);
        }
    }
}
