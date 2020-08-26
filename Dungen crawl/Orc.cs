using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Orc : Enemy
    {
        public Orc(int playerLevel) : base(playerLevel)
        {
            type = 2;
            Name = "Orc";
            str = rnd.Next(5, level * 7 - 2);
            dex = rnd.Next(5, level * 7 - 2);
            wis = rnd.Next(5, level * 7 - 2);
            con = rnd.Next(5, level * 7 - 2);
            hp = hpMod * con;
            maxhp = hpMod * con;
        }
    }
}
