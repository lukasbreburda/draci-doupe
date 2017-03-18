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
    /// Interaction logic for mistik.xaml
    /// </summary>
    public partial class mistik : Page
    {
        public mistik()
        {           
            InitializeComponent();
            text_mistik.Text = uvod.mistik.lore;
        }

        private void ano_f(object sender, RoutedEventArgs e)
        {
            MainWindow.framePublic.Source = new Uri("pages/boss.xaml", UriKind.Relative); //změna source Page

        }

        private void ne_f(object sender, RoutedEventArgs e)
        {
            MainWindow.framePublic.Source = new Uri("pages/dead.xaml", UriKind.Relative); //změna source Page

        }
    }
}
