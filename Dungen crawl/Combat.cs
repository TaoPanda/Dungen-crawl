﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Combat
    {
        private Random rnd = new Random();
        private Enemy enemy;

        public List<Enemy> NewRoom(int playerLevel)
        {
            List<Enemy> enemies = new List<Enemy>();
            int rndNumber = rnd.Next(100);
            if(rndNumber > 600)
            {
                enemy = new Enemy(playerLevel);
                enemies.Add(enemy);
            }
            else if(rndNumber > 900)
            {
                enemy = new Enemy(playerLevel);
                enemies.Add(enemy);
                enemy = new Enemy(playerLevel);
                enemies.Add(enemy);
            }
            else
            {
                enemy = new Enemy(playerLevel);
                enemies.Add(enemy);
                enemy = new Enemy(playerLevel);
                enemies.Add(enemy);
                enemy = new Enemy(playerLevel);
                enemies.Add(enemy);
            }
            return enemies;
        }
    }
}