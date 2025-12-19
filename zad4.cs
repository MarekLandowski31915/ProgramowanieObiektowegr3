class Osoba
{    public string Imie;
    public int Wiek;
    public void PrzedstawSie()
    {
        Console.WriteLine($"Cześć, nazywam się {Imie} i mam {Wiek} lat.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Osoba osoba1 = new Osoba();
        osoba1.Imie = "Jan";
        osoba1.Wiek = 30;
        osoba1.PrzedstawSie();

        Osoba osoba2 = new Osoba();
        osoba2.Imie = "Anna";
        osoba2.Wiek = 25;
        osoba2.PrzedstawSie();

        Osoba osoba3 = new Osoba { Imie = "Krzysztof", Wiek = 40 };
        osoba3.PrzedstawSie();
    }
}