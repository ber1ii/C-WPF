using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoservisConsole
{
    public class Autoservis
    {
        private Dictionary<int, Vozilo> autoservis;

        public Autoservis()
        {
            autoservis = new Dictionary<int, Vozilo>();
        }

        public bool DodajVozilo(Vozilo v)
        {
            if(autoservis.Any(x => x.Key == v.Sifra))
            {
                return false;
            }

            autoservis.Add(v.Sifra, v);
            return true;
        }

        public Vozilo PronadjiVozilo(int sifra)
        {
            if(autoservis.ContainsKey(sifra))
            {
                return autoservis[sifra];
            }

            return null;
        }

        public double IzracunajProsecneTroskove()
        {
            if(autoservis.Count == 0)
            {
                return 0.0;
            }

            double sum = 0;

            foreach(var v in autoservis.Values)
            {
                sum += v.TroskoviServisa;
            }

            double avg = sum / autoservis.Count;

            return avg;
        }

        public void Sortiraj()
        {
            List<Vozilo> vozila = new List<Vozilo>();

            foreach (var v in autoservis.Values)
            {
                vozila.Add(v);
            }

            vozila.Sort((a, b) => b.TroskoviServisa.CompareTo(a.TroskoviServisa));

            var newAutoservis = new Dictionary<int, Vozilo>();
            foreach(Vozilo v in vozila)
            {
                newAutoservis[v.Sifra] = v;
            }

            autoservis = newAutoservis;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if(autoservis.Count == 0)
            {
                sb.Append("Lista je prazna!");
                return sb.ToString();
            }

            sb.Append("Autoservis:");
            sb.Append("\n----------------------\n");
            foreach(var v in autoservis.Values)
            {
                sb.Append(v.ToString()).Append("\n");
            }

            sb.Append("----------------------");
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
                        var v = new Vozilo(int.Parse(delovi[0]), delovi[1], delovi[2], int.Parse(delovi[3]), int.Parse(delovi[4]));
                        DodajVozilo(v);
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine("Neuspesno ucitavanje fajla!\n");
                Console.WriteLine(e.Message);
            }
        }

        public void SacuvajSkupeServise(string ImeFajla)
        {
            double avg = IzracunajProsecneTroskove();

            using (StreamWriter sw = new StreamWriter(ImeFajla))
            {
                foreach(var v in autoservis.Values)
                {
                    if(v.TroskoviServisa > avg)
                    {
                        sw.WriteLine($"{v.Marka} {v.Model} - {v.TroskoviServisa}");
                    }
                }

                sw.WriteLine("------------------------------------");
                sw.WriteLine($"Prosecni troskovi servisa: {avg:0.0}");
            }
        }
    }
}
