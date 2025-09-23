using System;

namespace KnjizaraConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            Knjizara bookStore = new Knjizara();
            Knjizara bookStore2 = new Knjizara();
            Knjizara emptyStore = new Knjizara();

            bookStore.UcitajPodatke("Ulaz.txt");

            Console.WriteLine(bookStore);

            Console.WriteLine("Prosecna cena knjige: " + bookStore.IzracunajProsecnuCenu());
            Console.WriteLine("Prosecna cena u praznoj knjizari (ocekivano 0.0): " + emptyStore.IzracunajProsecnuCenu());

            Knjiga k1 = new Knjiga(99, "The Hobbit", "J.R.R Tolkien", 1937, 673.5);
            Knjiga k2 = new Knjiga(99, "The Nigga", "J.R.R Tolkien", 1937, 673.5);
            bookStore.DodajKnjigu(k1);

            Console.WriteLine(bookStore);

            Console.WriteLine(bookStore.DodajKnjigu(k2) ? "Uspesno dodavanje" : "Neuspesno dodavanje");

            Console.WriteLine("Uspesno pronadjena knjiga 99 na poziciji: " + bookStore.PronadjiKnjigu(99));

            Console.WriteLine("Neuspesno: " + bookStore.PronadjiKnjigu(152));

            bookStore.SacuvajPodatke("Izlaz.txt");

            bookStore2.UcitajPodatke("Pogresan.txt");
            Console.WriteLine(bookStore2);
        }
    }
}