using System;

public class BibliotekMeny
{
    private readonly Bibliotek bibliotek;

    public BibliotekMeny()
    {
        bibliotek = BibliotekJsonHantering.LaddaDataFrånJSON();
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n--- Bibliotekshantering ---");
            Console.WriteLine("1. Visa alla böcker och författare");
            Console.WriteLine("2. Lägg till en ny bok");
            Console.WriteLine("3. Avsluta");

            Console.Write("Välj ett alternativ: ");
            string val = Console.ReadLine();

            switch (val)
            {
                case "1":
                    VisaAllaBöckerOchFörfattare();
                    break;

                case "2":
                    LäggTillNyBok();
                    break;

                case "3":
                    AvslutaProgram();
                    return;

                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }

    private void VisaAllaBöckerOchFörfattare()
    {
        bibliotek.VisaAllaBöckerOchFörfattare();
    }

    private void LäggTillNyBok()
    {
        bibliotek.LäggTillNyBok();
    }

    private void AvslutaProgram()
    {
        BibliotekJsonHantering.SparaDataTillJSON(bibliotek);
        Console.WriteLine("Programmet avslutas.");
    }
}
