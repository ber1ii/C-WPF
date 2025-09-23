using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaKolekcijaConsole
{
    public class MuzickaKolekcija
    {
        private List<Pesma> pesme;

        public MuzickaKolekcija()
        {
            pesme = new List<Pesma>();
        }

        public List<Pesma> Pesme
        {
            get { return pesme; }
            set { pesme = value; }
        }

        public bool DodajPesmu(Pesma p)
        {
            if(pesme.Any(x => x.Sifra == p.Sifra))
            {
                return false;
            }

            pesme.Add(p);
            return true;
        }

        public int PronadjiPesmu(int sifra)
        {
            return pesme.FindIndex(p => p.Sifra == sifra);
        }

        public double IzracunajProsecnoTrajanje()
        {
            if(pesme.Count == 0)
            {
                return 0.0;
            }

            double sum = 0;

            foreach(Pesma p in pesme)
            {
                sum += p.Trajanje;
            }

            double avg = sum / pesme.Count;
            return avg;
        }


        public void Sortiraj()
        {
            pesme.Sort((a, b) => b.Popularnost.CompareTo(a.Popularnost));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Pesme u kolekciji:\n");

            foreach(Pesma p in pesme)
            {
                sb.Append(p.ToString()).Append("\n");
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
                    if(delovi.Length == 5)
                    {
                        var p = new Pesma(int.Parse(delovi[0]), delovi[1], delovi[2], int.Parse(delovi[3]), int.Parse(delovi[4]));
                        DodajPesmu(p);
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine("Greska pri ucitavanju fajla!\n");
                Console.WriteLine(e.Message);
            }
        }

        public void SacuvajPodatke(string ImeFajla)
        {
            int sum = 0;

            foreach(Pesma p in pesme)
            {
                sum += p.Popularnost;
            }

            int avg = sum / pesme.Count;

            using (StreamWriter sw = new StreamWriter(ImeFajla))
            {
                foreach(Pesma p in pesme)
                {
                    if(p.Popularnost > avg)
                    {
                        sw.WriteLine($"{p.Izvodjac} - {p.Naslov} ({p.Popularnost})");
                    }
                }

                sw.WriteLine("----------------------------");
                sw.WriteLine($"Prosecna popularnost:{avg:0.0}");
            }
        }
    }
}
