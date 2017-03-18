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
    public partial class uvod : Page
    {
        //založení tříd player a enemy
        public static List<enemy> potvory = new List<enemy>();
        public static List<place> mista = new List<place>();

        public static player p1 = new player();
        public static enemy e1 = new enemy();
        public static enemy e2 = new enemy();
        public static enemy e3 = new enemy();
        public static enemy e4 = new enemy();
        public static enemy e5 = new enemy();
        public static enemy e6 = new enemy();
        public static enemy drak = new enemy();

        public static place m1 = new place();
        public static place m2 = new place();
        public static place m3 = new place();
        public static place m4 = new place();
        public static place m5 = new place();
        public static place m6 = new place();
        public static place m7 = new place();

        public static place mistik = new place();
        
           public uvod()
        {
            InitializeComponent();
            //výhozí welcome hláška
           
            welcome.Text = "Vítej ve hře dračák, tvým úkolem je nejdříve se vycvičit na dostatečnou úroveň, aby jsi se mohl vydat za drakem, kterého poté musíš zabít. Setkáš se s ním, až tvoje síla dosáhne 100%, ale nesmíš při tréninku zemřít. Nejprve zadej název svého hrdiny a stiskni tlačítko dále. ";
        }
      
    //Funkce tlačítka vstoupit do hry
        private void s_button_Click(object sender, RoutedEventArgs e) 
        {
            //konfigurační funkce entit    
            config();   
            
               
            MainWindow.framePublic.Source = new Uri("Pages/game.xaml", UriKind.Relative); //změna source Page
           
        }

        //configurace veškerých tříd ve hře ---> změna celého příběhu
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
            e1.lore = "rychlého zákeřného vlka. Dej si pozor na jeho zuby !"; //vstupní příběh
            e1.image = "/picture/vlk.jpg";
            potvory.Add(e1);
            //založení enemy atributů pro vytvořenou classu
            e2.name = "Medvěd";
            e2.healt = 30;
            e2.level = 2;
            e2.fig = 10;
            e2.dev = 3;
            e2.lore = "Obrovského medvěda, který má obrovskou sýlu ve svých rukou proto se ho raděj rychle zbav!";
            e2.image = "/picture/medved.jpg";
            potvory.Add(e2);
            //založení enemy atributů pro vytvořenou classu
            e3.name = "Pes";
            e3.healt = 35;
            e3.level = 2;
            e3.fig = 10;
            e3.dev = 4;
            e3.lore = "divokého psa.";
            e3.image = "/picture/pes.jpg";
            potvory.Add(e3);
            //založení enemy atributů pro vytvořenou classu
            e4.name = "Skřet";
            e4.healt = 12;
            e4.level = 1;
            e4.fig = 15;
            e4.dev = 1;
            e4.lore = "kouzelnického skřeta, který ovládá kouzla.";
            e4.image = "/picture/skret.jpg";
            potvory.Add(e4);
            //založení enemy atributů pro vytvořenou classu
            e5.name = "Prase";
            e5.healt = 30;
            e5.level = 3;
            e5.fig = 9;
            e5.dev = 5;
            e5.lore = "divoké prase. Nenech se splést jeho velikostí.";
            e5.image = "/picture/prase.jpg";
            potvory.Add(e5);
            //založení enemy atributů pro vytvořenou classu
            e6.name = "Had";
            e6.healt = 10;
            e6.level = 2;
            e6.fig = 15;
            e6.dev = 5;
            e6.lore = "zákeřného hada, který tě může velmi potrápit.";
            e6.image = "/picture/had.jpg";
            potvory.Add(e6);

            drak.name = "Drak";
            drak.healt = 250;
            drak.level = 9;
            drak.fig = 50;
            drak.dev = 35;
            drak.lore = "Dokončil jsi svůj trénink a nyní se můžeš utkat s Drakem. Naučil jsi se kouzlu, ale nezapoměň, že kouzla se mohou odrazit a jejich užití má za následek ztrátu síly. Hodně štěstí !!!";
            drak.image = "/picture/drak.jpg";

            m1.name = "Louka";
            m1.fight_bonus = 3;
            m1.dev_bonus = 0;
            m1.lore = "Během svého cestování jsi se dostal na louku a díky tomu se tvé obrané schopnosti zhoršily, takže si dej velký pozor na ";
            m1.image = "/obrazky/vlk.jpg";
            mista.Add(m1);

            m2.name = "Les";
            m2.fight_bonus = 2;
            m2.dev_bonus = 4;
            m2.lore = "Jelikož tvé orientační schopnosti jsou velmi špatné zatoulal jsi se do temného lesa kde si narazil na ";
            m2.image = "/obrazky/vlk.jpg";
            mista.Add(m2);

            m3.name = "Hory";
            m3.fight_bonus = 2;
            m3.dev_bonus = 2;
            m3.lore = "Pro další zkušenosti musíš překonat vysoké hory, ale během svého putování si narazil na ";
            m3.image = "/obrazky/vlk.jpg";
            mista.Add(m3);

            m4.name = "Město";
            m4.fight_bonus = 3;
            m4.dev_bonus = 4;
            m4.lore = "Při tvé výpravě jsi se zatoulal do opuštěného města zamořeného nepřáteli. Proto si dej velký poroz na ";
            m4.image = "/obrazky/vlk.jpg";
            mista.Add(m4);

            m5.name = "Bažina";
            m5.fight_bonus = 0;
            m5.dev_bonus = 1;
            m5.lore = "Uvízl jsi v bažině a narazil jsi na ";
            m5.image = "/obrazky/vlk.jpg";
            mista.Add(m5);

            m6.name = "Jeskyně";
            m6.fight_bonus = 5;
            m6.dev_bonus = 0;
            m6.lore = "Chtěl jsi se schovat před bandity do jeskyně, ale bohužel jsi měl velkou smůlu a musíš si dát pozor na ";
            m6.image = "/obrazky/vlk.jpg";
            mista.Add(m6);

            m7.name = "Ostrov";
            m7.fight_bonus = 1;
            m7.dev_bonus = 1;
            m7.lore = "Pokoušel jsi se přeplavat řeku, ale ukloula ti noha a ty jsi se ocitl na opuštěném ostrově, kde jsi narazil na ";
            m7.image = "/obrazky/vlk.jpg";
            mista.Add(m7);

            mistik.name = "mistik";
            mistik.fight_bonus = 0;
            mistik.dev_bonus = 0;
            mistik.lore = "To je neuvěřitelné !! Našel si posvátný scitek, který tě přenesl k nejvyšímu čaroději, který tě může naučit všem technikám boje. Přijmeš jeho nabídku ?";
            mistik.image = "/obrazky/vlk.jpg";
            mista.Add(mistik);
        }
    }
}
