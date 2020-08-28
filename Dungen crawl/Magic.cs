using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    class Magic : Weapon
    {
        public Magic(int hitmod, int crtmod, int dmgmod) : base(hitmod, crtmod, dmgmod)
        {
            mod = 0.75;
            hit = 85;
            crt = 20;
            hit += hitmod;
            crt += crtmod;
            this.dmgmod = dmgmod;
        }

        public Magic(int mod, int hitmod, int crtmod, int dmgmod) : base(mod, hitmod, crtmod, dmgmod)
        {
            this.mod = mod;
            this.dmgmod = dmgmod;
            hit = 85;
            crt = 20;
            hit += hitmod;
            crt += crtmod;
        }
    }
}
