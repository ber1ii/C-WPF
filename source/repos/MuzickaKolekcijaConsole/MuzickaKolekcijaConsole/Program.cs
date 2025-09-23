using System;

namespace MuzickaKolekcijaConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            MuzickaKolekcija kolekcija = new MuzickaKolekcija();
            kolekcija.UcitajPodatke("Ulaz.txt");

            Console.WriteLine(kolekcija);
            kolekcija.Sortiraj();

            Console.WriteLine("Kolekcija nakon sortiranja\n");
            Console.WriteLine(kolekcija);

            Pesma p1 = new Pesma(06, "unrequited", "Midrift", 130, 65);
            Pesma p2 = new Pesma(05, "Cchap Cchap", "Desingerica", 220, 80);

            Console.WriteLine("\nDodajemo u kolekciju pesmu p1(ocekivano true): " + (kolekcija.DodajPesmu(p1) ? "true" : "false"));
            Console.WriteLine("\nDodajemo u kolekciju pesmu p2(ocekivano false): " + (kolekcija.DodajPesmu(p2) ? "true" : "false"));
        
            Console.WriteLine("\nPronalazimo pesmu 03 na indexu: " + kolekcija.PronadjiPesmu(03));
            Console.WriteLine("\nPokusavamo pronaci pesmu 07, ne postoji ocekivan output -1: " + kolekcija.PronadjiPesmu(07));

            Console.WriteLine("Prosecno trajanje pesme: " + kolekcija.IzracunajProsecnoTrajanje());

            kolekcija.SacuvajPodatke("Izlaz.txt");
        }
    }
}