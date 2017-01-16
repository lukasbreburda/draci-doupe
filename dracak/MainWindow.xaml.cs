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
    //Hlavní třída main
    public partial class MainWindow : Window
    {
        //založení hráče a enemy entit
        player p1 = new player();
        enemy e1 = new enemy();
        enemy e2 = new enemy();
        enemy e3 = new enemy();
        enemy e4 = new enemy();
        enemy e5 = new enemy();
        enemy e6 = new enemy();
        enemy drak = new enemy();
        //pomocné globální proměné 
        int rr;
        int atack;
        int defense;
        int level;
        //úvodní screan 
        public MainWindow()
        {  InitializeComponent(); //inicializace

            hiden(); //funkce pro schování ostatních xampl atributů
            welcome.Visibility = Visibility.Visible;
            textname.Visibility = Visibility.Visible;
            s_button.Visibility = Visibility.Visible;//zobrazení xampl
            welcome.Text = "Vítej ve hře dračák, tvým úkolem je nejdříve se vycvičit na dostatečnou úroveň, aby jsi se mohl vydat za drakem, kterého poté musíš zabít. Setkáš se s ním, až tvoje síla dosáhne 100%, ale nesmíš při tréninku zemřít. Nejprve zadej název svého hrdiny a stiskni tlačítko dále. ";
           //welcome hláška

        }

        private void s_button_Click(object sender, RoutedEventArgs e) //funkce po stsknutí buttonu "Do toho"
        {
            hiden(); //schování ostatních atributů xampl


            // zobrazení ostatních xampl atriburů
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

          

            //definování atributů classy hrac
           
            p1.name = "Tvůj nickname: " + textname.Text;
            p1.healt = 100;
            p1.level = 1;
            p1.dev = 0;
            p1.fight = 1;
            // nastavení barů
            h_bar.Maximum = 100;
            f_bar.Maximum = 50;
            d_bar.Maximum = 50;
            //přenos defaulních hodnot z classy hrač do progress barů
            h_bar.Value = p1.healt;
            f_bar.Value = p1.fight;
            d_bar.Value = p1.dev;
            name.Content = p1.name; 


            enemys(); // funkce pro načtení enemy

        }

        private void fight_but_Click(object sender, RoutedEventArgs e) //funkce pro utok 
        {

            //definice a výpočet utoku, který způsobý jak hráči, tak i enemy příšeře.
            Random rnd = new Random(); //random
            int uu = rnd.Next(1, 10);
            int at = uu + 1 + p1.fight ;
            int tt;
            if (defense > at) //podmínka, pokud je obraná hodnota větší než útok, neprováděj útok
            {
             tt = 0;
            }
             tt = at - defense;
            if (tt > 0)
            {
                p_enemy.Value = p_enemy.Value - tt; //odečte enemy životy s progress baru
            }
           
            int kk = rnd.Next(0, 3);
            int tr = atack - kk;
            int xx;
            if (p1.dev > tr)
            {
                xx = 0;
            }
            xx = tr - p1.dev;

            h_bar.Value = h_bar.Value - xx; //odečte hráči životy s pogress baru
            dead(); //funkce pro smrt
            if (p_enemy.Value <= 0) // pokud zemře enemy vyvolej novou
            {
                enemys(); //vyvolání enemyho
                //zlepšení schopností hráče i enemiho
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
            if (p1.fight >= 50) //pokud je síla 50 vstup na finální souboj
            {
                hiden(); //funkce pro skrytí
                //zobrazení 
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
                //založení enemy draka
                drak.name = "Drak";
                drak.healt = 250;
                drak.level = 9;
                drak.fig = 50;
                drak.dev = 35;
                drak.lore = "Dokončil jsi svůj trénink a nyní se můžeš utkat s Drakem. Naučil jsi se kouzlu, ale nezapoměň, že kouzla se mohou odrazit a jejich užití má za následek ztrátu síly. Hodně štěstí !!!";

                
                f_prog.Maximum = drak.healt; //přenesení hodnot s classy do proměné
                f_prog.Value = drak.healt;   
                defense = drak.dev;
                atack = drak.fig;

                f_wel.Text = drak.lore; //výpis finální hlášky

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("http://obrazky-gif.wz.cz/draci/12/drak-109.gif"); //převedení url obrázku na formát schpný zpracovat image.source
                bitmap.EndInit();
                f_image.Source = bitmap;

                
            }
        }

        private void dev_but_Click(object sender, RoutedEventArgs e) //definice obraného tlačítka
        {
            Random rnd = new Random();
            int hel = rnd.Next(0, 10);
            int del = hel / 4;

            p_enemy.Value = p_enemy.Value + del; //přičtení protívníkovy životy 
            h_bar.Value = h_bar.Value + hel; //přičtení hráči životy
        }
        public void hiden() //definice funkce která skyrá veškeré atributy xamlp
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
        public void enemys() //funkce pro vyvolání enemyho
        {
            //založení enemy atributů pro vytvořenou classu
            e1.name = "Vlk"; //název
            e1.healt = 20; //životy
            e1.level = 1; //level
            e1.fig = 10; //síla
            e1.dev = 5; //obrana
            e1.lore = "Během svého trenování jsi narazil na Vlka. Poror je rychlý a může být velmi nebezpečný proto se ho co nejdřív zbav!!"; //vstupní příběh
            //založení enemy atributů pro vytvořenou classu
            e2.name = "Medvěd";
            e2.healt = 30;
            e2.level = 2;
            e2.fig = 10;
            e2.dev = 3;
            e2.lore = "Během své trenikové výpravy jsi narazil na velkého medvěda. Dej si pozor na jeho drápy!";
            //založení enemy atributů pro vytvořenou classu
            e3.name = "Lev";
            e3.healt = 35;
            e3.level = 2;
            e3.fig = 10;
            e3.dev = 4;
            e3.lore = "Během svého trenování jsi narazil na Lva, nepodceň jej a zneškodni ho vší silu!!";
            //založení enemy atributů pro vytvořenou classu
            e4.name = "Trpaslík";
            e4.healt = 12;
            e4.level = 1;
            e4.fig = 15;
            e4.dev = 1;
            e4.lore = "Během svého trenování si narazil na zákeřného trpaslíka, který není tak roztomilí jak se na první pohled může zdát!!";
            //založení enemy atributů pro vytvořenou classu
            e5.name = "Kočvara";
            e5.healt = 40;
            e5.level = 3;
            e5.fig = 10;
            e5.dev = 6;
            e5.lore = "Během svého trenování si narazil na anime Kočvaru. Rychle se ho zbav, ale pozor je velmi zákeřný!!";
            //založení enemy atributů pro vytvořenou classu
            e6.name = "Had";
            e6.healt = 10;
            e6.level = 2;
            e6.fig = 15;
            e6.dev = 5;
            e6.lore = "Během svého trenování si narazil na hada. Raděj si dej pozor!!";

            Random rnd = new Random(); //random pro výběr náhodného enemyho
            rr = rnd.Next(1, 7);

            if (rr == 1) //podmínka pro přenesení hodnot s classu do proměných 
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
            if (rr == 2)//podmínka pro přenesení hodnot s classu do proměných 
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
            if (rr == 3)//podmínka pro přenesení hodnot s classu do proměných 
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
            if (rr == 4)//podmínka pro přenesení hodnot s classu do proměných 
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
            if (rr == 5)//podmínka pro přenesení hodnot s classu do proměných 
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
            if (rr == 6)//podmínka pro přenesení hodnot s classu do proměných 
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

        private void exit_Click(object sender, RoutedEventArgs e) //definice tláčítka exit
        {
            Application.Current.Shutdown(); //ukončení wpf aplikace
        }

        private void f1_but_Click(object sender, RoutedEventArgs e) //definování útoku při finálním fightu
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
        

        private void f2_but_Click(object sender, RoutedEventArgs e) //definování tlačítka kouzlo
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
                hiden();

                end.Visibility = Visibility.Visible;
                exit.Visibility = Visibility.Visible;
            }
        }
        public void win()//funkce pro výpis konce hry (prohra)
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
