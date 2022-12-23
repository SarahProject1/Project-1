using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Software_Engineering_Projekt_1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Schließen
        {
            Close();
        }

        private void OnOpenRegistrierung(object sender, RoutedEventArgs e) //Neues Fenster öffnen
        {
            Window1 objWindow1 = new Window1(); //neues Fenster öffnen
            objWindow1.Show();
           this.Close();

        }

        private void OnOpenHilfe(object sender, RoutedEventArgs e)
        {
            Ablauf objAblauf = new Ablauf();
            objAblauf.Show();
            this.Close();
        }

        private void OnOpenLogin(object sender, RoutedEventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB

;Database=LoginRegister;Integrated Security=True"); //Pfad zu SQL Server
            if (con.State == ConnectionState.Closed)
                con.Open();
            string query = "SELECT * FROM [dbo].[user2] WHERE username=@username and password=@password"; //aus Datenbank Spalte Username und Password um zuvergleichen
            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Parameters.AddWithValue("@username", benutzer.Text); //username den man eingibt muss gleich sein mit dem Username aus Datenbank
            sqlcmd.Parameters.AddWithValue("@password", login.Password);
            int Count = Convert.ToInt32(sqlcmd.ExecuteScalar()); //Programm schaut in Datenbank und wenn man sich registriert hat mit Benutername und Password und dieses nun eingibt, kann man sich "einloggen"


            if (Count > 0)
            {
                Login1 loginpage = new Login1();
                loginpage.Show();   //neue Seite öffnet sich (nach Login)
                this.Close();

            }
            else
            {
                MessageBox.Show("Benutzername oder Passwort stimmen nicht!", "Save error", MessageBoxButton.OK, MessageBoxImage.Error); // Falls Passwort oder Benutzername nicht stimmt bekommt man eine Benachrichtigung
            }

        }
    }
}
