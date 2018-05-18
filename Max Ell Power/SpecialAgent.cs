using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    class SpecialAgent : MainCharacter
    {
        //TO DO

        public SpecialAgent()
        {
            Sprites[(int)SpriteDirections.RIGHT] =
                new Image(@"imgs\SpecialAgentRight.png",190,234);
            Sprites[(int)SpriteDirections.LEFT] =
                new Image(@"imgs\SpecialAgentLeft.png", 190, 234);
        }
    }
}
