class Zwierze
{
    public void Jedz() => Console.WriteLine("Zwierzę je");
}

class Pies : Zwierze
{
    public void Szczekaj() => Console.WriteLine("woof");
}

class Kot : Zwierze
{
    public void Miaucz() => Console.WriteLine("meow");
}

class Program
{
    static void Main()
    {
        Pies pies = new Pies();
        Kot kot = new Kot();

        pies.Szczekaj();
        kot.Miaucz();
    }
}
