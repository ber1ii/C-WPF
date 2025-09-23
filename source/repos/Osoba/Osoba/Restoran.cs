using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoba
{
    public class Restoran
    {
        private string naziv;
        private string adresa;
        private List<Stavka> jelovnik;

        #region props
        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
            }
        }

        public string Adresa
        {
            get
            {
                return adresa;
            }

            set
            {
                adresa = value;
            }
        }

        #endregion

        public Restoran(string naziv, string adresa)
        {
            Naziv = naziv;
            Adresa = adresa;
            jelovnik = new List<Stavka>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Restoran ").Append(Naziv).Append("\n");
            sb.Append("Adresa: ").Append(Adresa).Append("\n");
            
            if(jelovnik.Count == 0)
            {
                sb.Append("Jelovnik je prazan");
            } else
            {
                sb.Append("Jelovnik:");
                sb.Append("\n******************\n");
                foreach (Stavka s in jelovnik)
                {
                    sb.Append(s).Append("\n");
                }
                sb.Append("******************");
            }

                return sb.ToString();
        }

        public bool dodajStavku(Stavka s)
        {
            if(jelovnik.Any(x => x.Naziv == s.Naziv)) {
                return false;
            }

            jelovnik.Add(s);
            return true;
        }

        public void Import(string ImeFajla)
        {
            try
            {
                foreach (var line in File.ReadLines(ImeFajla))
                {
                    var delovi = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                    if (delovi.Length >= 2 && double.TryParse(delovi[1].Trim(), out double cena))
                    {
                        string naziv = delovi[0].Trim();
                        dodajStavku(new Stavka(naziv, cena));
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public void Sortiraj()
        {
            jelovnik.Sort((a, b) => b.Cena.CompareTo(a.Cena));
        }

        public void Export(string ImeFajla)
        {
            using (StreamWriter sw = new StreamWriter(ImeFajla))
            {
                sw.WriteLine(this.ToString());
            }
        }
    }
}
