using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    class Bandage : Consumeble
    {
        public Bandage()
        {
            cost = 15;
            rarety = 1;
            effect = 5;
            name = "Bandage";
            description = "A simple bandage that is hard to proberly bind around a wound without a lot of strength";
        }

        public int CalculateEffect(Player Player)
        {
            effect = Convert.ToInt32(Math.Round(Convert.ToDouble(Player.Str / 3)));
            return effect;
        }
    }
}
