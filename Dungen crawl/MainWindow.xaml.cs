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
        public MainWindow()
        {
            InitializeComponent();
            Sp.Text = "Sp: " + combat.Player.SP;
            Str.Text = "Str: " + combat.Player.Str;
            Dex.Text = "Dex: " + combat.Player.Dex;
            Wis.Text = "Wis: " + combat.Player.Wis;
            Con.Text = "Con: " + combat.Player.Con;
            Level.Text = "Lv: " + combat.Player.Level;
            Hp.Text = "HP: " + combat.Player.Hp + '/' + combat.Player.Maxhp;
            EnemyHP1.Text = "";
            EnemyLevel1.Text = "";
            EnemyName1.Text = "";
            EnemyHP2.Text = "";
            EnemyLevel2.Text = "";
            EnemyName2.Text = "";
            EnemyHP3.Text = "";
            EnemyLevel3.Text = "";
            EnemyName3.Text = "";
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            combat.Enemies[combat.Target - 1].CalculateHP(0, combat.Equiped.Dmg(combat.Player.Attack(combat.Equiped.Type)));
            int index = 0;
            foreach (Enemy enemy in combat.Enemies)
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
                    combat.Player.CalculateHP(0, enemy.Attack(0));
                    Hp.Text = "HP: " + combat.Player.Hp + '/' + combat.Player.Maxhp;
                    if (combat.Player.Hp < 1)
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
                    combat.Player.CalculateExp(enemy.GiveExp());
                    Level.Text = "Lv: " + combat.Player.Level;
                    Sp.Text = "Sp: " + combat.Player.SP;
                    combat.EnemyKilled();
                    enemy.Hp = -99999999;
                    if(combat.EnemysAlive < 1)
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
                        combat.HealUsesUp();
                        if (combat.HealUses > 0)
                        {
                            Heal.IsEnabled = true;
                        }
                        HealUses.Text = Convert.ToString(combat.HealUses);
                    }
                }
            }
        }

        private void NextRoom_Click(object sender, RoutedEventArgs e)
        {
            combat.EncounterReset();
            combat.NewRoom();
            Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            int index = 0;
            Next_Room.IsEnabled = false;
            Attack.IsEnabled = true;
            foreach(Enemy enemy in combat.Enemies)
            {
                combat.EnemyAppear();
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
            if (combat.EnemysAlive > 1)
            {
                Switch_target.IsEnabled = true;
            }
        }

        private void Str_Click(object sender, RoutedEventArgs e)
        {
            if(combat.Player.SP > 0)
            {
                combat.SkillPointDown();
                combat.StrengthUp();
                Sp.Text = "Sp: " + combat.Player.SP;
                Str.Text = "Str: " + combat.Player.Str;
            }
        }
        private void Dex_Click(object sender, RoutedEventArgs e)
        {
            if (combat.Player.SP > 0)
            {
                combat.SkillPointDown();
                combat.DexterityUp();
                Sp.Text = "Sp: " + combat.Player.SP;
                Dex.Text = "Dex: " + combat.Player.Dex;
            }
        }
        private void Wis_Click(object sender, RoutedEventArgs e)
        {
            if (combat.Player.SP > 0)
            {
                combat.SkillPointDown();
                combat.WisdomUp();
                Sp.Text = "Sp: " + combat.Player.SP;
                Wis.Text = "Wis: " + combat.Player.Wis;
            }
        }
        private void Con_Click(object sender, RoutedEventArgs e)
        {
            if (combat.Player.SP > 0)
            {
                combat.SkillPointDown();
                combat.ConstitutionUp();
                Sp.Text = "Sp: " + combat.Player.SP;
                Con.Text = "Con: " + combat.Player.Con;
                Hp.Text = "HP: " + combat.Player.Hp + '/' + combat.Player.Maxhp;
            }
        }

        private void Switch_target_Click(object sender, RoutedEventArgs e)
        {
            combat.NextTarget();
            Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
            Target2.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
            Target3.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
            if(combat.Target == 1)
            {
                Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            }
            else if (combat.Target == 2)
            {
                Target2.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            }
            else if (combat.Target == 3)
            {
                Target3.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        private void Sword_Click(object sender, RoutedEventArgs e)
        {
            combat.EquipWeapon(0);
            Switch_weapon.IsEnabled = true;
            if (combat.EnemysAlive < 1)
            {
                Next_Room.IsEnabled = true;
            }
            else
            {
                if (combat.EnemyNumber > 1)
                {
                    Switch_target.IsEnabled = true;
                }
                Attack.IsEnabled = true;
            }
            if (combat.HealUses > 0)
            {
                Heal.IsEnabled = true;
            }
            Sword.IsEnabled = false;
            Bow.IsEnabled = false;
            Magic_staff.IsEnabled = false;
            foreach (Enemy enemy in combat.Enemies)
            {
                if (enemy.Hp > 0)
                {
                    combat.Player.CalculateHP(0, enemy.Attack(0));
                    Hp.Text = "HP: " + combat.Player.Hp + '/' + combat.Player.Maxhp;
                    if (combat.Player.Hp < 1)
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
            combat.EquipWeapon(1);
            Switch_weapon.IsEnabled = true;
            if (combat.EnemysAlive < 1)
            {
                Next_Room.IsEnabled = true;
            }
            else
            {
                if (combat.EnemyNumber > 1)
                {
                    Switch_target.IsEnabled = true;
                }
                Attack.IsEnabled = true;
            }
            if (combat.HealUses > 0)
            {
                Heal.IsEnabled = true;
            }
            Sword.IsEnabled = false;
            Bow.IsEnabled = false;
            Magic_staff.IsEnabled = false;
            foreach (Enemy enemy in combat.Enemies)
            {
                if(enemy.Hp > 0)
                {
                    combat.Player.CalculateHP(0, enemy.Attack(0));
                    Hp.Text = "HP: " + combat.Player.Hp + '/' + combat.Player.Maxhp;
                    if (combat.Player.Hp < 1)
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
            combat.EquipWeapon(2);
            Switch_weapon.IsEnabled = true;
            if(combat.EnemysAlive < 1)
            {
            Next_Room.IsEnabled = true;
            }
            else
            {
                if (combat.EnemyNumber > 1)
                {
                    Switch_target.IsEnabled = true;
                }
                Attack.IsEnabled = true;
            }
            if (combat.HealUses > 0)
            {
                Heal.IsEnabled = true;
            }
            Sword.IsEnabled = false;
            Bow.IsEnabled = false;
            Magic_staff.IsEnabled = false;
            foreach (Enemy enemy in combat.Enemies)
            {
                if (enemy.Hp > 0)
                {
                    combat.Player.CalculateHP(0, enemy.Attack(0));
                    Hp.Text = "HP: " + combat.Player.Hp + '/' + combat.Player.Maxhp;
                    if (combat.Player.Hp < 1)
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
            combat.Player.CalculateHP(Convert.ToInt32(Math.Round(Convert.ToDouble(combat.Player.Wis / 3))), 0);
            Hp.Text = "HP: " + combat.Player.Hp + '/' + combat.Player.Maxhp;
            combat.HealUsesDown();
            if(combat.HealUses < 1)
            {
            Heal.IsEnabled = false;
            }
            HealUses.Text = Convert.ToString(combat.HealUses);
        }
    }
}
