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
using BibliotekaKlasa;
using System.IO;

namespace BibliotekaWPF
{
    public partial class MainWindow : Window
    {
        private Biblioteka bib;
        public MainWindow()
        {
            InitializeComponent();

            //init
            bib = new Biblioteka();

            bib.UcitajPodatkeFajl("Ulaz.txt");
            dgKnjige.ItemsSource = bib.Knjige;

            cbKnjige.ItemsSource = bib.Knjige;
            cbKnjige.DisplayMemberPath = "Naslov";
            cbKnjige.SelectedValuePath = "Sifra";
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int sifra = int.Parse(txbSifra.Text);
                string naslov = txbNaslov.Text.Trim();
                string autor = txbAutor.Text.Trim();
                int godina = int.Parse(txbGodina.Text);
                string zanr = txbZanr.Text.Trim();

                Knjiga k = new Knjiga(sifra, naslov, autor, godina ,zanr);

                bool added = bib.DodajKnjigu(k);

                if(!added)
                {
                    MessageBox.Show("Vec postoji knjiga sa tom sifrom ili naslovom!", "Greska");
                }
                else
                {
                    MessageBox.Show("Uspesno dodata knjiga!", "Info");
                    dgKnjige.Items.Refresh();
                }

            } catch(Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }
        private void cbKnjige_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbKnjige.SelectedItem is Knjiga selected)
            {
                txbRemoveNaslov.Text = selected.Naslov;
                txbRemoveAutor.Text = selected.Autor;
                txbRemoveGodina.Text = selected.Godina.ToString();
                txbRemoveZanr.Text = selected.Zanr;
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if(cbKnjige.SelectedItem is Knjiga selected)
            {
                try
                {
                    Knjiga nova = new Knjiga(selected.Sifra, txbRemoveNaslov.Text.Trim(),
                        txbRemoveAutor.Text.Trim(), int.Parse(txbRemoveGodina.Text), txbRemoveZanr.Text.Trim());

                    bool success = bib.IzmeniKnjigu(nova);

                    if(success)
                    {
                        MessageBox.Show("Uspesna izmena!");
                        cbKnjige.Items.Refresh();
                        dgKnjige.Items.Refresh();
                    } else
                    {
                        MessageBox.Show("Izmena neuspesna (naslov mozda vec postoji)!");
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show("Greska: " + ex.Message);
                }
            }
        }
    }
}