using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Enemy
    {
        private int str;
        private int dex;
        private int wis;
        private int con;
        private int level;
        private int hp;
        private int maxhp;
        private int type;
        private string name;
        Random rnd = new Random();
        Weapon weapon;

        public Enemy(int playerLevel)
        {
            if(playerLevel < 6)
            {
                type = 1;
            }
            else if(playerLevel < 10)
            {
                type = rnd.Next(1, 3);

            }
            else
            {
                type = rnd.Next(1, 4);
            }
            if(type < 3)
            {
                 Weapon = new Weapon(rnd.Next(1, 4), rnd.Next(2), rnd.Next(2), rnd.Next(2));
            }
            if(type == 1)
            {
                Name = "Goblin";
            }
            else if(type == 2)
            {
                Name = "Orc";
            }
            else
            {
                Name = "Dragon";
            }
            level = rnd.Next(1, playerLevel+1);
            str = rnd.Next(1 + 3 * (type - 1), level * 8 * type - 3);
            dex = rnd.Next(1 + 3 * (type - 1), level * 8 * type - 3);
            wis = rnd.Next(1 + 3 * (type - 1), level * 8 * type - 3);
            con = rnd.Next(1 + 3 * (type - 1), level * 8 * type - 3);
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
        public string Name { get => name; set => name = value; }
        public Weapon Weapon { get => weapon; set => weapon = value; }

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
