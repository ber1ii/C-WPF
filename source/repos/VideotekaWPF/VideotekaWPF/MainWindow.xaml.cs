using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideotekaKlasa;
using System.IO;

namespace VideotekaWPF
{
    public partial class MainWindow : Window
    {
        Videoteka cinema;

        public MainWindow()
        {
            InitializeComponent();

            cinema = new Videoteka();
            cinema.UcitajPodatke("Ulaz.txt");

            dgFilmovi.ItemsSource = cinema.Filmovi.Values.ToList();
            cmbFilmovi.ItemsSource = cinema.Filmovi.Values.ToList();

            cmbFilmovi.DisplayMemberPath = "Naslov";
            //cmbFilmovi.SelectedValuePath = "Sifra";
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int sifra = int.Parse(txbSifra.Text);
                string naslov = txbNaslov.Text.Trim();
                string reziser = txbReziser.Text.Trim();
                int godina = int.Parse(txbGodina.Text);
                string zanr = txbZanr.Text.Trim();

                Film f = new Film(sifra, naslov, reziser, godina, zanr);

                bool added = cinema.DodajFilm(f);
                dgFilmovi.ItemsSource = null;
                dgFilmovi.ItemsSource = cinema.Filmovi.Values.ToList();

                if (added)
                {
                    MessageBox.Show("Uspesno dodavanje");
                }
                else
                {
                    MessageBox.Show("Nije uspelo dodavanje (mozda isti film vec postoji)!");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if(cmbFilmovi.SelectedItem is Film selected)
            {
                try
                {
                    Film novi = new Film(selected.Sifra, txbNaslovIzmena.Text.Trim(), txbReziserIzmena.Text.Trim(),
                        int.Parse(txbGodinaIzmena.Text), txbZanrIzmena.Text.Trim());
                    
                    bool success = cinema.IzmeniFilm(novi);
                    dgFilmovi.ItemsSource = null;
                    dgFilmovi.ItemsSource = cinema.Filmovi.Values.ToList();
                    if(success)
                    {
                        MessageBox.Show("Uspesnsa izmena!");
                    } else
                    {
                        MessageBox.Show("Nije uspela izmena (mozda isti film vec postoji)!");
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}