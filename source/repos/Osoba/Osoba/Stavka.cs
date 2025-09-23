using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoba
{
    public class Stavka
    {
        private string naziv;
        private double cena;

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

        public double Cena
        {
            get
            {
                return cena;
            }

            set
            {
                cena = value;
            }
        }

        #endregion

        public Stavka(string naziv, double cena)
        {
            Naziv = naziv;
            Cena = cena;
        }

        public override string ToString()
        {
            return $"{Naziv} {Cena:0.0}";
        }
    }
}
