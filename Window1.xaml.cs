using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Data;

namespace Software_Engineering_Projekt_1
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public object FileUpload1 { get; private set; }

        public Window1()
        {
            InitializeComponent();
           
        }

        private void OnOpenZurück(object sender, RoutedEventArgs e)
        {
            MainWindow zu = new MainWindow();
            zu.Show();
            this.Close();
        }

        private void OnOpenBeende(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnOpenAblauf(object sender, RoutedEventArgs e)
        {
            Ablauf objAblauf = new Ablauf();
            objAblauf.Show();
            this.Close();
        }

           



        

       

        private void OnOpenRegister(object sender, RoutedEventArgs e)

        {
            string answer1 = "Ja"; // für Radiobutton Platzvariable und später für Datenbank
            string answer2 = "Ja";

            string a1;
            string a2;
           
            SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=LoginRegister;Integrated Security=True"); //Pfad zur Datenbank und welche Database speichern soll , da Datenbank lokal, muss man neue Database und Tabellen erstellen
            con.Open();
            string add_data = "INSERT INTO [dbo].[user1] VALUES(@vor, @nach, @birthday, @street, @PLZ, @town, @tele, @Fachrichtung, @Fachsemester, @username, @password, @Rolle)"; //In welche Spalten speichern soll
            SqlCommand cmd = new SqlCommand(add_data, con);
            cmd.Parameters.AddWithValue("@vor", firstName.Text);
            cmd.Parameters.AddWithValue("@nach", lastname.Text);
            cmd.Parameters.AddWithValue("@birthday", datum.Text);
            cmd.Parameters.AddWithValue("@street", street.Text);
            cmd.Parameters.AddWithValue("@PLZ", postcode.Text);
            cmd.Parameters.AddWithValue("@town", town.Text);
            cmd.Parameters.AddWithValue("@tele", number.Text);
            cmd.Parameters.AddWithValue("@Fachrichtung", fachrichtung.Text);
            cmd.Parameters.AddWithValue("@Fachsemester", semester.Text);
            cmd.Parameters.AddWithValue("@username", user.Text);
            cmd.Parameters.AddWithValue("@password", password.Password);
            cmd.Parameters.AddWithValue("@Rolle", SqlDbType.NVarChar).Value = answer1;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Daten wurden gespeichert! Account wurde erstellt!");
            MainWindow zu = new MainWindow();
            zu.Show();
            this.Close();

            if (RadioButton.IsChecked==true)
            {
                a1 = answer1;
               
            }
            else
            {
                a2 = answer2;
                //cmd.Parameters.AddWithValue("@Rolle", SqlDbType.NVarChar).Value = answer2;

            }
           
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
           
        }
    }
  }

