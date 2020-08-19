using System;
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

        public Player(int str, int dex, int wis, int con, int exp)
        {
            this.str = str;
            this.dex = dex;
            this.wis = wis;
            this.con = con;
            this.exp = exp;
            level = 1;
            sp = 10;
        }

        public int Str { get => str; set => str = value; }
        public int Dex { get => dex; set => dex = value; }
        public int Wis { get => wis; set => wis = value; }
        public int Con { get => con; set => con = value; }
        public int Exp { get => exp; set => exp = value; }
        public int Level { get => level; set => level = value; }
        public int SP { get => sp; set => sp = value; }
        public int Hp { get => hp; set => hp = value; }


    }
}
