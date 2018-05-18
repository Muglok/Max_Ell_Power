using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    class Frog : MainCharacter
    {
        public Frog()
        {
            Sprites[(int)SpriteDirections.RIGHT] =
                new Image(@"imgs\RanitaRight.png", 190, 234);
            Sprites[(int)SpriteDirections.LEFT] =
                new Image(@"imgs\RanitaLeft.png", 190, 234);
        }
    }
}
