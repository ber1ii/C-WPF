using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoservisConsole
{
    public class Vozilo
    {
        private int sifra;
        private string marka;
        private string model;
        private int godiste;
        private double troskoviServisa;

        public int Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Godiste
        {
            get { return godiste; }
            set { godiste = value; }
        }

        public double TroskoviServisa
        {
            get { return troskoviServisa; }
            set { troskoviServisa = value; }
        }

        public Vozilo() { }

        public Vozilo(int sifra, string marka, string model, int godiste, double troskoviServisa)
        {
            Sifra = sifra;
            Marka = marka;
            Model = model;
            Godiste = godiste;
            TroskoviServisa = troskoviServisa;
        }

        public override string ToString()
        {
            return $"{Sifra} | {Marka} | {Model} | {Godiste} | {TroskoviServisa}";
        }
    }
}
