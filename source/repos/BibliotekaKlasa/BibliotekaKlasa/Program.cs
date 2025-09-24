using System;

namespace BibliotekaKlasa
{
    class Program
    {
        public static void Main(string[] args)
        {
            Biblioteka bib = new Biblioteka();

            bib.UcitajPodatkeFajl("Ulaz.txt");

            Console.WriteLine(bib);

            Knjiga k1 = new Knjiga(110, "The Foundation", "Isaac Asimov", 1951, "ROMAN");
            Console.WriteLine("\nDodajemo knjigu k1 u biblioteku(ocekivano true): " + (bib.DodajKnjigu(k1) ? "true" : "false"));

            Knjiga k2 = new Knjiga(104, "A Game of Thrones", "George R.R. Martin", 1996, "ROMAN");
            Console.WriteLine("\nDodajemo knjigu k2 u biblioteku(ocekivano false): " + (bib.DodajKnjigu(k2) ? "true" : "false"));

            Console.WriteLine(bib);

            Console.WriteLine("\nProsecna godina izdavanja knjige: " + bib.IzracunajProsecnuGodinu());

            bib.SacuvajRomaneFajl("Izlaz.txt");
        }
    }
}