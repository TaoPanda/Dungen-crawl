using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    class HealthPotion : Consumeble
    {
        public HealthPotion(int dex)
        {
            cost = 25;
            rarety = 1;
            effect = Convert.ToInt32(Math.Round(Convert.ToDouble(dex / 3)));
            name = "Health Potion";
            description = "A red glistening potion that opon consumtion enhance the body's natural regening ability for a short time (effects can vary depending on how fast its consumed).";
        }
    }
}

