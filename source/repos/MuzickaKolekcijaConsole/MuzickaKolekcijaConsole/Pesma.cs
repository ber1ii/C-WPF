using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaKolekcijaConsole
{
    public class Pesma
    {
        private int sifra;
        private string naslov;
        private string izvodjac;
        private int trajanje;
        private int popularnost;

        public int Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

        public string Naslov
        {
            get { return naslov; }
            set { naslov = value; }
        }

        public string Izvodjac
        {
            get { return izvodjac; }
            set { izvodjac = value; }
        }

        public int Trajanje
        {
            get { return trajanje; }
            set { trajanje = value; }
        }

        public int Popularnost
        {
            get { return popularnost; }
            set { popularnost = value; }
        }

        public Pesma() { }

        public Pesma(int sifra, string naslov, string izvodjac, int trajanje, int popularnost)
        {
            Sifra = sifra;
            Naslov = naslov;
            Izvodjac = izvodjac;
            Trajanje = trajanje;
            Popularnost = popularnost;
        }

        public override string ToString()
        {
            return $"{Sifra} | {Naslov} | {Izvodjac} | {Trajanje} | {Popularnost}";
        }
    }
}
