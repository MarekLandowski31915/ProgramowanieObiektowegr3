class KontoBankowe
{
    private double saldo;

    public void Wplata(double kwota)
    {
        saldo += kwota;
    }

    public bool Wyplata(double kwota)
    {
        if (kwota <= saldo)
        {
            saldo -= kwota;
            return true;
        }
        return false;
    }

    public double PobierzSaldo()
    {
        return saldo;
    }
}

class Program
{
    static void Main()
    {
        KontoBankowe konto = new KontoBankowe();
        konto.Wplata(100);
        konto.Wyplata(50);
    }
}
