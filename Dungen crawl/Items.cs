using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Items
    {
        public int cost = 15;
        public string name = "";
        public string description = "";
        public int rarety = 0;

        public int Cost { get => cost; set => cost = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Rarety { get => rarety; set => rarety = value; }
    }
}
