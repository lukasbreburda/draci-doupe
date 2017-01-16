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
        enemy drak = new enemy();
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
            welcome.Text = "Vítej ve hře dračák, tvým úkolem je nejdříve se vycvičit na dostatečnou úroveň, aby jsi se mohl vydat za drakem, kterého poté musíš zabít. setkáš se s ním, až tvoje síla dosáhne 100%, ale nesmíš při trénigu zemří. Nejprve zadej název svého hrdiny a stiskni tlačítko dále. ";
           

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
            f_bar.Maximum = 50;
            d_bar.Maximum = 50;

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
            dead();
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
            if (p1.fight >= 50)
            {
                hiden();
                f1_but.Visibility = Visibility.Visible;
                f2_but.Visibility = Visibility.Visible;
                d_but.Visibility = Visibility.Visible;
                f_prog.Visibility = Visibility.Visible;
                f_image.Visibility = Visibility.Visible;
                f_wel.Visibility = Visibility.Visible;
                h_bar.Visibility = Visibility.Visible;
                f_bar.Visibility = Visibility.Visible;
                d_bar.Visibility = Visibility.Visible;
                h.Visibility = Visibility.Visible;
                f.Visibility = Visibility.Visible;
                d.Visibility = Visibility.Visible;

                drak.name = "Drak";
                drak.healt = 250;
                drak.level = 9;
                drak.fig = 50;
                drak.dev = 35;
                drak.lore = "Dokončil jsi svůj trénink a nyní se můžeš utkat s Drakem. Naučil jsi se kouzlu, ale nezapoměň, že kouzla se mohou odrazit. Hodně štěstí.!";

                
                f_prog.Maximum = drak.healt;
                f_prog.Value = drak.healt;   
                defense = drak.dev;
                atack = drak.fig;

                f_wel.Text = drak.lore;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("http://obrazky-gif.wz.cz/draci/12/drak-109.gif");
                bitmap.EndInit();
                f_image.Source = bitmap;

                
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
            f1_but.Visibility = Visibility.Hidden;
            f2_but.Visibility = Visibility.Hidden;
            d_but.Visibility = Visibility.Hidden;
            f_prog.Visibility = Visibility.Hidden;
            f_image.Visibility = Visibility.Hidden;
            f_wel.Visibility = Visibility.Hidden;
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
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("http://previews.123rf.com/images/lawangdesign/lawangdesign1502/lawangdesign150200023/37154372-cute-wolf-cartoon-Stock-Photo.jpg");
                bitmap.EndInit();

                textenemy.Text = e1.lore;
                p_enemy.Maximum = e1.healt;
                p_enemy.Value = e1.healt;
                 image.Source = bitmap;
                level = e1.level;
                defense = e1.dev;
                atack = e1.fig;
            }
            if (rr == 2)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("http://static6.depositphotos.com/1152839/640/v/950/depositphotos_6404226-stock-illustration-bear-mascot-flexing-arm-cartoon.jpg");
                bitmap.EndInit();

                textenemy.Text = e2.lore;
                p_enemy.Maximum = e2.healt;
                p_enemy.Value = e2.healt;
                level = e2.level;
                image.Source = bitmap;
                defense = e2.dev;
                atack = e2.fig;
            }
            if (rr == 3)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("http://st.depositphotos.com/1967477/2538/v/950/depositphotos_25388139-stock-illustration-lion-cartoon-roaring.jpg");
                bitmap.EndInit();

                textenemy.Text = e3.lore;
                p_enemy.Maximum = e3.healt;
                p_enemy.Value = e3.healt;
                level = e3.level;
                image.Source = bitmap;
                defense = e3.dev;
                atack = e3.fig;
            }
            if (rr == 4)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("http://static4.depositphotos.com/1012083/295/v/950/depositphotos_2955197-stock-illustration-green-dwarf.jpg");
                bitmap.EndInit();

                textenemy.Text = e4.lore;
                p_enemy.Maximum = e4.healt;
                p_enemy.Value = e4.healt;
                level = e4.level;
                image.Source = bitmap;
                defense = e4.dev;
                atack = e4.fig;
            }
            if (rr == 5)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("https://scontent-vie1-1.xx.fbcdn.net/v/t1.0-9/1958478_636975406367707_403968752_n.jpg?oh=410352ccc7c94e252f4640e7d909b529&oe=5922C05A");
                bitmap.EndInit();

                textenemy.Text = e5.lore;
                p_enemy.Maximum = e5.healt;
                p_enemy.Value = e5.healt;
                image.Source = bitmap;
                level = e5.level;
                defense = e5.dev;
                atack = e5.fig;
            }
            if (rr == 6)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("http://st.depositphotos.com/2400497/2917/v/950/depositphotos_29175525-stock-illustration-cartoon-snake.jpg");
                bitmap.EndInit();

                textenemy.Text = e6.lore;
                p_enemy.Maximum = e6.healt;
                p_enemy.Value = e6.healt;
                image.Source = bitmap;
                level = e6.level;
                defense = e6.dev;
                atack = e6.fig;
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void f1_but_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int uu = rnd.Next(1, 10);
            int at = uu + 1 + p1.fight;
            int tt;
            if (defense > at)
            {
                tt = 0;
            }
            tt = at - defense;
            if (tt > 0)
            {
                f_prog.Value = f_prog.Value - tt;
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
            dead();
            win();
        }
        

        private void f2_but_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int uu = rnd.Next(1, 30);
            int at = uu + 1 + p1.fight;
            int tt;
            if (defense > at)
            {
                tt = 0;
            }
            tt = at - defense;
            if (tt > 0)
            {
                f_prog.Value = f_prog.Value - tt;
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
            f_bar.Value = f_bar.Value - 10;
            dead();
            win();
        }

        private void d_but_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int hel = rnd.Next(0, 20);
            int del = hel / 2;

            f_prog.Value = f_prog.Value + del;
            h_bar.Value = h_bar.Value + hel;
        }
        public void dead()
        {
            if (h_bar.Value <= 0)
            {
                hiden();

                end.Visibility = Visibility.Visible;
                exit.Visibility = Visibility.Visible;
            }
        }
        public void win()
        {
            if(f_prog.Value <= 0)
            {
                hiden();
                end.Visibility = Visibility.Visible;
                end.Text = "Vyhrál jsi !!!";
                end.Foreground = Brushes.Green;
                exit.Visibility = Visibility.Visible;
            }
        }
    }
   
}
