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
    /// Interaction logic for boss.xaml
    /// </summary>
    public partial class boss : Page
    {
        //pomocné promněné 
        int atack; 
        int defense;
        public boss()
        {
            InitializeComponent();

            h_bar.Maximum = 100;
            f_bar.Maximum = 50;
            d_bar.Maximum = 50;
            //přenos defaulních hodnot z classy hrač do progress barů

            h_bar.Value = uvod.p1.healt;
            f_bar.Value = uvod.p1.fight;
            d_bar.Value = uvod.p1.dev;
            name.Content = uvod.p1.name;

            f_prog.Maximum = uvod.drak.healt; //přenesení hodnot s classy do proměné
            f_prog.Value = uvod.drak.healt;
            defense = uvod.drak.dev;
            atack = uvod.drak.fig;
            f_wel.Text = uvod.drak.lore; //výpis finální hlášky
            f_image.Source = new BitmapImage(new Uri(@uvod.drak.image, UriKind.Relative));

        }

        private void f1_but_Click(object sender, RoutedEventArgs e) //definování útoku při finálním fightu
        {
            Random rnd = new Random();
            int uu = rnd.Next(1, 10);
            int at = uu + 1 + uvod.p1.fight;
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
            if (uvod.p1.dev > tr)
            {
                xx = 0;
            }
            xx = tr - uvod.p1.dev;
            h_bar.Value = h_bar.Value - xx;
            dead();
            win();
        }


        private void f2_but_Click(object sender, RoutedEventArgs e) //definování tlačítka kouzlo
        {
            Random rnd = new Random();
            int uu = rnd.Next(1, 30);
            int at = uu + 1 + uvod.p1.fight;
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
            if (uvod.p1.dev > tr)
            {
                xx = 0;
            }
            xx = tr - uvod.p1.dev;
            h_bar.Value = h_bar.Value - xx;
            f_bar.Value = f_bar.Value - 10;
            dead();
            win();
        }

        private void d_but_Click(object sender, RoutedEventArgs e) //definice obranného tlačítka.
        {
            Random rnd = new Random();
            int hel = rnd.Next(0, 20);
            int del = hel / 2;

            f_prog.Value = f_prog.Value + del;
            h_bar.Value = h_bar.Value + hel;
        }

        public void dead() //funkce pro výpis konce hry (prohra)
        {
            if (h_bar.Value <= 0)
            {
                MainWindow.framePublic.Source = new Uri("pages/dead.xaml", UriKind.Relative);
            }
        }
        public void win()//funkce pro výpis konce hry (výhra)
        {
            if (f_prog.Value <= 0)
            {
                MainWindow.framePublic.Source = new Uri("pages/win.xaml", UriKind.Relative);
            }
        }
    }
}
