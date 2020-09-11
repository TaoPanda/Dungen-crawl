using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Shop
    {
        int gold;
        List<Items> items;
        Random rnd;
        string shopName;

        public int Gold { get => gold; set => gold = value; }
        public string ShopName { get => shopName; set => shopName = value; }
        internal List<Items> Items { get => items; set => items = value; }

        public void GenerateItemShop()
        {
            shopName = "Gobby's General Goods";
            items = new List<Items>();
            for (int i = 0; i < 9; i++)
            {

            }
        }

        public void GettingGold(int reward)
        {
            Gold += reward;
        }
    }
}
