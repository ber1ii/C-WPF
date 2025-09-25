using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Buffers;

namespace VideotekaKlasa
{
    public class Videoteka
    {
        private Dictionary<int, Film> filmovi;

        public Videoteka()
        {
            filmovi = new Dictionary<int, Film>();
        }

        public Dictionary<int, Film> Filmovi
        {
            get { return filmovi; }
            set { filmovi = value; }
        }

        public bool DodajFilm(Film f)
        {
            foreach(Film existing in filmovi.Values)
            {
                if(f.Sifra == existing.Sifra || f.Naslov.Equals(existing.Naslov, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            filmovi.Add(f.Sifra, f);
            return true;
        }

        public bool IzmeniFilm(Film f)
        {
            foreach(Film existing in filmovi.Values)
            {
                if (f.Sifra != existing.Sifra && f.Naslov.Equals(existing.Naslov, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                foreach(Film other in filmovi.Values)
                {
                    if(other.Sifra == f.Sifra)
                    {
                        other.Naslov = f.Naslov;
                        other.Reziser = f.Reziser;
                        other.Godina = f.Godina;
                        other.Zanr = f.Zanr;
                    }
                }
            }
            return true;
        }

        public Film PronadjiFilm(int sifra)
        {
            if(filmovi.ContainsKey(sifra))
            {
                return filmovi[sifra];
            }

            return null;
        }

        public double IzracunajProsecnuGodinu()
        {
            double sum = 0;

            foreach(var f in filmovi.Values)
            {
                sum += f.Godina;
            }

            return sum / (double)filmovi.Count();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Filmovi:");
            sb.Append("\n---------------------------\n");

            foreach(Film f in filmovi.Values)
            {
                sb.Append(f.ToString()).Append("\n");
            }

            sb.Append("---------------------------");
            return sb.ToString();
        }

        public void UcitajPodatke(string imeFajla)
        {
            try
            {
                foreach (var line in File.ReadLines(imeFajla))
                {
                    string[] delovi = line.Split("|");
                    if (delovi.Length == 5)
                    {
                        var f = new Film(int.Parse(delovi[0]), delovi[1], delovi[2], int.Parse(delovi[3]), delovi[4]);
                        DodajFilm(f);
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine("Neuspesno ucitavanje fajla!" + ex.Message);
            }
        }

        public void SacuvajAkcione(string imeFajla)
        {
            var filmList = new List<Film>();
            filmList = filmovi.Values.ToList();

            var akcioni = filmList.Where(x => x.Zanr == "AKCIJA");

            using (StreamWriter sw  = new StreamWriter(imeFajla))
            {
                foreach(Film f in akcioni)
                {
                    sw.WriteLine($"{f.Naslov} - {f.Reziser}");
                }

                sw.WriteLine("-----------------------------------------------------");

                if(akcioni.Count() > 0)
                {
                    sw.WriteLine("Prosecna godina akcionih filmova je: " + akcioni.Average(x => x.Godina));
                }
            }
        }
    }
}
