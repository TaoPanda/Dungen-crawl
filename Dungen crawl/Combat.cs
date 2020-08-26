using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    public class Combat
    {
        Random rnd = new Random();
        Player player = new Player();
        List<Enemy> enemies = new List<Enemy>();
        List<Weapon> weapons = new List<Weapon> { new Weapon(1, 0, 0, 0), new Weapon(2, 0, 0, 0), new Weapon(3, 0, 0, 0) };
        Weapon equiped = new Weapon(1, 0, 0, 0);
        int target = 0;
        int enemyNumber = 0;
        int enemysAlive = 0;
        int healUses = 0;
        int enemyType = 0;

        public Player Player { get => player; set => player = value; }
        public List<Enemy> Enemies { get => enemies; set => enemies = value; }
        public List<Weapon> Weapons { get => weapons; set => weapons = value; }
        public Weapon Equiped { get => equiped; set => equiped = value; }
        public int Target { get => target; set => target = value; }
        public int EnemyNumber { get => enemyNumber; set => enemyNumber = value; }
        public int EnemysAlive { get => enemysAlive; set => enemysAlive = value; }
        public int HealUses { get => healUses; set => healUses = value; }

        public void NewRoom()
        {
            enemies = new List<Enemy>();
            int rndNumber = rnd.Next(1000);
            if(rndNumber < 750)
            {
                enemies.Add(RandomEnemy());
            }
            else if(rndNumber < 950)
            {
                enemies.Add(RandomEnemy());
                enemies.Add(RandomEnemy());
            }
            else
            {
                enemies.Add(RandomEnemy());
                enemies.Add(RandomEnemy());
                enemies.Add(RandomEnemy());
            }
        }

        public Enemy RandomEnemy()
        {
            if(player.level < 6)
            {
                return new Goblin(player.level);
            }
            else if(player.level < 10)
            {
                enemyType = rnd.Next(1, 3);
                if (enemyType == 1)
                {
                    return new Goblin(player.level);
                }
                else
                {
                    return new Orc(player.level);
                }
            }
            else
            {
            enemyType = rnd.Next(1, 4);
            if(enemyType == 1)
            {
                return new Goblin(player.level);
            }
            else if(enemyType == 2)
            {
                return new Orc(player.level);
            }
            else
            {
                return new Dragon(player.level);
            }
            }
        }

        public void EquipWeapon(int index)
        {
            equiped = weapons[index];
        }

        public void HealUsesDown()
        {
            healUses--;
        }

        public void HealUsesUp()
        {
            healUses += rnd.Next(0, 2);
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

        public void SkillPointDown()
        {
            player.SP--;
        }

        public void StrengthUp()
        {
            player.Str++;
        }

        public void DexterityUp()
        {
            player.Dex++;
        }

        public void WisdomUp()
        {
            player.Wis++;
        }

        public void ConstitutionUp()
        {
            player.Con++;
            player.Maxhp = 10 * player.Con;
            player.Hp += 10;
        }
    }
}
