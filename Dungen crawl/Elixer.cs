using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Elixer : Consumeble
    {
        public Elixer()
        {
            cost = 200;
            rarety = 5;
            effect = 100;
            name = "Elixer";
            description = "A blue glistening potion that opon consumtion enhance the knowledge of one self. (its an exp potion)";
        }
    }
}
