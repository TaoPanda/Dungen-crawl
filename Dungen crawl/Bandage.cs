using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    class Bandage : Consumeble
    {
        public Bandage(int str)
        {
            cost = 15;
            rarety = 1;
            effect = Convert.ToInt32(Math.Round(Convert.ToDouble(str / 5)));
            name = "Bandage";
            description = "A simple bandage that is hard to proberly bind around a wound without a lot of strength";
        }
    }
}
