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
    /// Interaktionslogik für LoginDS.xaml
    /// </summary>
    public partial class LoginDS : Window
    {
        public LoginDS()
        {
            InitializeComponent();
        }

        private void OnOpenRegistrierung(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnOpenHilfe(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
