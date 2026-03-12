namespace Dane
{
    public enum Styl
    {
        Dowolny,
        Grzbietowy,
        Klasyczny,
        Motylkowy
    }
    public struct Wynik
    {
        public string Nazwisko { get; set; }
        public int Dystans { get; set; }
        public double Czas { get; set; }
        public decimal Nagroda { get; set; }
        public bool Rekord { get; set; }
        public Styl StylPływania { get; set; }

        public override string ToString()
        {
            return $"{Nazwisko}";
        }
    }
}
