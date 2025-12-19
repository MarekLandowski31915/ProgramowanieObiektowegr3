interface IKarmione
{
    void Karm();
}

interface ITrenowane
{
    void Trenuj();
}

abstract class Zwierze
{
    public abstract void DajGlos();
}

class Pies : Zwierze, IKarmione, ITrenowane
{
    public override void DajGlos()
    {
        Console.WriteLine("Hau!");
    }

    public void Karm()
    {
        Console.WriteLine("Pies je karmę");
    }

    public void Trenuj()
    {
        Console.WriteLine("Pies trenuje posłuszeństwo");
    }
}

class Kot : Zwierze, IKarmione
{
    public override void DajGlos()
    {
        Console.WriteLine("Miau!");
    }

    public void Karm()
    {
        Console.WriteLine("Kot je rybę");
    }
}

class Tygrys : Zwierze, IKarmione, ITrenowane
{
    public override void DajGlos()
    {
        Console.WriteLine("Roooar!");
    }

    public void Karm()
    {
        Console.WriteLine("Tygrys je mięso");
    }

    public void Trenuj()
    {
        Console.WriteLine("Tygrys trenuje skoki");
    }
}

class Program
{
    static void Main()
    {
        List<Zwierze> zwierzeta = new List<Zwierze>
        {
            new Pies(),
            new Kot(),
            new Tygrys()
        };

        foreach (var z in zwierzeta)
        {
            z.DajGlos();

            if (z is IKarmione k)
                k.Karm();

            if (z is ITrenowane t)
                t.Trenuj();
        }
    }
}
