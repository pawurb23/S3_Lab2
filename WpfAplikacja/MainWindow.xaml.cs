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
using Dane;

namespace WpfAplikacja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPobierz_Click(object sender, RoutedEventArgs e)
        {
            ListCoś.Items.Clear(); 
            foreach (Wynik w in Wynik.wartościPoczątkowe) { ListCoś.Items.Add(w); }
        }

        private void BtnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (ListCoś.SelectedIndex >= 0) { ListCoś.Items.RemoveAt(ListCoś.SelectedIndex); }
            else
            {
                MessageBox.Show("Wybierz coś, aby usunąć.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nazwisko = txtNazwisko.Text;
                int dystans = int.Parse(txtDystans.Text);
                double czas = double.Parse(txtCzas.Text);
                decimal nagroda = decimal.Parse(txtNagroda.Text);
                string? klub = string.IsNullOrWhiteSpace(txtKlub.Text) ? null : txtKlub.Text;
                bool rekord = chkRekord.IsChecked == true;

                Styl styl = Styl.Dowolny;
                if (rbGrzbietowy.IsChecked == true) styl = Styl.Grzbietowy;
                else if (rbKlasyczny.IsChecked == true) styl = Styl.Klasyczny;
                else if (rbMotylkowy.IsChecked == true) styl = Styl.Motylkowy;
                else if (rbZmienny.IsChecked == true) styl = Styl.Zmienny;

                Wynik nowyWynik = new Wynik(nazwisko, dystans, czas, nagroda, rekord, styl, klub);

                foreach (var item in ListCoś.Items)
                {
                    if (item is Wynik istniejacyWynik)
                    {
                        if (istniejacyWynik == nowyWynik)
                        {
                            MessageBox.Show("Wynik jest już na liście!", "Duplikat", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return; 
                        }
                    }
                }

                ListCoś.Items.Add(nowyWynik);

                txtNazwisko.Clear(); txtDystans.Clear(); txtCzas.Clear(); txtNagroda.Clear(); txtKlub.Clear(); 
                chkRekord.IsChecked = false; rbDowolny.IsChecked = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Dystans, czas i nagroda to dane liczbowe!", "Złe dane!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Zła wartość", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Zła wartość", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił nieoczekiwany błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}