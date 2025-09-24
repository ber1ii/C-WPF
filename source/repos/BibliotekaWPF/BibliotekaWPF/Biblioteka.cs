using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BibliotekaKlasa
{
    public class Biblioteka
    {
        private List<Knjiga> knjige;

        public Biblioteka()
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
            if(knjige.Any(x => x.Sifra == k.Sifra || x.Naslov == k.Naslov))
            {
                return false;
            }

            knjige.Add(k);
            return true;
        }

        public int PronadjiKnjigu(int sifra)
        {
            return knjige.FindIndex(x => x.Sifra == sifra);
        }

        public bool IzmeniKnjigu(Knjiga k)
        {
            foreach(Knjiga other in knjige)
            {
                if(other.Sifra != k.Sifra &&  other.Naslov.Equals(k.Naslov, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            foreach(Knjiga trenutna in knjige)
            {
                if(trenutna.Sifra == k.Sifra)
                {
                    trenutna.Naslov = k.Naslov;
                    trenutna.Autor = k.Autor;
                    trenutna.Godina = k.Godina;
                    trenutna.Zanr = k.Zanr;

                    return true;
                }
            }

            return false;
        }

        public double IzracunajProsecnuGodinu()
        {
            if(knjige.Count == 0)
            {
                return 0.0;
            }

            double sum = 0;

            foreach(Knjiga k in knjige)
            {
                sum += k.Godina;
            }

            double avg = sum / knjige.Count;
            return avg;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Biblioteka:");
            sb.Append("\n------------------------\n");

            foreach(Knjiga k in knjige)
            {
                sb.Append(k.ToString()).Append("\n");
            }
            sb.Append("------------------------");

            return sb.ToString();
        }

        public void UcitajPodatkeFajl(string imeFajla)
        {
            try
            {
                foreach (var line in File.ReadLines(imeFajla))
                {
                    string[] delovi = line.Split("|");

                    if (delovi.Length == 5)
                    {
                        var k = new Knjiga(int.Parse(delovi[0]), delovi[1], delovi[2], int.Parse(delovi[3]), delovi[4]);
                        DodajKnjigu(k);
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine("Neuspesno ucitavanje fajla!\n");
                Console.WriteLine(e.Message);
            }
        }

        public void SacuvajRomaneFajl(string imeFajla)
        {
            var romani = knjige.Where(x => x.Zanr == "ROMAN").ToList();

            using (StreamWriter sw = new StreamWriter(imeFajla))
            {
                foreach (var r in romani)
                {
                    sw.WriteLine($"{r.Naslov} - {r.Autor}");
                }

                if(romani.Count > 0)
                {
                    double avg = romani.Average(x => x.Godina);
                    sw.WriteLine("\n----------------------------------------\n");
                    sw.WriteLine("Prosecna godina izdanja romana: " + avg.ToString());
                }
            }
        }
    }
}
