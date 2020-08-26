using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Player : Entity
    {
        private int exp;
        private int sp;
        private int levelup;

        public Player()
        {
            str = 15;
            dex = 15;
            wis = 15;
            con = 15;
            exp = 0;
            level = 1;
            sp = 10;
            levelup = 20;
            hpMod = 10;
            hp = hpMod * con;
            maxhp = hpMod * con;
        }

        public int Exp { get => exp; private set => exp = value; }
        public int Levelup { get => levelup; private set => levelup = value; }
        public int SP { get => sp; set => sp = value; }

        public void CalculateExp(int points)
        {
            exp += points;
            if(exp >= levelup)
            {
                level++;
                exp = exp - levelup;
                levelup = levelup + Convert.ToInt32(Math.Round(levelup * 0.4));
                sp += 10;
            }
        }
    }
}
