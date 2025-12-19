    static void Main(string[] args)
    {
        int number; 

        do
        {
            Console.Write("Podaj liczbę większą od zera: ");


            string input = Console.ReadLine();
            if (!int.TryParse(input, out number))
            {
                number = 0; 
            }


            if (number <= 0)
            {
                Console.WriteLine("To nie jest liczba większa od zera. Spróbuj ponownie.");
            }

        } while (number <= 0); 


        Console.WriteLine($"Dziękuję! Podałeś poprawną liczbę: {number}");
    }