using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Sword : Weapon
    {
        public Sword(int hitmod, int crtmod, int dmgmod) : base(hitmod, crtmod, dmgmod)
        {
            hit = 95;
            crt = 10;
            hit += hitmod;
            crt += crtmod;
            this.dmgmod = dmgmod;
        }

        public Sword(int mod, int hitmod, int crtmod, int dmgmod) : base(mod, hitmod, crtmod, dmgmod)
        {
            hit = 95;
            crt = 10;
            hit += hitmod;
            crt += crtmod;
            this.mod = mod;
            this.dmgmod = dmgmod;
        }
    }
}
