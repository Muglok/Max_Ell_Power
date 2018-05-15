using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    class Screen
    {
        protected Hardware hardware;

        public Screen(Hardware hardware)
        {
            this.hardware = hardware;
        }

        public virtual void Show()
        {
            //TO DO
        }
    }
}
