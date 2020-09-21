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
        Business business = new Business();
        public MainWindow()
        {
            InitializeComponent();
            Sp.Text = "Sp: " + business.Player.SP;
            Str.Text = "Str: " + business.Player.Str;
            Dex.Text = "Dex: " + business.Player.Dex;
            Wis.Text = "Wis: " + business.Player.Wis;
            Con.Text = "Con: " + business.Player.Con;
            Level.Text = "Lv: " + business.Player.Level;
            Hp.Text = "HP: " + business.Player.Hp + '/' + business.Player.Maxhp;
            EnemyHP1.Visibility = Visibility.Hidden;
            EnemyLevel1.Visibility = Visibility.Hidden;
            EnemyName1.Visibility = Visibility.Hidden;
            EnemyHP2.Visibility = Visibility.Hidden;
            EnemyLevel2.Visibility = Visibility.Hidden;
            EnemyName2.Visibility = Visibility.Hidden;
            EnemyHP3.Visibility = Visibility.Hidden;
            EnemyLevel3.Visibility = Visibility.Hidden;
            EnemyName3.Visibility = Visibility.Hidden;
            PlayerName_grid.Visibility = Visibility.Visible;
            Start_grid.Visibility = Visibility.Hidden;
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            business.Combat.Enemies[business.Combat.Target - 1].CalculateHP(0, business.Player.Equiped.Dmg(business.Player.Attack(business.Player.Equiped)));
            int index = 0;
            foreach (Enemy enemy in business.Combat.Enemies)
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
                    business.Player.CalculateHP(0, enemy.Attack(enemy.Weapon));
                    Hp.Text = "HP: " + business.Player.Hp + '/' + business.Player.Maxhp;
                    if (business.Player.Hp < 1)
                    {
                        Sword_btn.IsEnabled = false;
                        Bow_btn.IsEnabled = false;
                        Magic_staff_btn.IsEnabled = false;
                        Switch_weapon_btn.IsEnabled = false;
                        Next_Room_btn.IsEnabled = false;
                        Attack_btn.IsEnabled = false;
                        Switch_target_btn.IsEnabled = false;
                        Heal_btn.IsEnabled = false;
                    }
                }
                else if (enemy.Hp < 1 && enemy.Hp > -99999)
                {
                    business.Highscore.CalculateScore(enemy);
                    business.Player.CalculateExp(enemy.GiveExp());
                    Level.Text = "Lv: " + business.Player.Level;
                    Sp.Text = "Sp: " + business.Player.SP;
                    business.Combat.EnemyKilled();
                    enemy.Hp = -99999999;
                    if(business.Combat.EnemysAlive < 1)
                    {
                        EnemyHP1.Visibility = Visibility.Hidden;
                        EnemyLevel1.Visibility = Visibility.Hidden;
                        EnemyName1.Visibility = Visibility.Hidden;
                        EnemyHP2.Visibility = Visibility.Hidden;
                        EnemyLevel2.Visibility = Visibility.Hidden;
                        EnemyName2.Visibility = Visibility.Hidden;
                        EnemyHP3.Visibility = Visibility.Hidden;
                        EnemyLevel3.Visibility = Visibility.Hidden;
                        EnemyName3.Visibility = Visibility.Hidden;
                        Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
                        Target2.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
                        Target3.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
                        Next_Room_btn.Visibility = Visibility.Visible;
                        Attack_btn.Visibility = Visibility.Hidden;
                        Switch_target_btn.Visibility = Visibility.Hidden;
                        business.HealUsesUp();
                        if (business.HealUses > 0)
                        {
                            Heal_btn.IsEnabled = true;
                        }
                        HealUses.Text = Convert.ToString(business.HealUses);
                    }
                }
            }
        }

        private void NextRoom_Click(object sender, RoutedEventArgs e)
        {
            business.Combat.EncounterReset();
            business.Combat.NewRoom(business.Player.Level);
            Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            int index = 0;
            Next_Room_btn.Visibility = Visibility.Hidden;
            Attack_btn.Visibility = Visibility.Visible;
            foreach(Enemy enemy in business.Combat.Enemies)
            {
                business.Combat.EnemyAppear();
                index++;
                if(index == 1)
                {
                    EnemyHP1.Text = "HP: " + enemy.Hp + '/' + enemy.Maxhp;
                    EnemyLevel1.Text = "Lv: " + enemy.Level;
                    EnemyName1.Text = enemy.Name;
                    EnemyHP1.Visibility = Visibility.Visible;
                    EnemyLevel1.Visibility = Visibility.Visible;
                    EnemyName1.Visibility = Visibility.Visible;
                }
                else if (index == 2)
                {
                    EnemyHP2.Text = "HP: " + enemy.Hp + '/' + enemy.Maxhp;
                    EnemyLevel2.Text = "Lv: " + enemy.Level;
                    EnemyName2.Text = enemy.Name;
                    EnemyHP2.Visibility = Visibility.Visible;
                    EnemyLevel2.Visibility = Visibility.Visible;
                    EnemyName2.Visibility = Visibility.Visible;
                }
                else
                {
                    EnemyHP3.Text = "HP: " + enemy.Hp + '/' + enemy.Maxhp;
                    EnemyLevel3.Text = "Lv: " + enemy.Level;
                    EnemyName3.Text = enemy.Name;
                    EnemyHP3.Visibility = Visibility.Visible;
                    EnemyLevel3.Visibility = Visibility.Visible;
                    EnemyName3.Visibility = Visibility.Visible;
                }
            }
            if (business.Combat.EnemysAlive > 1)
            {
                Switch_target_btn.Visibility = Visibility.Visible;
            }
        }

        private void Str_Click(object sender, RoutedEventArgs e)
        {
            if(business.Player.SP > 0)
            {
                business.SkillPointDown();
                business.StrengthUp();
                Sp.Text = "Sp: " + business.Player.SP;
                Str.Text = "Str: " + business.Player.Str;
            }
        }
        private void Dex_Click(object sender, RoutedEventArgs e)
        {
            if (business.Player.SP > 0)
            {
                business.SkillPointDown();
                business.DexterityUp();
                Sp.Text = "Sp: " + business.Player.SP;
                Dex.Text = "Dex: " + business.Player.Dex;
            }
        }
        private void Wis_Click(object sender, RoutedEventArgs e)
        {
            if (business.Player.SP > 0)
            {
                business.SkillPointDown();
                business.WisdomUp();
                Sp.Text = "Sp: " + business.Player.SP;
                Wis.Text = "Wis: " + business.Player.Wis;
            }
        }
        private void Con_Click(object sender, RoutedEventArgs e)
        {
            if (business.Player.SP > 0)
            {
                business.SkillPointDown();
                business.ConstitutionUp();
                Sp.Text = "Sp: " + business.Player.SP;
                Con.Text = "Con: " + business.Player.Con;
                Hp.Text = "HP: " + business.Player.Hp + '/' + business.Player.Maxhp;
            }
        }

        private void Switch_target_Click(object sender, RoutedEventArgs e)
        {
            business.Combat.NextTarget();
            Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
            Target2.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
            Target3.Stroke = new SolidColorBrush(System.Windows.Media.Colors.White);
            if(business.Combat.Target == 1)
            {
                Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            }
            else if (business.Combat.Target == 2)
            {
                Target2.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            }
            else if (business.Combat.Target == 3)
            {
                Target3.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        private void Sword_Click(object sender, RoutedEventArgs e)
        {
            business.EquipWeapon(0);
            Switch_weapon_btn.Visibility = Visibility.Visible;
            if (business.Combat.EnemysAlive < 1)
            {
                Next_Room_btn.Visibility = Visibility.Visible;
            }
            else
            {
                if (business.Combat.EnemyNumber > 1)
                {
                    Switch_target_btn.Visibility = Visibility.Visible;
                }
                Attack_btn.Visibility = Visibility.Visible;
            }
            if (business.HealUses > 0)
            {
                Heal_btn.IsEnabled = true;
            }
            Sword_btn.Visibility = Visibility.Hidden;
            Bow_btn.Visibility = Visibility.Hidden;
            Magic_staff_btn.Visibility = Visibility.Hidden;
            foreach (Enemy enemy in business.Combat.Enemies)
            {
                if (enemy.Hp > 0)
                {
                    business.Player.CalculateHP(0, enemy.Attack(enemy.Weapon));
                    Hp.Text = "HP: " + business.Player.Hp + '/' + business.Player.Maxhp;
                    if (business.Player.Hp < 1)
                    {
                        Sword_btn.IsEnabled = false;
                        Bow_btn.IsEnabled = false;
                        Magic_staff_btn.IsEnabled = false;
                        Switch_weapon_btn.IsEnabled = false;
                        Next_Room_btn.IsEnabled = false;
                        Attack_btn.IsEnabled = false;
                        Switch_target_btn.IsEnabled = false;
                        Heal_btn.IsEnabled = false;
                    }
                }
            }
        }

        private void Bow_Click(object sender, RoutedEventArgs e)
        {
            business.EquipWeapon(1);
            Switch_weapon_btn.Visibility = Visibility.Visible;
            if (business.Combat.EnemysAlive < 1)
            {
                Next_Room_btn.Visibility = Visibility.Visible;
            }
            else
            {
                if (business.Combat.EnemyNumber > 1)
                {
                    Switch_target_btn.Visibility = Visibility.Visible;
                }
                Attack_btn.Visibility = Visibility.Visible;
            }
            if (business.HealUses > 0)
            {
                Heal_btn.IsEnabled = true;
            }
            Sword_btn.Visibility = Visibility.Hidden;
            Bow_btn.Visibility = Visibility.Hidden;
            Magic_staff_btn.Visibility = Visibility.Hidden;
            foreach (Enemy enemy in business.Combat.Enemies)
            {
                if(enemy.Hp > 0)
                {
                    business.Player.CalculateHP(0, enemy.Attack(enemy.Weapon));
                    Hp.Text = "HP: " + business.Player.Hp + '/' + business.Player.Maxhp;
                    if (business.Player.Hp < 1)
                    {
                        Sword_btn.IsEnabled = false;
                        Bow_btn.IsEnabled = false;
                        Magic_staff_btn.IsEnabled = false;
                        Switch_weapon_btn.IsEnabled = false;
                        Next_Room_btn.IsEnabled = false;
                        Attack_btn.IsEnabled = false;
                        Switch_target_btn.IsEnabled = false;
                        Heal_btn.IsEnabled = false;
                    }
                }
            }
        }

        private void Magic_staff_Click(object sender, RoutedEventArgs e)
        {
            business.EquipWeapon(2);
            Switch_weapon_btn.Visibility = Visibility.Visible;
            if(business.Combat.EnemysAlive < 1)
            {
                Next_Room_btn.Visibility = Visibility.Visible;
            }
            else
            {
                if (business.Combat.EnemyNumber > 1)
                {
                    Switch_target_btn.Visibility = Visibility.Visible;
                }
                Attack_btn.Visibility = Visibility.Visible;
            }
            if (business.HealUses > 0)
            {
                Heal_btn.IsEnabled = true;
            }
            Sword_btn.Visibility = Visibility.Hidden;
            Bow_btn.Visibility = Visibility.Hidden;
            Magic_staff_btn.Visibility = Visibility.Hidden;
            foreach (Enemy enemy in business.Combat.Enemies)
            {
                if (enemy.Hp > 0)
                {
                    business.Player.CalculateHP(0, enemy.Attack(enemy.Weapon));
                    Hp.Text = "HP: " + business.Player.Hp + '/' + business.Player.Maxhp;
                    if (business.Player.Hp < 1)
                    {
                        Sword_btn.IsEnabled = false;
                        Bow_btn.IsEnabled = false;
                        Magic_staff_btn.IsEnabled = false;
                        Switch_weapon_btn.IsEnabled = false;
                        Next_Room_btn.IsEnabled = false;
                        Attack_btn.IsEnabled = false;
                        Switch_target_btn.IsEnabled = false;
                        Heal_btn.IsEnabled = false;
                    }
                }
            }
        }

        private void Switch_weapon_Click(object sender, RoutedEventArgs e)
        {
            Sword_btn.Visibility = Visibility.Visible;
            Bow_btn.Visibility = Visibility.Visible;
            Magic_staff_btn.Visibility = Visibility.Visible;
            Switch_weapon_btn.Visibility = Visibility.Hidden;
            Next_Room_btn.Visibility = Visibility.Hidden;
            Attack_btn.Visibility = Visibility.Hidden;
            Switch_target_btn.Visibility = Visibility.Hidden;
            Heal_btn.IsEnabled = false;
        }

        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            business.Player.CalculateHP(Convert.ToInt32(Math.Round(Convert.ToDouble(business.Player.Wis / 3))), 0);
            Hp.Text = "HP: " + business.Player.Hp + '/' + business.Player.Maxhp;
            business.HealUsesDown();
            if(business.HealUses < 1)
            {
                Heal_btn.IsEnabled = false;
            }
            HealUses.Text = Convert.ToString(business.HealUses);
        }

        private void Enter_btn_Click(object sender, RoutedEventArgs e)
        {
            WrongCharacter_warning.Foreground = Brushes.Black;
            NoCharacter_warning.Foreground = Brushes.Black;
            MaxCharacter_warning.Foreground = Brushes.Black; 
            string playerName = PlayerName_input.Text;
            if(playerName.Length > 10)
            {
                MaxCharacter_warning.Foreground = Brushes.Red;
            }
            if(playerName.Length == 0)
            {
                NoCharacter_warning.Foreground = Brushes.Red;
            }
            for(int i = 0; i < playerName.Length; i++)
            {
                char[] characters = playerName.ToCharArray();
                if(characters[i] == ' ' || Convert.ToString(characters[i]) == "'")
                {
                    WrongCharacter_warning.Foreground = Brushes.Red;
                }
            }
            if(WrongCharacter_warning.Foreground == Brushes.Black && NoCharacter_warning.Foreground == Brushes.Black && MaxCharacter_warning.Foreground == Brushes.Black)
            {
                PlayerName_grid.Visibility = Visibility.Hidden;
                business.Highscore.PlayerName = playerName;
                Start_grid.Visibility = Visibility.Visible;
                PlayerName.Text = playerName;
            }
            else
            {
                TryAgain_txtbox.Visibility = Visibility.Visible;
            }
        }

        private void InventoryOpen_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InventoryClose_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ArrowDown_img_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ArrowUp_img_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
