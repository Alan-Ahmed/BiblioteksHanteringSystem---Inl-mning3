using System;
using System.Collections.Generic;
using System.Linq;

public class Bibliotek
{
    private List<Bok> böcker = new List<Bok>();
    private List<Författare> författare = new List<Författare>();

    public Bibliotek()
    {
        // Om du vill att böcker ska läggas till här kan du göra det
    }

    public void LäggTillNyBok()
    {
        Bok nyBok = new Bok();

        Console.Write("Ange titel: ");
        nyBok.Titel = Console.ReadLine();

        Console.Write("Ange författare: ");
        nyBok.Författare = Console.ReadLine();

        Console.Write("Ange genre: ");
        nyBok.Genre = Console.ReadLine();

        Console.Write("Ange publiceringsår: ");
        if (int.TryParse(Console.ReadLine(), out int år))
        {
            nyBok.Publiceringsår = år;
        }

        // Lägg till bok till listan
        böcker.Add(nyBok);
        Console.WriteLine("Ny bok har lagts till.");
        BibliotekJsonHantering.SparaDataTillJSON(this);
    }

    public void LäggTillNyFörfattare()
    {
        Författare nyFörfattare = new Författare();

        Console.Write("Ange namn: ");
        nyFörfattare.Namn = Console.ReadLine();

        Console.Write("Ange land: ");
        nyFörfattare.Land = Console.ReadLine();

        // Lägg till författare till listan
        författare.Add(nyFörfattare);
        Console.WriteLine("Ny författare har lagts till.");
        BibliotekJsonHantering.SparaDataTillJSON(this);
    }

    public void ListaAllaBöckerOchFörfattare()
    {
        Console.WriteLine("\n--- Alla Böcker ---");
        foreach (var bok in böcker)
            Console.WriteLine($"Titel: {bok.Titel}, Författare: {bok.Författare}, Betyg: {bok.GenomsnittligtBetyg}");

        Console.WriteLine("\n--- Alla Författare ---");
        foreach (var f in författare)
            Console.WriteLine($"Namn: {f.Namn}, Land: {f.Land}");
    }
}