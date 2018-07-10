using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bored
{
    class Wizard
    {
        Normal aNormal = new Normal();

        public int getMagicDamage()
        {
            return aNormal.getMagicDamage(5, 4);
        }
    }
}
