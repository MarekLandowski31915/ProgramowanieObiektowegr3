using System;
using System.Collections.Generic;

abstract class Pojazd
{
    public abstract void UruchomSilnik();

    public virtual void Info()
    {
        Console.WriteLine(GetType().Name);
    }
}

class Samochod : Pojazd
{
    public override void UruchomSilnik()
    {
        Console.WriteLine("Silnik samochodu uruchomiony");
    }
}

class Motocykl : Pojazd
{
    public override void UruchomSilnik()
    {
        Console.WriteLine("Silnik motocykla uruchomiony");
    }
}

class Ciezarowka : Pojazd
{
    public override void UruchomSilnik()
    {
        Console.WriteLine("Silnik ciezarowki uruchomiony");
    }
}

class Program
{
    static void Main()
    {
        List<Pojazd> pojazdy = new List<Pojazd>
        {
            new Samochod(),
            new Motocykl(),
            new Ciezarowka()
        };

        foreach (var p in pojazdy)
        {
            p.Info();
            p.UruchomSilnik();
        }
    }
}
