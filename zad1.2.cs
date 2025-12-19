using System;

abstract class Zwierze
{
    public abstract void DajGlos();
}

class Pies : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Hau!");
    }
}

class Kot : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Miau!");
    }
}

class Krowa : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Muuu!");
    }
}

class Program
{
    static void Main()
    {
        Zwierze[] zwierzeta = new Zwierze[]
        {
            new Pies(),
            new Kot(),
            new Krowa()
        };

        foreach (var z in zwierzeta)
        {
            z.DajGlos();
        }
    }
}
