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

        public Enemy(int playerLevel)
        {
            name = "";
            str = 0;
            dex = 0;
            wis = 0;
            con = 0;
            Weapon = new Weapon(rnd.Next(1, 4), rnd.Next(2), rnd.Next(2), rnd.Next(2));
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

        public override int Attack(int type)
        {
            if (Weapon.Type == 1)
            {
                return Weapon.Dmg(str);
            }
            else if (Weapon.Type == 2)
            {
                return Weapon.Dmg(dex);
            }
            else
            {
                return Weapon.Dmg(wis);
            }
        }
    }
}
