using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Entity
    {
        public int str;
        public int dex;
        public int wis;
        public int con;
        public int level;
        public int hp;
        public int maxhp;
        public int hpMod;

        public int Str { get => str; set => str = value; }
        public int Dex { get => dex; set => dex = value; }
        public int Wis { get => wis; set => wis = value; }
        public int Con { get => con; set => con = value; }
        public int Level { get => level; set => level = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Maxhp { get => maxhp; set => maxhp = value; }

        public virtual void CalculateHP(int heal, int dmg)
        {
            maxhp = hpMod * con;
            hp = hp + heal - dmg;
            if (hp > maxhp)
            {
                hp = maxhp;
            }
        }

        public virtual int Attack(Weapon weapon)
        {
            if (weapon is Sword)
            {
                return weapon.Dmg(str);
            }
            else if (weapon is Bow)
            {
                return weapon.Dmg(dex);
            }
            else
            {
                return weapon.Dmg(wis);
            }
        }
    }
}
