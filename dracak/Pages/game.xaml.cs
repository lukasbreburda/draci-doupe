﻿using System;
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
    /// Interaction logic for game.xaml
    /// </summary>
    public partial class game : Page
    {      
        //pomocné globální proměné 
        int rr;
        int atack;
        int defense;
        int level;

        public game()
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

            enemys();
        }

        public void enemys() //funkce pro vyvolání enemyho
        {
            
            Random rnd = new Random(); //random pro výběr náhodného enemyho
            rr = rnd.Next(0, 6);

            textenemy.Text = uvod.potvory[rr].lore;
            p_enemy.Maximum = uvod.potvory[rr].healt;
            p_enemy.Value = uvod.potvory[rr].healt;
            image.Source = new BitmapImage(new Uri(@uvod.potvory[rr].image, UriKind.Relative));
            level = uvod.potvory[rr].level;
            defense = uvod.potvory[rr].dev;
            atack = uvod.potvory[rr].fig;           
        }
        private void fight_but_Click(object sender, RoutedEventArgs e) //funkce pro utok 
        {
            //definice a výpočet utoku, který způsobý jak hráči, tak i enemy příšeře.
            Random rnd = new Random(); //random
            int uu = rnd.Next(1, 10);
            int at = uu + 1 + uvod.p1.fight;
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
            if (uvod.p1.dev > tr)
            {
                xx = 0;
            }
            xx = tr - uvod.p1.dev;
            h_bar.Value = h_bar.Value - xx; //odečte hráči životy s pogress baru
            dead(); //funkce pro smrt
            if (p_enemy.Value <= 0) // pokud zemře enemy vyvolej novou
            {
                enemys(); //vyvolání enemyho
                //zlepšení schopností hráče i enemiho
                uvod.p1.dev = uvod.p1.dev + level;
                uvod.p1.fight = uvod.p1.fight + (level * 3);
                h_bar.Value = uvod.p1.healt;
                f_bar.Value = uvod.p1.fight;
                d_bar.Value = uvod.p1.dev;
                atack = atack + level + 5;
                defense = defense + (level * 2);
                p_enemy.Maximum = (p_enemy.Maximum * 2);
                p_enemy.Value = (p_enemy.Value * 2);
            }
            if (uvod.p1.fight >= 50) //pokud je síla 50 vstup na finální souboj
            {
                MainWindow.framePublic.Source = new Uri("pages/boss.xaml", UriKind.Relative);
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
        public void dead() //funkce pro výpis konce hry (prohra)
        {
            if (h_bar.Value <= 0)
            {
                MainWindow.framePublic.Source = new Uri("pages/dead.xaml", UriKind.Relative);
            }
        }
    }
}
