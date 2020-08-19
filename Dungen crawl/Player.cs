﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    class Player
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
            str = 10;
            dex = 10;
            wis = 10;
            con = 10;
            exp = 0;
            level = 1;
            sp = 10;
            hp = 100;
            levelup = 50;
            maxhp = 100;
        }

        public int Str { get => str; set => str = value; }
        public int Dex { get => dex; set => dex = value; }
        public int Wis { get => wis; set => wis = value; }
        public int Con { get => con; set => con = value; }
        public int SP { get => sp; set => sp = value; }
        public int Exp { get => exp; private set => exp = value; }
        public int Level { get => level; private set => level = value; }
        public int Hp { get => hp; private set => hp = value; }
        public int Levelup { get => levelup; private set => levelup = value; }
        public int Maxhp { get => maxhp; private set => maxhp = value; }

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
                levelup = levelup + Convert.ToInt32(Math.Round(levelup * 0.25));
                sp += 5;
            }
        }
    }
}
