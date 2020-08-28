using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Consumeble : Items
    {
        public int uses = 0;
        public int level = 1;
        public int effect;

        public int Uses { get => uses; set => uses = value; }
        public int Level { get => level; set => level = value; }
        public int Effect { get => effect; set => effect = value; }

        public virtual int Gained()
        {
            uses++;
            return effect;
        }

        public virtual void Used()
        {
            uses--;
        }
    }
}
