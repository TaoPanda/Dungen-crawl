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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextRoom_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            enemies = combat.NewRoom(player.Level);
            foreach(Enemy enemy in enemies)
            {
                index++;
                if(index == 1)
                {
                    EnemyHP1.Text = "HP: " + enemy.Hp + '/' + enemy.Maxhp;
                    EnemyLevel1.Text = "Lv: " + enemy.Level;
                    EnemyName1.Text = enemy.Name;
                    
                }
            }
        }
    }
}
