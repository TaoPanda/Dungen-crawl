using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Dungen_crawl
{
    public class Highscore
    {
        Random rnd = new Random();
        string playerName;
        int goblinsKilled = 0;
        int orcsKilled = 0;
        int dragonsKilled = 0;
        int score = 0;

        public Highscore(string playerName, int goblinsKilled, int orcsKilled, int dragonsKilled, int score)
        {
            this.playerName = playerName;
            this.goblinsKilled = goblinsKilled;
            this.orcsKilled = orcsKilled;
            this.dragonsKilled = dragonsKilled;
            this.score = score;
        }

        public string PlayerName { get => playerName; set => playerName = value; }
        public int GoblinsKilled { get => goblinsKilled; set => goblinsKilled = value; }
        public int OrcsKilled { get => orcsKilled; set => orcsKilled = value; }
        public int DragonsKilled { get => dragonsKilled; set => dragonsKilled = value; }
        public int Score { get => score; set => score = value; }

        public void CalculateScore(Enemy enemy)
        {
            int typeMod = 1;
            int lvMod = enemy.level;
            if(enemy is Goblin)
            {
                typeMod = 5;
                goblinsKilled++;
            }
            else if (enemy is Orc)
            {
                typeMod = 25;
                orcsKilled++;
            }
            else if(enemy is Dragon)
            {
                typeMod = 100;
                dragonsKilled++;
            }
            Score += typeMod * lvMod + rnd.Next(0, 10);
        }
    }
}
