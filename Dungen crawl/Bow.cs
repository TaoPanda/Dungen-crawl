using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    class Bow : Weapon
    {
        public Bow(int hitmod, int crtmod, int dmgmod) : base(hitmod, crtmod, dmgmod)
        {
            hit = 75;
            crt = 40;
            hit += hitmod;
            crt += crtmod;
            this.dmgmod = dmgmod;
        }

        public Bow(int mod, int hitmod, int crtmod, int dmgmod) : base(mod, hitmod, crtmod, dmgmod)
        {
            hit = 75;
            crt = 40;
            hit += hitmod;
            crt += crtmod;
            this.mod = mod;
            this.dmgmod = dmgmod;
        }
    }
}
