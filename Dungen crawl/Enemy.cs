using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    class Enemy
    {
        private int str;
        private int dex;
        private int wis;
        private int con;
        private int level;
        private int hp;
        private int maxhp;
        private Random rnd;
        private int type;
        private Weapon weapon;

        public Enemy(Player player)
        {
            rnd = new Random();
            if(player.Level < 6)
            {
                type = 1;
            }
            else if(player.Level < 10)
            {
                type = rnd.Next(1, 3);
            }
            else
            {
                type = rnd.Next(1, 4);
            }
            if(type < 3)
            {
                 weapon = new Weapon(rnd.Next(1, 4), rnd.Next(2), rnd.Next(2), rnd.Next(2));
            }
            level = rnd.Next(1, player.Level+1);
            str = rnd.Next(1, level * 10 * type - 5);
            dex = rnd.Next(1, level * 10 * type - 5);
            wis = rnd.Next(1, level * 10 * type - 5);
            con = rnd.Next(1, level * 10 * type - 5);
            hp = 5 * con;
            maxhp = 5 * con;
        }

        public int Str { get => str; set => str = value; }
        public int Dex { get => dex; set => dex = value; }
        public int Wis { get => wis; set => wis = value; }
        public int Con { get => con; set => con = value; }
        public int Level { get => level; private set => level = value; }
        public int Hp { get => hp; private set => hp = value; }
        public int Maxhp { get => maxhp; private set => maxhp = value; }
        public int Type { get => type; private set => type = value; }

        public void CalculateHP(int heal, int dmg)
        {
            maxhp = 5 * con;
            hp = hp + heal - dmg;
            if (hp > maxhp)
            {
                hp = maxhp;
            }
        }
        public int attack()
        {
            if (type < 3)
            {
                if (weapon.Type == 1)
                {
                    return weapon.Dmg(str);
                }
                else if (weapon.Type == 2)
                {
                    return weapon.Dmg(dex);
                }
                else
                {
                    return weapon.Dmg(wis);
                }
            }
            else
            {
                int dragCrit;
                int dragHit;
                int dragAttack;
                int attackType;
                dragAttack = rnd.Next(1, 4);
                if (dragAttack < 3)
                {
                    if(dragAttack == 1)
                    {
                        attackType = str;
                        dragHit = 90;
                        dragCrit = 20;
                    }
                    else
                    {
                        attackType = dex;
                        dragHit = 65;
                        dragCrit = 40;
                    }
                    if (dragHit > rnd.Next(101))
                    {
                        if (dragCrit > rnd.Next(101))
                        {
                            attackType *= 2;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                    return Convert.ToInt32(Math.Round(Convert.ToDouble(attackType) / 2 * Convert.ToDouble(1) + Convert.ToDouble(rnd.Next(5))));
                }
                else
                {
                    return rnd.Next(wis/6,wis/3);
                }
            }
        }
    }
}
