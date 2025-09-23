using System;

namespace AutoservisConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            Autoservis servis = new Autoservis();

            servis.UcitajPodatke("Ulaz.txt");

            Console.WriteLine(servis);

            Vozilo v1 = new Vozilo(07, "Nissan", "240sx", 1995, 47000);
            Console.WriteLine("\nDodajemo vozilo v1 u autoservis(ocekivano true): " + (servis.DodajVozilo(v1) ? "true" : "false"));

            Vozilo v2 = new Vozilo(03, "Mercedes", "C180 Kompressor", 2002, 20000);
            Console.WriteLine("\nPokusavamo dodati vozilo v2 u autoservis(ocekivano false)" + (servis.DodajVozilo(v2) ? "true" : "false"));

            Console.WriteLine(servis);

            Console.WriteLine("\nVozilo 02 pronadjeno: " + servis.PronadjiVozilo(02));
            if(servis.PronadjiVozilo(08) == null)
            {
                Console.WriteLine("\nVozilo 08 nije moguce pronaci");
            }

            servis.Sortiraj();

            Console.WriteLine("Sortiramo servis: \n");
            Console.WriteLine(servis);

            servis.SacuvajSkupeServise("Izlaz.txt");
        }
    }
}