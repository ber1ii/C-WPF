using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnjizaraConsole
{
    public class Knjiga
    {
        private int sifra;
        private string naslov;
        private string autor;
        private int godina;
        private double cena;

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

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public int Godina
        {
            get { return godina; }
            set { godina = value; }
        }

        public double Cena
        {
            get { return cena; }
            set {  cena = value; }
        }

        public Knjiga() { }

        public Knjiga(int sifra, string naslov, string autor, int godina, double cena)
        {
            Sifra = sifra;
            Naslov = naslov;
            Autor = autor;
            Godina = godina;
            Cena = cena;
        }

        public override string ToString()
        {
            return $"{Sifra} | {Naslov} | {Autor} | {Godina} | {Cena}";
        }
    }
}
