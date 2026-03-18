namespace Dane
{
    public enum Styl
    {
        Dowolny,
        Grzbietowy,
        Klasyczny,
        Motylkowy,
        Zmienny
    }
    public struct Wynik
    {
        private static int _Licznik = 0;
        public int Id { get; }

        private string _nazwisko;
        private int _dystans;
        private double _czas;
        private decimal _nagroda;
        public bool Rekord { get; set; }
        public Styl StylPływania { get; set; }
        public string? Klub { get; set; }

        public string Nazwisko
        {
            readonly get => _nazwisko;
            set 
            {                
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Nazwisko nie może być puste!");
                _nazwisko = value;
            }
        }

        public int Dystans 
        { 
            readonly get => _dystans;
            set
            {
                if (value != 50 && value != 100 && value != 200) throw new ArgumentOutOfRangeException(nameof(value), "Nieprawidłowy dystans!");
                _dystans = value;
            }
        }

        public double Czas
        {
            readonly get => _czas;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "Czas nie może być ujemny!");
                _czas = value;
            }
        }

        public decimal Nagroda
        {
            readonly get => _nagroda;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Nagroda musi być większa od 0!");
                _nagroda = value;
            }
        }

        public Wynik()
        {
            _Licznik++;
            Id = _Licznik;
            
            _nazwisko = "Nieznany";
            _dystans = 50;
            _czas = 1.0;
            _nagroda = 0m;
            Rekord = false;
            StylPływania = Styl.Dowolny;
            Klub = null;
        }

        public Wynik(string nazwisko, int dystans, double czas, decimal nagroda, bool rekord, Styl stylPływania, string? klub = null)
            :this()
        {
            Nazwisko = nazwisko;
            Dystans = dystans;
            Czas = czas;
            Nagroda = nagroda;
            Rekord = rekord;
            StylPływania = stylPływania;
            Klub = klub;
        }

        public void ZwiekszNagrode(decimal bonus)
        {
            if (bonus < 0) throw new ArgumentOutOfRangeException(nameof(bonus), "Bonus musi być wartością dodatnią.");
            Nagroda += bonus;
        }

        public static bool operator ==(Wynik w1, Wynik w2)
        {
            return w1.Nazwisko == w2.Nazwisko && w1.Dystans == w2.Dystans && w1.Czas == w2.Czas && w1.Nagroda == w2.Nagroda && 
                w1.Rekord == w2.Rekord && w1.StylPływania == w2.StylPływania && w1.Klub == w2.Klub;
        }

        public static bool operator !=(Wynik w1, Wynik w2)
        {
            return !(w1 == w2);
        }

        public override string ToString()
        {
            string przynaleznosc = Klub != null ? $" ({Klub})" : " (Niezrzeszony)";
            return $"{Nazwisko}{przynaleznosc}";
        }

        public static Wynik[] wartościPoczątkowe = new Wynik[]
        {
            new Wynik("Sieradzki", 200, 101.48, 5000, true, Styl.Dowolny, "AZS AWF Katowice"),
            new Wynik("Masiuk", 100, 50.80, 3000, false, Styl.Grzbietowy, "KU AZS Uniwersytetu Warszawskiego"),
            new Wynik("Kozan", 400, 268.56, 5000, true, Styl.Zmienny),

            new Wynik() {Nazwisko = "Wasick", Dystans = 50, Czas = 24.11, Nagroda = 3000m, Rekord = false,
                StylPływania = Styl.Dowolny, Klub = "AZS AWF Katowice"
            },
            new Wynik() {Nazwisko = "Jędrzejczak", Dystans = 200, Czas = 125.61, Nagroda = 8000, Rekord = true,
                StylPływania = Styl.Motylkowy, Klub = "AZS AWF Warszawa"},
            new Wynik() {Nazwisko = "Sztandera", Dystans = 50, Czas = 29.22, Nagroda = 1000, Rekord = true,
                StylPływania = Styl.Klasyczny, Klub = "MKS Juvenia Wrocław"}
        }; 
    }
}
