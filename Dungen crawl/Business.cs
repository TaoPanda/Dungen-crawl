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
        int healUses = 0;

        internal Database Database { get => database; set => database = value; }
        public Highscore Highscore { get => highscore; set => highscore = value; }
        public Player Player { get => player; set => player = value; }
        public Combat Combat { get => combat; set => combat = value; }
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
            Player.Equiped = Player.Weapons[index];
        }
    }
}
