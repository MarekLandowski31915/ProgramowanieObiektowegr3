using System;

interface IDrukowalne
{
    void Drukuj();
}

class Dokument : IDrukowalne
{
    public void Drukuj()
    {
        Console.WriteLine("Drukowanie dokumentu");
    }
}

class Zdjecie : IDrukowalne
{
    public void Drukuj()
    {
        Console.WriteLine("Drukowanie zdjecia");
    }
}

class Program
{
    static void Main()
    {
        IDrukowalne[] elementy = new IDrukowalne[]
        {
            new Dokument(),
            new Zdjecie()
        };

        foreach (var e in elementy)
        {
            e.Drukuj();
        }
    }
}
