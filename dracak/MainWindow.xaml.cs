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
    //Hlavní třída main
    public partial class MainWindow : Window
    {
        public static Frame framePublic;
        public MainWindow()
        {
            InitializeComponent();
            framePublic = frame;
            MainWindow.framePublic.Source = new Uri("pages/uvod.xaml", UriKind.Relative);
        }
           
    }
}