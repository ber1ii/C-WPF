using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main()
        {
            Biblioteka bib = new Biblioteka();

            // Test dodavanja
            bib.DodajKnjigu(new Knjiga(101, "Na Drini Cuprija", "Ivo Andric", 1945, "ROMAN"));
            bib.DodajKnjigu(new Knjiga(102, "Istorija sveta", "Marko Popovic", 2001, "ISTORIJA"));
            bib.DodajKnjigu(new Knjiga(103, "Pesme", "Desanka Maksimovic", 1965, "POEZIJA"));
            bib.DodajKnjigu(new Knjiga(104, "The Foundation", "Isaac Asiimov", 1951, "ROMAN"));

            Console.WriteLine("=== Sve knjige ===");
            Console.WriteLine(bib);

            Console.WriteLine("\nProsecna godina: " + bib.IzracunajProsecnuGodinu());

            int pos = bib.PronadjiKnjigu(104);
            Console.WriteLine("\nPronadjen Rat i Mir na poziciji: " + pos);

            bib.UcitajPodatkeFajl("Ulaz.txt");
            bib.SacuvajRomaneFajl("Izlaz.txt");
        }
    }
}
