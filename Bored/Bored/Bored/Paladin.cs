using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bored
{
    class Paladin
    {
        Normal aNormal = new Normal();

        public int getMeleeDamage()
        {
            return aNormal.getMeleeDamage(5, 4);
        }
    }
}
