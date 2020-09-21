using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Combat
    {
        Random rnd = new Random();
        List<Enemy> enemies = new List<Enemy>();
        int target = 0;
        int enemyNumber = 0;
        int enemysAlive = 0;
        int enemyType = 0;

        public List<Enemy> Enemies { get => enemies; set => enemies = value; }
        public int Target { get => target; set => target = value; }
        public int EnemyNumber { get => enemyNumber; set => enemyNumber = value; }
        public int EnemysAlive { get => enemysAlive; set => enemysAlive = value; }

        public void NewRoom(int playerLV)
        {
            enemies = new List<Enemy>();
            int rndNumber = rnd.Next(1000);
            if(rndNumber < 750)
            {
                enemies.Add(RandomEnemy(playerLV));
            }
            else if(rndNumber < 950)
            {
                enemies.Add(RandomEnemy(playerLV));
                enemies.Add(RandomEnemy(playerLV));
            }
            else
            {
                enemies.Add(RandomEnemy(playerLV));
                enemies.Add(RandomEnemy(playerLV));
                enemies.Add(RandomEnemy(playerLV));
            }
        }

        public Enemy RandomEnemy(int playerLV)
        {
            if(playerLV < 6)
            {
                return new Goblin(playerLV);
            }
            else if(playerLV < 10)
            {
                enemyType = rnd.Next(1, 3);
                if (enemyType == 1)
                {
                    return new Goblin(playerLV);
                }
                else
                {
                    return new Orc(playerLV);
                }
            }
            else
            {
            enemyType = rnd.Next(1, 4);
            if(enemyType == 1)
            {
                return new Goblin(playerLV);
            }
            else if(enemyType == 2)
            {
                return new Orc(playerLV);
            }
            else
            {
                return new Dragon(playerLV);
            }
            }
        }

        public void EncounterReset()
        {
            enemyNumber = 0;
            target = 1;
        }

        public void EnemyKilled()
        {
            enemysAlive--;
        }

        public void EnemyAppear()
        {
            enemysAlive++;
            enemyNumber++;
        }

        public void NextTarget()
        {
            target++;
            if (target > enemyNumber)
            {
                target = 1;
            }
        }
    }
}
