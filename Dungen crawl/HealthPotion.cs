using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    class HealthPotion : Consumeble
    {
        public HealthPotion()
        {
            cost = 25;
            rarety = 1;
            effect = 5;
            name = "Health Potion";
            description = "A red glistening potion that opon consumtion enhance the body's natural regening ability for a short time (effects can vary depending on how fast its consumed).";
        }

        public int CalculateEffect(Player Player)
        {
            effect = Convert.ToInt32(Math.Round(Convert.ToDouble(Player.Dex / 3)));
            return effect;
        }
    }
}

