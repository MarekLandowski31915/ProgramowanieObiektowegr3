
class Program
{
    static void Main(string[] args)
    {

        string[] miasta = { "Warszawa", "Kraków", "Gdańsk", "Wrocław", "Poznań" };

        Console.WriteLine("Lista miast:");


        foreach (string miasto in miasta)
        {
            Console.WriteLine(miasto);
        }
    }
}