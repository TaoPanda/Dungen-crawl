using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl
{
    class Business
    {
        Random rnd = new Random();
        Database database = new Database();
        Highscore highscore = new Highscore("PlayerName", 0, 0, 0, 0);
        Player player = new Player();
        Combat combat = new Combat();
        List<Items> inventoryShow = new List<Items>();
        int bandages = 0;
        int healthPotions = 0;
        int elixers = 0;
        int inventorystart = 0;
        int healUses = 0;

        internal Database Database { get => database; set => database = value; }
        public Highscore Highscore { get => highscore; set => highscore = value; }
        public Player Player { get => player; set => player = value; }
        public Combat Combat { get => combat; set => combat = value; }
        public List<Items> InventoryShow { get => inventoryShow; set => inventoryShow = value; }
        public int Bandages { get => bandages; set => bandages = value; }
        public int HealthPotions { get => healthPotions; set => healthPotions = value; }
        public int Elixers { get => elixers; set => elixers = value; }
        public int Inventorystart { get => inventorystart; set => inventorystart = value; }
        public int HealUses { get => healUses; set => healUses = value; }

        public void HealUsesDown()
        {
            healUses--;
        }

        public void HealUsesUp()
        {
            healUses += rnd.Next(0, 2);
        }

        public void SkillPointDown()
        {
            Player.SP--;
        }

        public void StrengthUp()
        {
            Player.Str++;
        }

        public void DexterityUp()
        {
            Player.Dex++;
        }

        public void WisdomUp()
        {
            Player.Wis++;
        }

        public void ConstitutionUp()
        {
            Player.Con++;
            Player.Maxhp = 10 * Player.Con;
            Player.Hp += 10;
        }

        public void EquipWeapon(int index)
        {
            Player.Equiped = (Weapon)Player.Inventory[index];
        }

        public void BuildInventory()
        {
            inventoryShow = new List<Items>();
            bandages = 0;
            healthPotions = 0;
            elixers = 0;
            foreach (Items item in player.Inventory)
            {
                if(item is Weapon)
                {
                    inventoryShow.Add(item);
                }
                else if(item is Bandage)
                {
                    if(bandages < 1)
                    {
                        inventoryShow.Add(item);
                    }
                    bandages++;
                }
                else if (item is HealthPotion)
                {
                    if (healthPotions < 1)
                    {
                        inventoryShow.Add(item);
                    }
                    healthPotions++;
                }
                else if (item is Elixer)
                {
                    if (elixers < 1)
                    {
                        inventoryShow.Add(item);
                    }
                    elixers++;
                }
            }
        }
    }
}
