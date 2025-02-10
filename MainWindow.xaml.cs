﻿using System.Text;
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
        private List<Auto> autok = new();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Beolvas(string allomany)
        {
            try
            {
                using (StreamReader olvas = new(allomany))
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
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott állomány!");
            }
        }
    }
}
