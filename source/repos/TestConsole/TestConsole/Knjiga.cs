using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Knjiga
    {
        public int Sifra {  get; set; }
        public string Naslov { get; set; }
        public string Autor {  get; set; }
        public int Godina { get; set; }
        public string Zanr { get; set; }

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
