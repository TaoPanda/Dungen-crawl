using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Player
    {
        private int str;
        private int dex;
        private int wis;
        private int con;
        private int exp;
        private int level;
        private int sp;
        private int hp;
        private int levelup;
        private int maxhp;

        public Player()
        {
            str = 15;
            dex = 15;
            wis = 15;
            con = 15;
            exp = 0;
            level = 1;
            sp = 10;
            hp = 10 * con;
            levelup = 50;
            maxhp = 10 * con;
        }

        public int Str { get => str; set => str = value; }
        public int Dex { get => dex; set => dex = value; }
        public int Wis { get => wis; set => wis = value; }
        public int Con { get => con; set => con = value; }
        public int SP { get => sp; set => sp = value; }
        public int Exp { get => exp; private set => exp = value; }
        public int Level { get => level; private set => level = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Levelup { get => levelup; private set => levelup = value; }
        public int Maxhp { get => maxhp; set => maxhp = value; }

        public void CalculateHP(int heal, int dmg)
        {
            maxhp = 10 * con;
            hp = hp + heal - dmg;
            if(hp > maxhp)
            {
                hp = maxhp;
            }
        }

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

        public int Attack(int type)
        {
            if(type == 1)
            {
                return str;
            }
            else if (type == 2)
            {
                return dex;
            }
            else
            {
                return wis;
            }
        }
    }
}
