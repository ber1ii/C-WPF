using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnjizaraConsole
{
    public class Knjizara
    {
        private List<Knjiga> knjige;

        public Knjizara()
        {
            knjige = new List<Knjiga>();
        }

        public List<Knjiga> Knjige
        {
            get { return knjige; }

            set { knjige = value; }
        }

        public bool DodajKnjigu(Knjiga k)
        {
            if(knjige.Any(b => b.Sifra == k.Sifra))
            {
                return false;
            }

            knjige.Add(k);
            return true;
        }

        public int PronadjiKnjigu(int sifra)
        {
            return knjige.FindIndex(b => b.Sifra == sifra);
        }

        public double IzracunajProsecnuCenu()
        {
            if(knjige.Count == 0)
            {
                return 0.0;
            }
            double sum = 0;

            foreach(Knjiga k in knjige)
            {
                sum += k.Cena;
            }

            return (sum / knjige.Count);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (knjige.Count == 0)
            {
                sb.Append("PRAZNA LISTA!");
                return sb.ToString();
            }


            foreach (Knjiga k in knjige)
            {
                sb.Append(k.ToString()).Append("\n");
            }

            return sb.ToString();
        }

        public void UcitajPodatke(string ImeFajla)
        {
            try
            {
                foreach (var line in File.ReadLines(ImeFajla))
                {
                    var delovi = line.Split('|');
                    if (delovi.Length == 5)
                    {
                        var k = new Knjiga(int.Parse(delovi[0]), delovi[1], delovi[2], int.Parse(delovi[3]), double.Parse(delovi[4]));

                        DodajKnjigu(k);
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine("Greska pri ucitavanju fajla: \n" + e.Message);
            }
        }

        public void SacuvajPodatke(string ImeFajla)
        {
            double prosek = IzracunajProsecnuCenu();
            var skupljeKnjige = knjige.Where(k => k.Cena > prosek);

            using (StreamWriter sw = new StreamWriter(ImeFajla))
            {
                foreach(Knjiga k in skupljeKnjige)
                {
                    sw.WriteLine($"{k.Naslov} - {k.Autor}");
                }

                sw.WriteLine("------------------------------------");
                sw.WriteLine($"Prosecna cena knjiga: {prosek:0.0}");
            }
        }
    }
}
