class Program
{
    static void Main(string[] args)
    {
        string password = "";
        while (password != "admin123")
        {
            Console.Write("Podaj hasło: ");
            password = Console.ReadLine();
            if (password != "admin123" && password != "")
            {
                Console.WriteLine("Błędne hasło, spróbuj ponownie.");
            }
        }

        Console.WriteLine("Zalogowano pomyślnie!");
    }
}