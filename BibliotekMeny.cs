using System;

public class BibliotekMeny
{
    private Bibliotek _bibliotek;

    public BibliotekMeny()
    {
        _bibliotek = BibliotekJsonHantering.LaddaDataFrånJSON();
    }

    public void Start()
    {
        bool kör = true;
        while (kör)
        {
            VisaMeny();
            kör = HanteraVal();
        }
        BibliotekJsonHantering.SparaDataTillJSON(_bibliotek);
    }

    private void VisaMeny()
    {
        Console.WriteLine("\n--- BIBLIOTEK MENY ---");
        Console.WriteLine("1. Lägg till ny bok");
        Console.WriteLine("2. Lägg till ny författare");
        Console.WriteLine("3. Lista alla böcker och författare");
        Console.WriteLine("4. Avsluta och spara data");
        Console.Write("Välj ett alternativ: ");
    }

    private bool HanteraVal()
    {
        if (!int.TryParse(Console.ReadLine(), out int val))
        {
            Console.WriteLine("Ogiltigt val, försök igen.");
            return true;
        }

        switch (val)
        {
            case 1:
                _bibliotek.LäggTillNyBok();
                break;
            case 2:
                _bibliotek.LäggTillNyFörfattare();
                break;
            case 3:
                _bibliotek.ListaAllaBöckerOchFörfattare();
                break;
            case 4:
                Console.WriteLine("Data sparades. Avslutar programmet.");
                return false;
            default:
                Console.WriteLine("Ogiltigt val, försök igen.");
                break;
        }
        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadLine();
        return true;
    }
}