using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    class Weapon
    {
        private int type;
        private int mod;
        private int hit;
        private int crt;
        private Random rnd;

        public Weapon(int type, int mod, int hitmod, int crtmod)
        {
            this.type = type;
            this.mod = mod;
            if(type == 1) 
            {
                hit = 95;
                crt = 10;
            }
            else if (type == 2)
            {
                hit = 75;
                crt = 40;
            }
            else if (type == 3)
            {
                hit = 85;
                crt = 20;
            }
            hit += hitmod;
            crt += crtmod;
            rnd = new Random();
        }

        public int Type { get => type; private set => type = value; }
        public int Mod { get => mod; private set => mod = value; }
        public int Hit { get => hit; private set => hit = value; }
        public int Crt { get => crt; private set => crt = value; }

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
                stat = 0;
            }
            return stat * mod + rnd.Next(0,5);
        }
    }
}
