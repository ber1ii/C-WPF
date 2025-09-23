using System;
using CinemaConsole;

namespace CinemaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoTeka v = new VideoTeka();

            v.UcitajPodatkeFajl("Ulaz.txt");

            Console.WriteLine(">>> Nakon ucitavanja:");
            Console.WriteLine(v);

            Film novi = new Film(99, "Test Film", "Test Reziser", 2020, "AKCIJA");
            bool added = v.DodajFilm(novi);
            Console.WriteLine(added ? "Film dodat." : "Film već postoji.");

            Console.WriteLine(v);

            int position = v.PronadjiFilm(99);
            Console.WriteLine("Pozicija filma 99: " + position);

            Console.WriteLine("Prosečna godina svih filmova: " + v.IzracunajProsecnuGodinu());

            v.SacuvajAkcioneFilmove("Izlaz.txt");
            Console.WriteLine(">>> Sacuvan fajl Izlaz.txt sa akcijama.");

            Console.WriteLine("Kraj test programa.");
        }
    }
}