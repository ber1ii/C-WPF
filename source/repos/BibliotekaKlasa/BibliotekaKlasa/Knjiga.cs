using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlasa
{
    public class Knjiga
    {
        private int sifra;
        private string naslov;
        private string autor;
        private int godina;
        private string zanr;

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

        public string Zanr
        {
            get { return zanr; }
            set { zanr = value; }
        }

        public Knjiga() { }

        public Knjiga(int sifra, string naslov, string autor, int godina, string zanr)
        {
            Sifra = sifra;
            Naslov = naslov;
            Autor = autor;
            Godina = godina;
            Zanr = zanr;
        }

        public override string ToString()
        {
            return $"{Sifra} | {Naslov} | {Autor} | {Godina} | {Zanr}";
        }
    }
}
