using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    class Screen
    {
        /*
         * Diferent tipes of screens inheredits of this class
         */
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
