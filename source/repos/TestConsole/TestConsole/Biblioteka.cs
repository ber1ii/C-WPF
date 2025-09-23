using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Biblioteka
    {
        public List<Knjiga> knjige {  get; set; }

        public Biblioteka () {
            knjige = new List<Knjiga>();
        }

        public bool DodajKnjigu(Knjiga k)
        {
            if(knjige.Exists(b => b.Sifra == k.Sifra || b.Naslov == k.Naslov))
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

        public double IzracunajProsecnuGodinu()
        {
            if(knjige.Count == 0) { return 0.0; }

            return knjige.Average(b => b.Godina);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, knjige);
        }

        public void UcitajPodatkeFajl(string imeFajla)
        {
            foreach(var line in File.ReadLines(imeFajla))
            {
                var delovi = line.Split("|");
                if(delovi.Length == 5)
                {
                    var k = new Knjiga(int.Parse(delovi[0]),
                            delovi[1],
                            delovi[2],
                            int.Parse(delovi[3]),
                            delovi[4]
                        );
                    DodajKnjigu(k);
                }
            }
        }

        public void SacuvajRomaneFajl(string imeFajla2)
        {
            var romani = knjige.Where(b => b.Zanr == "ROMAN").ToList();

            using (StreamWriter sw = new StreamWriter(imeFajla2))
            {
                foreach(var r in romani)
                {
                    sw.WriteLine($"{r.Naslov} - {r.Autor}");
                }

                if (romani.Count > 0)
                {
                    double prosek = romani.Average(b => b.Godina);
                    sw.WriteLine("----------------------------");
                    sw.WriteLine($"Prosecna godina izdanja romana: {Math.Round(prosek)}");
                }
            }
        }
    }
}
