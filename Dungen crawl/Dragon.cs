using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Dragon : Enemy
    {
        int dragCrit;
        int dragHit;
        int dragAttack;
        int attackType;

        public Dragon(int playerLevel) : base(playerLevel)
        {
            type = 3;
            Name = "Dragon";
            str = rnd.Next(7, level * 9 - 2);
            dex = rnd.Next(7, level * 9 - 2);
            wis = rnd.Next(7, level * 9 - 2);
            con = rnd.Next(7, level * 9 - 2);
            weapon = null;
            hp = hpMod * con;
            maxhp = hpMod * con;
        }

        public override int Attack(Weapon weapon)
        {
            dragAttack = rnd.Next(1, 4);
            if (dragAttack < 3)
            {
                if (dragAttack == 1)
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
                return rnd.Next(wis / 6, wis / 3);
            }
        }
    }
}
