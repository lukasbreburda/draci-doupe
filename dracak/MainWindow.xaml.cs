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

namespace dracak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        player p1 = new player();
        enemy e1 = new enemy();
        enemy e2 = new enemy();
        enemy e3 = new enemy();
        enemy e4 = new enemy();
        enemy e5 = new enemy();
        enemy e6 = new enemy();
        int rr;
        int atack;
        int defense;
        int level;
        public MainWindow()
        {  InitializeComponent();

            hiden();
            welcome.Visibility = Visibility.Visible;
            textname.Visibility = Visibility.Visible;
            s_button.Visibility = Visibility.Visible;
            welcome.Text = "Vítej ve hře dračák, tvým úkolem je nejdříve se vycvičit na dostatečnou úroven, aby si se mohl vydat za drakem, kterého poté musíš zabít. setkáš se s ním, až tvoje síla dosáhne 100%, ale nesmíš při trénigu zemří. Nejprve zadej název svého hrdiny a stiskni tlačítko dále. ";
           

        }

        private void s_button_Click(object sender, RoutedEventArgs e)
        {
            hiden();

            h_bar.Visibility = Visibility.Visible;
            f_bar.Visibility = Visibility.Visible;
            d_bar.Visibility = Visibility.Visible;
            name.Visibility = Visibility.Visible;
            h.Visibility = Visibility.Visible;
            f.Visibility = Visibility.Visible;
            d.Visibility = Visibility.Visible;
            

            dev_but.Visibility = Visibility.Visible;
            fight_but.Visibility = Visibility.Visible;
            image.Visibility = Visibility.Visible;
            textenemy.Visibility = Visibility.Visible;
            p_enemy.Visibility = Visibility.Visible;

          


           
            p1.name = "Tvůj nickname: " + textname.Text;
            p1.healt = 100;
            p1.level = 1;
            p1.dev = 0;
            p1.fight = 1;

            h_bar.Maximum = 100;
            f_bar.Maximum = 100;
            d_bar.Maximum = 100;

            h_bar.Value = p1.healt;
            f_bar.Value = p1.fight;
            d_bar.Value = p1.dev;
            name.Content = p1.name;


            enemys();

        }

        private void fight_but_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int uu = rnd.Next(1, 10);
            int at = uu + 1 + p1.fight ;
            int tt;
            if (defense > at)
            {
             tt = 0;
            }
             tt = at - defense;
            if (tt > 0)
            {
                p_enemy.Value = p_enemy.Value - tt;
            }
           
            int kk = rnd.Next(0, 3);
            int tr = atack - kk;
            int xx;
            if (p1.dev > tr)
            {
                xx = 0;
            }
            xx = tr - p1.dev;

            h_bar.Value = h_bar.Value - xx;
            if (h_bar.Value <= 0)
            {
                hiden();

                end.Visibility = Visibility.Visible;
                exit.Visibility = Visibility.Visible;
            }
            if (p_enemy.Value <= 0)
            {
                enemys();
                p1.dev = p1.dev + level;
                p1.fight = p1.fight + (level * 3 );
                h_bar.Value = p1.healt;
                f_bar.Value = p1.fight;
                d_bar.Value = p1.dev;
                atack = atack + level +5;
                defense = defense + (level * 2);
                p_enemy.Maximum = (p_enemy.Maximum * 2);
                p_enemy.Value = (p_enemy.Value * 2);

                
            }
            if (p1.fight >= 100)
            {
                hiden();
            }
        }

        private void dev_but_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int hel = rnd.Next(0, 10);
            int del = hel / 4;

            p_enemy.Value = p_enemy.Value + del;
            h_bar.Value = h_bar.Value + hel;
        }
        public void hiden()
        {
            h_bar.Visibility = Visibility.Hidden;
            f_bar.Visibility = Visibility.Hidden;
            d_bar.Visibility = Visibility.Hidden;
            name.Visibility = Visibility.Hidden;
            h.Visibility = Visibility.Hidden;
            f.Visibility = Visibility.Hidden;
            d.Visibility = Visibility.Hidden;
            dev_but.Visibility = Visibility.Hidden;
            fight_but.Visibility = Visibility.Hidden;
            image.Visibility = Visibility.Hidden;
            textenemy.Visibility = Visibility.Hidden;
            p_enemy.Visibility = Visibility.Hidden;
            textname.Visibility = Visibility.Hidden;
            welcome.Visibility = Visibility.Hidden;
            ssss.Visibility = Visibility.Hidden;
            s_button.Visibility = Visibility.Hidden;
            end.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;

        }
        public void enemys()
        {
            e1.name = "Vlk";
            e1.healt = 20;
            e1.level = 1;
            e1.fig = 10;
            e1.dev = 5;
            e1.lore = "Během svého trenování si narazil na Vlka. Rychle se ho zbav!!";

            e2.name = "Medvěd";
            e2.healt = 30;
            e2.level = 2;
            e2.fig = 10;
            e2.dev = 3;
            e2.lore = "Během svého trenování si narazil na Medvěda. Rychle se ho zbav!!";

            e3.name = "Lev";
            e3.healt = 35;
            e3.level = 2;
            e3.fig = 10;
            e3.dev = 4;
            e3.lore = "Během svého trenování si narazil na Lva. Rychle se ho zbav!!";

            e4.name = "Trpaslík";
            e4.healt = 12;
            e4.level = 1;
            e4.fig = 15;
            e4.dev = 1;
            e4.lore = "Během svého trenování si narazil na zákeřného trpaslíka. Rychle se ho zbav!!";

            e5.name = "Kočvara";
            e5.healt = 40;
            e5.level = 3;
            e5.fig = 10;
            e5.dev = 6;
            e5.lore = "Během svého trenování si narazil na anime Kočvaru. Rychle se ho zbav, ale pozor je velmi zákeřný!!";

            e6.name = "Had";
            e6.healt = 10;
            e6.level = 2;
            e6.fig = 15;
            e6.dev = 5;
            e6.lore = "Během svého trenování si narazil na hada. Rychle se ho zbav!!";

            Random rnd = new Random();
            rr = rnd.Next(1, 6);

            if (rr == 1)
            {
                textenemy.Text = e1.lore;
                p_enemy.Maximum = e1.healt;
                p_enemy.Value = e1.healt;
                // image.Source = ;
                level = e1.level;
                defense = e1.dev;
                atack = e1.fig;
            }
            if (rr == 2)
            {
                textenemy.Text = e2.lore;
                p_enemy.Maximum = e2.healt;
                p_enemy.Value = e2.healt;
                level = e2.level;
                defense = e2.dev;
                atack = e2.fig;
            }
            if (rr == 3)
            {
                textenemy.Text = e3.lore;
                p_enemy.Maximum = e3.healt;
                p_enemy.Value = e3.healt;
                level = e3.level;
                defense = e3.dev;
                atack = e3.fig;
            }
            if (rr == 4)
            {
                textenemy.Text = e4.lore;
                p_enemy.Maximum = e4.healt;
                p_enemy.Value = e4.healt;
                level = e4.level;
                defense = e4.dev;
                atack = e4.fig;
            }
            if (rr == 5)
            {
                textenemy.Text = e5.lore;
                p_enemy.Maximum = e5.healt;
                p_enemy.Value = e5.healt;
                level = e5.level;
                defense = e5.dev;
                atack = e5.fig;
            }
            if (rr == 6)
            {
                textenemy.Text = e6.lore;
                p_enemy.Maximum = e6.healt;
                p_enemy.Value = e6.healt;
                level = e6.level;
                defense = e6.dev;
                atack = e6.fig;
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
   
}
