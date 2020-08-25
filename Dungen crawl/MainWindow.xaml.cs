using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dungen_crawl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Combat combat = new Combat();
        Player player = new Player();
        List<Enemy> enemies = new List<Enemy>();
        List<Weapon> weapons = new List<Weapon>();
        Weapon equiped = new Weapon(1, 0, 0, 0, 0);
        int target = 0;
        int enemyNumber = 0;
        int enemysAlive = 0;
        int healUses = 0;
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            Sp.Text = "Sp: " + player.SP;
            Str.Text = "Str: " + player.Str;
            Dex.Text = "Dex: " + player.Dex;
            Wis.Text = "Wis: " + player.Wis;
            Con.Text = "Con: " + player.Con;
            Level.Text = "Lv: " + player.Level;
            Hp.Text = "HP: " + player.Hp + '/' + player.Maxhp;
            EnemyHP1.Text = "";
            EnemyLevel1.Text = "";
            EnemyName1.Text = "";
            EnemyHP2.Text = "";
            EnemyLevel2.Text = "";
            EnemyName2.Text = "";
            EnemyHP3.Text = "";
            EnemyLevel3.Text = "";
            EnemyName3.Text = "";
            weapons.Add(new Weapon(1, 0, 0, 0));
            weapons.Add(new Weapon(2, 0, 0, 0));
            weapons.Add(new Weapon(3, 0, 0, 0));
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            enemies[target - 1].CalculateHP(equiped.Dmg(player.Attack(equiped.Type)));
            foreach (Enemy enemy in enemies)
            {
                index++;
                if (index == 1)
                {
                    if (enemy.Hp > -99999)
                    {
                        EnemyHP1.Text = "HP: " + enemy.Hp + '/' + enemy.Maxhp;
                    }
                }
                else if (index == 2)
                {
                    if (enemy.Hp > -99999)
                    {
                        EnemyHP2.Text = "HP: " + enemy.Hp + '/' + enemy.Maxhp;
                    }
                }
                else
                {
                    if (enemy.Hp > -99999)
                    {
                        EnemyHP3.Text = "HP: " + enemy.Hp + '/' + enemy.Maxhp;
                    }
                }
                if (enemy.Hp > 0)
                {
                    player.CalculateHP(0, enemy.attack());
                    Hp.Text = "HP: " + player.Hp + '/' + player.Maxhp;
                    if (player.Hp < 1)
                    {
                        Sword.IsEnabled = false;
                        Bow.IsEnabled = false;
                        Magic_staff.IsEnabled = false;
                        Switch_weapon.IsEnabled = false;
                        Next_Room.IsEnabled = false;
                        Attack.IsEnabled = false;
                        Switch_target.IsEnabled = false;
                        Heal.IsEnabled = false;
                    }
                }
                else if (enemy.Hp < 1 && enemy.Hp > -99999)
                {
                    player.CalculateExp(enemy.GiveExp());
                    Level.Text = "Lv: " + player.Level;
                    Sp.Text = "Sp: " + player.SP;
                    enemysAlive--;
                    enemy.Hp = -99999999;
                    if(enemysAlive < 1)
                    {
                        EnemyHP1.Text = "";
                        EnemyLevel1.Text = "";
                        EnemyName1.Text = "";
                        EnemyHP2.Text = "";
                        EnemyLevel2.Text = "";
                        EnemyName2.Text = "";
                        EnemyHP3.Text = "";
                        EnemyLevel3.Text = "";
                        EnemyName3.Text = "";
                        Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
                        Target2.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
                        Target3.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
                        Next_Room.IsEnabled = true;
                        Attack.IsEnabled = false;
                        Switch_target.IsEnabled = false;
                        healUses += rnd.Next(0, 2);
                        if (healUses > 0)
                        {
                            Heal.IsEnabled = true;
                        }
                        HealUses.Text = Convert.ToString(healUses);
                    }
                }
            }
        }

        private void NextRoom_Click(object sender, RoutedEventArgs e)
        {
            enemyNumber = 0;
            target = 1;
            Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            int index = 0;
            enemies = combat.NewRoom(player.Level);
            Next_Room.IsEnabled = false;
            Attack.IsEnabled = true;
            foreach(Enemy enemy in enemies)
            {
                enemyNumber++;
                index++;
                if(index == 1)
                {
                    EnemyHP1.Text = "HP: " + enemy.Hp + '/' + enemy.Maxhp;
                    EnemyLevel1.Text = "Lv: " + enemy.Level;
                    EnemyName1.Text = enemy.Name;
                }
                else if (index == 2)
                {
                    EnemyHP2.Text = "HP: " + enemy.Hp + '/' + enemy.Maxhp;
                    EnemyLevel2.Text = "Lv: " + enemy.Level;
                    EnemyName2.Text = enemy.Name;
                }
                else
                {
                    EnemyHP3.Text = "HP: " + enemy.Hp + '/' + enemy.Maxhp;
                    EnemyLevel3.Text = "Lv: " + enemy.Level;
                    EnemyName3.Text = enemy.Name;
                }
            }
            enemysAlive = enemyNumber;
            if (enemyNumber > 1)
            {
                Switch_target.IsEnabled = true;
            }
        }

        private void Str_Click(object sender, RoutedEventArgs e)
        {
            if(player.SP > 0)
            {
                player.SP--;
                player.Str++;
                Sp.Text = "Sp: " + player.SP;
                Str.Text = "Str: " + player.Str;
            }
        }
        private void Dex_Click(object sender, RoutedEventArgs e)
        {
            if (player.SP > 0)
            {
                player.SP--;
                player.Dex++;
                Sp.Text = "Sp: " + player.SP;
                Dex.Text = "Dex: " + player.Dex;
            }
        }
        private void Wis_Click(object sender, RoutedEventArgs e)
        {
            if (player.SP > 0)
            {
                player.SP--;
                player.Wis++;
                Sp.Text = "Sp: " + player.SP;
                Wis.Text = "Wis: " + player.Wis;
            }
        }
        private void Con_Click(object sender, RoutedEventArgs e)
        {
            if (player.SP > 0)
            {
                player.SP--;
                player.Con++;
                Sp.Text = "Sp: " + player.SP;
                Con.Text = "Con: " + player.Con;
                player.Maxhp = 10 * player.Con;
                player.Hp += 10; 
                Hp.Text = "HP: " + player.Hp + '/' + player.Maxhp;
            }
        }

        private void Switch_target_Click(object sender, RoutedEventArgs e)
        {
            target++;
            if(target > enemyNumber)
            {
                target = 1;
            }
            Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
            Target2.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
            Target3.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
            if(target == 1)
            {
                Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            }
            else if (target == 2)
            {
                Target2.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            }
            else if (target == 3)
            {
                Target3.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        private void Sword_Click(object sender, RoutedEventArgs e)
        {
            equiped = weapons[0];
            Switch_weapon.IsEnabled = true;
            if (enemysAlive < 1)
            {
                Next_Room.IsEnabled = true;
            }
            else
            {
                if (enemyNumber > 1)
                {
                    Switch_target.IsEnabled = true;
                }
                Attack.IsEnabled = true;
            }
            if (healUses > 0)
            {
                Heal.IsEnabled = true;
            }
            Sword.IsEnabled = false;
            Bow.IsEnabled = false;
            Magic_staff.IsEnabled = false;
            foreach (Enemy enemy in enemies)
            {
                if (enemy.Hp > 0)
                {
                    player.CalculateHP(0, enemy.attack());
                    Hp.Text = "HP: " + player.Hp + '/' + player.Maxhp;
                    if (player.Hp < 1)
                    {
                        Sword.IsEnabled = false;
                        Bow.IsEnabled = false;
                        Magic_staff.IsEnabled = false;
                        Switch_weapon.IsEnabled = false;
                        Next_Room.IsEnabled = false;
                        Attack.IsEnabled = false;
                        Switch_target.IsEnabled = false;
                        Heal.IsEnabled = false;
                    }
                }
            }
        }

        private void Bow_Click(object sender, RoutedEventArgs e)
        {
            equiped = weapons[1];
            Switch_weapon.IsEnabled = true;
            if (enemysAlive < 1)
            {
                Next_Room.IsEnabled = true;
            }
            else
            {
                if (enemyNumber > 1)
                {
                    Switch_target.IsEnabled = true;
                }
                Attack.IsEnabled = true;
            }
            if (healUses > 0)
            {
                Heal.IsEnabled = true;
            }
            Sword.IsEnabled = false;
            Bow.IsEnabled = false;
            Magic_staff.IsEnabled = false;
            foreach (Enemy enemy in enemies)
            {
                if(enemy.Hp > 0)
                {
                    player.CalculateHP(0, enemy.attack());
                    Hp.Text = "HP: " + player.Hp + '/' + player.Maxhp;
                    if (player.Hp < 1)
                    {
                        Sword.IsEnabled = false;
                        Bow.IsEnabled = false;
                        Magic_staff.IsEnabled = false;
                        Switch_weapon.IsEnabled = false;
                        Next_Room.IsEnabled = false;
                        Attack.IsEnabled = false;
                        Switch_target.IsEnabled = false;
                        Heal.IsEnabled = false;
                    }
                }
            }
        }

        private void Magic_staff_Click(object sender, RoutedEventArgs e)
        {
            equiped = weapons[2];
            Switch_weapon.IsEnabled = true;
            if(enemysAlive < 1)
            {
            Next_Room.IsEnabled = true;
            }
            else
            {
                if (enemyNumber > 1)
                {
                    Switch_target.IsEnabled = true;
                }
                Attack.IsEnabled = true;
            }
            if (healUses > 0)
            {
                Heal.IsEnabled = true;
            }
            Sword.IsEnabled = false;
            Bow.IsEnabled = false;
            Magic_staff.IsEnabled = false;
            foreach (Enemy enemy in enemies)
            {
                if (enemy.Hp > 0)
                {
                    player.CalculateHP(0, enemy.attack());
                    Hp.Text = "HP: " + player.Hp + '/' + player.Maxhp;
                    if (player.Hp < 1)
                    {
                        Sword.IsEnabled = false;
                        Bow.IsEnabled = false;
                        Magic_staff.IsEnabled = false;
                        Switch_weapon.IsEnabled = false;
                        Next_Room.IsEnabled = false;
                        Attack.IsEnabled = false;
                        Switch_target.IsEnabled = false;
                        Heal.IsEnabled = false;
                    }
                }
            }
        }

        private void Switch_weapon_Click(object sender, RoutedEventArgs e)
        {
            Sword.IsEnabled = true;
            Bow.IsEnabled = true;
            Magic_staff.IsEnabled = true;
            Switch_weapon.IsEnabled = false;
            Next_Room.IsEnabled = false;
            Attack.IsEnabled = false;
            Switch_target.IsEnabled = false;
            Heal.IsEnabled = false;
        }

        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            player.CalculateHP(Convert.ToInt32(Math.Round(Convert.ToDouble(player.Wis / 3))), 0);
            Hp.Text = "HP: " + player.Hp + '/' + player.Maxhp;
            healUses--;
            if(healUses < 1)
            {
            Heal.IsEnabled = false;
            }
            HealUses.Text = Convert.ToString(healUses);
        }
    }
}
