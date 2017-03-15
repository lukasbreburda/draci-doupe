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
    /// Interaction logic for uvod.xaml
    /// </summary>
    public partial class uvod : Page
    {
         public static List<enemy> potvory = new List<enemy>();
        public static player p1 = new player();
        public static enemy e1 = new enemy();
        public static enemy e2 = new enemy();
        public static enemy e3 = new enemy();
        public static enemy e4 = new enemy();
        public static enemy e5 = new enemy();
        public static enemy e6 = new enemy();
        public static enemy drak = new enemy();

        public uvod()
        {
            InitializeComponent();
            welcome.Text = "Vítej ve hře dračák, tvým úkolem je nejdříve se vycvičit na dostatečnou úroveň, aby jsi se mohl vydat za drakem, kterého poté musíš zabít. Setkáš se s ním, až tvoje síla dosáhne 100%, ale nesmíš při tréninku zemřít. Nejprve zadej název svého hrdiny a stiskni tlačítko dále. ";
        }
      
    
        private void s_button_Click(object sender, RoutedEventArgs e)
        {
            config();
            

            MainWindow.framePublic.Source = new Uri("pages/game.xaml", UriKind.Relative);
        }

        private void config()
        {
            p1.name = textname.Text;
            p1.healt = 100;
            p1.level = 1;
            p1.dev = 0;
            p1.fight = 1;


            e1.name = "Vlk"; //název
            e1.healt = 20; //životy
            e1.level = 1; //level
            e1.fig = 10; //síla
            e1.dev = 5; //obrana
            e1.lore = "Během svého trenování jsi narazil na Vlka. Poror je rychlý a může být velmi nebezpečný proto se ho co nejdřív zbav!!"; //vstupní příběh
            e1.image = "/obrazky/vlk.jpg";
            potvory.Add(e1);
            //založení enemy atributů pro vytvořenou classu
            e2.name = "Medvěd";
            e2.healt = 30;
            e2.level = 2;
            e2.fig = 10;
            e2.dev = 3;
            e2.lore = "Během své trenikové výpravy jsi narazil na velkého medvěda. Dej si pozor na jeho drápy!";
            e2.image = "/obrazky/vlk.jpg";
            potvory.Add(e2);
            //založení enemy atributů pro vytvořenou classu
            e3.name = "Lev";
            e3.healt = 35;
            e3.level = 2;
            e3.fig = 10;
            e3.dev = 4;
            e3.lore = "Během svého trenování jsi narazil na Lva, nepodceň jej a zneškodni ho vší silu!!";
            e3.image = "/obrazky/vlk.jpg";
            potvory.Add(e3);
            //založení enemy atributů pro vytvořenou classu
            e4.name = "Trpaslík";
            e4.healt = 12;
            e4.level = 1;
            e4.fig = 15;
            e4.dev = 1;
            e4.lore = "Během svého trenování si narazil na zákeřného trpaslíka, který není tak roztomilí jak se na první pohled může zdát!!";
            e4.image = "/obrazky/vlk.jpg";
            potvory.Add(e4);
            //založení enemy atributů pro vytvořenou classu
            e5.name = "Kočvara";
            e5.healt = 40;
            e5.level = 3;
            e5.fig = 10;
            e5.dev = 6;
            e5.lore = "Během svého trenování si narazil na anime Kočvaru. Rychle se ho zbav, ale pozor je velmi zákeřný!!";
            e5.image = "/obrazky/vlk.jpg";
            potvory.Add(e5);
            //založení enemy atributů pro vytvořenou classu
            e6.name = "Had";
            e6.healt = 10;
            e6.level = 2;
            e6.fig = 15;
            e6.dev = 5;
            e6.lore = "Během svého trenování si narazil na hada. Raděj si dej pozor!!";
            e6.image = "/obrazky/vlk.jpg";
            potvory.Add(e6);

            drak.name = "Drak";
            drak.healt = 250;
            drak.level = 9;
            drak.fig = 50;
            drak.dev = 35;
            drak.lore = "Dokončil jsi svůj trénink a nyní se můžeš utkat s Drakem. Naučil jsi se kouzlu, ale nezapoměň, že kouzla se mohou odrazit a jejich užití má za následek ztrátu síly. Hodně štěstí !!!";
            drak.image = "/obrazky/vlk.jpg";
        }
    }
}
