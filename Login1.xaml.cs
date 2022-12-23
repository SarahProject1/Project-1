using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Interaktionslogik für Login1.xaml
    /// </summary>
    public partial class Login1 : Window
    {
        public Login1()
        {
            InitializeComponent();
        }

        private void OnOpenFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog(); // Pfad wird geöffnet
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                Text.Text = openFileDlg.FileName; // Zeigt Dokumentnamen

            }
            openFileDlg.Multiselect = true;
            openFileDlg.Filter = "All files (*.*)|*.*"; // Alle Dokumententypen sind möglich

        }

                private void Button_Click(object sender, RoutedEventArgs e)
                {
                    MessageBox.Show("Du wurdest erfolgreich ausgeloggt"); //Beenden des Programmes
                    this.Close();
                }

                private void OnOpenRegistrierung(object sender, RoutedEventArgs e)
                {

                }

                private void OnOpenHilfe(object sender, RoutedEventArgs e)
                {

                }

        private void OnOpenSave(object sender, RoutedEventArgs e)
        {
            SaveFile(Text.Text); //Um das Dokument zu speichern, extra Klasse unten erstellt
            MessageBox.Show("Dokumente wurden gespeichert!");


        }

        private void SaveFile(string filepath)
        {
            using( Stream stream = File.OpenRead(filepath)) 
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                string extn = new FileInfo(filepath).Extension;

                string query = "INSERT INTO Documents(Data,Extension)VALUES(@data,@extn)";

                using(SqlConnection cn=GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.Add(@"data", SqlDbType.VarBinary).Value = buffer;
                    cmd.Parameters.Add(@"extn", SqlDbType.Char).Value = extn;
                    cn.Open();
                    cmd.ExecuteNonQuery(); //Dokument wird in SQL Datenbank eingefügt. 
                }
            }
        }

        private SqlConnection GetConnection() //Methode
        {
            return new SqlConnection(@"Server = (localdb)\MSSQLLocalDB; Database = LOG; Integrated Security = True");
        }
    } 
  }
    
