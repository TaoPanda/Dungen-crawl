using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Weapon : Items
    {
        public double mod;
        public int hit;
        public int crt;
        public int dmgmod;
        public Random rnd = new Random();

        public Weapon(int mod, int hitmod, int crtmod, int dmgmod)
        {
            this.mod = mod;
            this.dmgmod = dmgmod;
            hit += hitmod;
            crt += crtmod;
        }
        public Weapon(int hitmod, int crtmod, int dmgmod)
        {
            this.mod = 1;
            this.Dmgmod = dmgmod;
            hit += hitmod;
            crt += crtmod;
        }

        public double Mod { get => mod; private set => mod = value; }
        public int Hit { get => hit; private set => hit = value; }
        public int Crt { get => crt; private set => crt = value; }
        public int Dmgmod { get => dmgmod; private set => dmgmod = value; }

        public int Dmg(int stat)
        {
            if (hit > rnd.Next(101))
            {
                if(crt > rnd.Next(101))
                {
                    stat *= 2;
                }
            }
            else
            {
                return 0;
            }
            return Convert.ToInt32(Math.Round(Convert.ToDouble(stat) / 2 * Convert.ToDouble(mod) + Convert.ToDouble(Dmgmod)));
        }
    }
}
