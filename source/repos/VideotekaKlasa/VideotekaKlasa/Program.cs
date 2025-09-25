using System;

namespace VideotekaKlasa
{
    class Program
    {
        static void Main(string[] args)
        {
            Videoteka cinema = new Videoteka();

            cinema.UcitajPodatke("Ulaz.txt");

            Console.WriteLine(cinema);

            Film f1 = new Film(06, "BlacKKKlansman", "IDK", 2018, "COMEDY");
            Film f2 = new Film(04, "Star Wars", "IDK", 2018, "COMEDY");

            Console.WriteLine("Dodajemo film f1 (ocekivano true) " + (cinema.DodajFilm(f1) ? "true" : "false"));
            Console.WriteLine("Dodajemo film f2 (ocekivano false) " + (cinema.DodajFilm(f2) ? "true" : "false"));

            Console.WriteLine("Film 03 pronadjen: " + cinema.PronadjiFilm(03));

            Console.WriteLine("Prosecna godina izdanja filma je:" + cinema.IzracunajProsecnuGodinu());

            cinema.SacuvajAkcione("Izlaz.txt");
        }
    }
}