using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaConsole
{
    public class VideoTeka
    {
        private List<Film> filmovi;

        public List<Film> Filmovi
        {
            get {  return filmovi; }
            set { filmovi = value; }
        }
        public VideoTeka()
        {
            filmovi = new List<Film>();
        }

        public bool DodajFilm(Film f)
        {
            if(filmovi.Any(x => x.Sifra == f.Sifra))
            {
                return false;
            }

            filmovi.Add(f);
            return true;
        }

        public int PronadjiFilm(int sifra)
        {
            return filmovi.FindIndex(x => x.Sifra == sifra);
        }

        public int IzracunajProsecnuGodinu()
        {
            int sum = 0;
            
            foreach(Film f in filmovi)
            {
                sum += f.Godina;
            }

            int avg = 0;
            avg = (sum / filmovi.Count);

            return avg;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Videoteka: \n");

            foreach(Film f in filmovi)
            {
                sb.Append(f.ToString()).Append("\n");
            }

            return sb.ToString();
        }

        public void UcitajPodatkeFajl(string ImeFajla)
        {
            foreach(var line in File.ReadLines(ImeFajla))
            {
                var delovi = line.Split('|');
                if(delovi.Length == 5)
                {
                    var k = new Film(int.Parse(delovi[0]), delovi[1], delovi[2], int.Parse(delovi[3]), delovi[4]);
                    DodajFilm(k);
                }
            }
        }

        public void SacuvajAkcioneFilmove(string ImeFajla)
        {
            var films = filmovi.Where(x => x.Zanr.ToUpper() == "AKCIJA").ToList();

            using (StreamWriter sw = new StreamWriter(ImeFajla))
            {
                foreach(var f in films)
                {
                    sw.WriteLine($"{f.Naslov} - {f.Reziser}");
                }

                if(filmovi.Count > 0)
                {
                    sw.WriteLine("***************************");
                    sw.WriteLine("\nProsecna godina izdanja filma: " + Math.Round(films.Average(f => f.Godina)));
                }
            }
        }
    }
}
