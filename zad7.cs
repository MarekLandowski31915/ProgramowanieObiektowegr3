using System;

class Zwierze
{
    public virtual void DajGlos() => Console.WriteLine("Zwierzę wydaje dźwięk");
}

class Pies : Zwierze
{
    public override void DajGlos() => Console.WriteLine("woof");
}

class Kot : Zwierze
{
    public override void DajGlos() => Console.WriteLine("meow");
}

class Program
{
    static void Main()
    {
        Zwierze[] zwierzeta = { new Pies(), new Kot(), new Zwierze() };

        foreach (var z in zwierzeta)
        {
            z.DajGlos();
        }
    }
}
