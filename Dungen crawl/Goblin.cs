using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Goblin : Enemy
    {
        public Goblin(int playerLevel) : base(playerLevel)
        {
            type = 1;
            Name = "Goblin";
            str = rnd.Next(3, level * 5 - 1);
            dex = rnd.Next(3, level * 5 - 1);
            wis = rnd.Next(3, level * 5 - 1);
            con = rnd.Next(3, level * 5 - 1);
            hp = hpMod * con;
            maxhp = hpMod * con;
        }
    }
}
