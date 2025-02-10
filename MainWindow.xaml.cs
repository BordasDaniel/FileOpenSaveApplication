using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.Generic;
using FileOpenSaveApplication.Models;
using Microsoft.Win32;

namespace FileOpenSaveApplication
{
    public partial class MainWindow : Window
    {
        static List<Auto> autok = new();

        public MainWindow()
        {
            InitializeComponent();


        }

        private void Beolvas(string allomany)
        {
            try
            {
                using (StreamReader olvas = new(allomany, Encoding.Default))
                {
                    olvas.ReadLine();
                    string sor;

                    while ((sor = olvas.ReadLine()) != null)
                    {
                        autok.Add(new(sor));
                    }
                }
                MessageBox.Show("Sikeres beolvasás!");
            }
            catch (FormatException fex)
            {
                MessageBox.Show($"Hibás adatformátum {fex.Message}!");
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show($"A fájl nem található: {allomany}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt: {ex.Message}");
            }
        }

        private void Beolvasas_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new();
            fileDialog.Filter = "Szöveges fájlok|*.txt|CSV fájlok|*.csv|Összes fájl|*.*";
            
            if (fileDialog.ShowDialog().Value)
            {
                Beolvas(fileDialog.FileName);
                lbAutok.Items.Clear();
                lbAutok.ItemsSource = autok;

                //dgAutok.Items.Clear();
                //dgAutok.ItemsSource = autok;
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott állomány!");
            }
        }

        private void lbAutok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbAutok.SelectedItem != null)
            {
                Auto a = (Auto)lbAutok.SelectedItem;
                tbkId.Text = a.Id.ToString();
                tbkMarka.Text = a.Marka;
                tbkTipus.Text = a.Tipus;
                tbkSzin.Text = a.Szin;
                tbkEvjarat.Text = a.Evjarat.ToString();
                tbkMuszaki.Text = a.Muszaki.ToString();
                cbxAktiv.IsChecked = a.Aktiv;
            }
        }
    }
}
