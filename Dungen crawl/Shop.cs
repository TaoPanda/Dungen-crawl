using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Shop
    {
        int gold;
        List<Items> items;

        public int Gold { get => gold; set => gold = value; }
        internal List<Items> Items { get => items; set => items = value; }

        public void GettingGold(int reward)
        {
            Gold += reward;
        }
    }
}
