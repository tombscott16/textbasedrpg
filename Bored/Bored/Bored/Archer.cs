using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bored
{
    class Archer
    {
        Normal aNormal = new Normal();

        public int getRangedDamage()
        {
            return aNormal.getRangedDamage(5, 4);
        }
    }
}
