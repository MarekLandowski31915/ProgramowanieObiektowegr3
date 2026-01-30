using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

[JsonDerivedType(typeof(Programista), typeDiscriminator: "Programista")]
[JsonDerivedType(typeof(Ksiegowa), typeDiscriminator: "Ksiegowa")]
public abstract class Pracownik //Klasa abstrakcyjna 
{
    //Hermetyzacja 
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public decimal StawkaPodstawowa { get; set; }

    public Pracownik(string imie, string nazwisko, decimal stawka)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        StawkaPodstawowa = stawka;
    }

    //Polimorfizm 
    public abstract decimal ObliczWyplate();
    
    public virtual string PrzedstawSie()
    {
        return $"{Imie} {Nazwisko}";
    }
}

public class Programista : Pracownik
{
    public decimal PremiaZaKod { get; set; }

    public Programista(string imie, string nazwisko, decimal stawka, decimal premia) 
        : base(imie, nazwisko, stawka)
    {
        PremiaZaKod = premia;
    }

    public override decimal ObliczWyplate()
    {
        return StawkaPodstawowa + PremiaZaKod;
    }

    public override string PrzedstawSie()
    {
        return $"[PROGRAMISTA] {base.PrzedstawSie()} - Wypłata: {ObliczWyplate()} PLN";
    }
}

public class Ksiegowa : Pracownik
{
    public int LataStazu { get; set; }

    public Ksiegowa(string imie, string nazwisko, decimal stawka, int staz) 
        : base(imie, nazwisko, stawka)
    {
        LataStazu = staz;
    }

    public override decimal ObliczWyplate()
    {
        return StawkaPodstawowa + (LataStazu * 100);
    }

    public override string PrzedstawSie()
    {
        return $"[KSIĘGOWA] {base.PrzedstawSie()} - Wypłata: {ObliczWyplate()} PLN";
    }
}

class Program
{
    static string nazwaPliku = "baza_pracownikow.json";

    static void Main(string[] args)
    {
        //Kolekcje generyczne
        List<Pracownik> listaPracownikow = new List<Pracownik>();

        //Odczyt z pliku
        if (File.Exists(nazwaPliku))
        {
            string jsonDanych = File.ReadAllText(nazwaPliku);
            //Wczytywanie danych z JSON
            listaPracownikow = JsonSerializer.Deserialize<List<Pracownik>>(jsonDanych) ?? new List<Pracownik>();
            Console.WriteLine("Wczytano dane z pliku!");
        }

        bool czyDzialac = true;

        //Pętla
        while (czyDzialac)
        {
            Console.WriteLine("\n--- SYSTEM KADROWY ---");
            Console.WriteLine("1. Dodaj Programistę");
            Console.WriteLine("2. Dodaj Księgową");
            Console.WriteLine("3. Wyświetl wszystkich (Lista płac)");
            Console.WriteLine("4. Zapisz i Wyjdź");
            Console.Write("Wybierz opcję: ");

            string wybor = Console.ReadLine();

            //Instrukcje warunkowe
            switch (wybor)
            {
                case "1":
                    DodajProgramiste(listaPracownikow);
                    break;
                case "2":
                    DodajKsiegowa(listaPracownikow);
                    break;
                case "3":
                    WyswietlListe(listaPracownikow);
                    break;
                case "4":
                    ZapiszDoPliku(listaPracownikow);
                    czyDzialac = false;
                    break;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }
    }

    static void DodajProgramiste(List<Pracownik> lista)
    {
        Console.Write("Podaj imię: ");
        string imie = Console.ReadLine();
        Console.Write("Podaj nazwisko: ");
        string nazwisko = Console.ReadLine();
        Console.Write("Podaj stawkę podstawową: ");
        decimal stawka = decimal.Parse(Console.ReadLine());
        Console.Write("Podaj premię za kod: ");
        decimal premia = decimal.Parse(Console.ReadLine());

        //Dodawanie obiektu
        lista.Add(new Programista(imie, nazwisko, stawka, premia));
        Console.WriteLine("Dodano programistę!");
    }

    static void DodajKsiegowa(List<Pracownik> lista)
    {
        Console.Write("Podaj imię: ");
        string imie = Console.ReadLine();
        Console.Write("Podaj nazwisko: ");
        string nazwisko = Console.ReadLine();
        Console.Write("Podaj stawkę podstawową: ");
        decimal stawka = decimal.Parse(Console.ReadLine());
        Console.Write("Podaj lata stażu: ");
        int staz = int.Parse(Console.ReadLine());

        lista.Add(new Ksiegowa(imie, nazwisko, stawka, staz));
        Console.WriteLine("Dodano księgową!");
    }

    static void WyswietlListe(List<Pracownik> lista)
    {
        Console.WriteLine("\n--- LISTA PRACOWNIKÓW ---");
        
        //Pętla foreach
        if (lista.Count == 0)
        {
            Console.WriteLine("Brak pracowników na liście.");
        }
        else
        {
            foreach (var pracownik in lista)
            {
                Console.WriteLine(pracownik.PrzedstawSie());
            }
        }
    }

    static void ZapiszDoPliku(List<Pracownik> lista)
    {
        var opcje = new JsonSerializerOptions { WriteIndented = true };
        
        //Zapis do pliku JSON
        string jsonString = JsonSerializer.Serialize(lista, opcje);
        File.WriteAllText(nazwaPliku, jsonString);
        Console.WriteLine("Dane zapisane do pliku " + nazwaPliku);
    }
}
