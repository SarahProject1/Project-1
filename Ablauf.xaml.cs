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
using System.Windows.Shapes;

namespace Software_Engineering_Projekt_1
{
    /// <summary>
    /// Interaktionslogik für Ablauf.xaml
    /// </summary>
    public partial class Ablauf : Window
    {
        public Ablauf()
        {
            InitializeComponent();
        }

        private void OnOpenBeende(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnOpenRegistrierung(object sender, RoutedEventArgs e)
        {
            Window1 objWindow1 = new Window1(); //neues Fenster öffnen
            objWindow1.Show();
            this.Close();
        }

        private void OnOpenZurück(object sender, RoutedEventArgs e)
        {
            MainWindow zu = new MainWindow();
            zu.Show();
            this.Close();
        }

        private void OnOpenDozent(object sender, RoutedEventArgs e)
        {
            AblaufAD objAblauf1 = new AblaufAD();
            objAblauf1.Show();
            this.Close();
        }
    }
}
