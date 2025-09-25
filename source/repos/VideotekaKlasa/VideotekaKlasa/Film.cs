using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideotekaKlasa
{
    public class Film
    {
        private int sifra;
        private string naslov;
        private string reziser;
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

        public string Reziser
        {
            get { return reziser; }
            set { reziser = value; }
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

        public Film() { }

        public Film(int sifra, string naslov, string reziser, int godina, string zanr)
        {
            Sifra = sifra;
            Naslov = naslov;
            Reziser = reziser;
            Godina = godina;
            Zanr = zanr;
        }

        public override string ToString()
        {
            return $"{Sifra} | {Naslov} | {Reziser} | {Godina} | {Zanr}";
        }
    }
}
