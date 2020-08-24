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
        Weapon equiped = new Weapon(0, 0, 0, 0, 0);
        int target = 0;
        int enemyNumber = 0;
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

        }

        private void NextRoom_Click(object sender, RoutedEventArgs e)
        {
            enemyNumber = 0;
            target = 1;
            Target1.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black);
            EnemyHP1.Text = "";
            EnemyLevel1.Text = "";
            EnemyName1.Text = "";
            EnemyHP2.Text = "";
            EnemyLevel2.Text = "";
            EnemyName2.Text = "";
            EnemyHP3.Text = "";
            EnemyLevel3.Text = "";
            EnemyName3.Text = "";
            int index = 0;
            enemies = combat.NewRoom(player.Level);
            //Next_Room.IsEnabled = false;
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

        }

        private void Bow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Magic_staff_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
