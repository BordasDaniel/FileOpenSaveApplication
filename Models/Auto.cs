using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOpenSaveApplication.Models
{
    internal class Auto
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Tipus { get; set; }
        public string Szin { get; set; }
        public int Evjarat { get; set; }
        public DateOnly Muszaki { get; set; }
        public bool Aktiv { get; set; }

        public Auto() { }

        public Auto(int id, string marka, string tipus, string szin, int evjarat, DateOnly muszaki, bool aktiv)
        {
            Id = id;
            Marka = marka;
            Tipus = tipus;
            Szin = szin;
            Evjarat = evjarat;
            Muszaki = muszaki;
            Aktiv = aktiv;
        }

        public Auto(string AdatSor)
        {
            string[] Adatok = AdatSor.Split(';');
            Id = int.Parse(Adatok[0]);
            Marka = Adatok[1];
            Tipus = Adatok[2];
            Szin = Adatok[3];
            Evjarat = int.Parse(Adatok[4]);
            Muszaki = DateOnly.Parse(Adatok[5]);
            Aktiv = bool.Parse(Adatok[6]);
        }

        public override string ToString()
        {
            return $"{Id}: {Marka}: {Tipus}";
        }

    }
}
