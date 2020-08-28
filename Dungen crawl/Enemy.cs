using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Enemy : Entity
    {
        public int type;
        public string name;
        public Random rnd = new Random();
        public Weapon weapon;
        int random;


        public Enemy(int playerLevel)
        {
            random = rnd.Next(1, 4);
            name = "";
            str = 0;
            dex = 0;
            wis = 0;
            con = 0;
            if(random == 1)
            {
                weapon = new Sword(rnd.Next(2), rnd.Next(2), rnd.Next(2));
            }
            else if (random == 2)
            {
                weapon = new Bow(rnd.Next(2), rnd.Next(2), rnd.Next(2));
            }
            else
            {
                weapon = new Magic(1, rnd.Next(2), rnd.Next(2), rnd.Next(2));
            }
            level = rnd.Next(1, playerLevel+1);
            hpMod = 5;
            hp = 0;
            maxhp = 0;
        }

        public string Name { get => name; set => name = value; }
        public Weapon Weapon { get => weapon; set => weapon = value; }

        public int GiveExp()
        {
            return 2 * type * level;
        }

    }
}
