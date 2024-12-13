using System;
using System.Collections.Generic;

public class Bibliotek
{
    public List<Bok> Böcker { get; set; }
    public List<Författare> Författare { get; set; }

    public Bibliotek(List<Bok> böcker, List<Författare> författare)
    {
        Böcker = böcker ?? new List<Bok>();
        Författare = författare ?? new List<Författare>();
    }

    public void LäggTillNyBok()
    {
        Bok nyBok = new Bok();

        Console.Write("Ange titel: ");
        nyBok.Title = Console.ReadLine();

        Console.Write("Ange författarens namn: ");
        string författarNamn = Console.ReadLine();

        var författare = Författare.Find(f => f.Name.Equals(författarNamn, StringComparison.OrdinalIgnoreCase));
        if (författare == null)
        {
            Console.Write("Ange författarens land: ");
            string land = Console.ReadLine();
            författare = new Författare
            {
                Name = författarNamn,
                Id = Författare.Count + 1,
                Country = land
            };
            Författare.Add(författare);
        }
        nyBok.Author = författare;

        Console.Write("Ange genre: ");
        nyBok.Genre = Console.ReadLine();

        Console.Write("Ange publiceringsår: ");
        nyBok.PublishedYear = int.TryParse(Console.ReadLine(), out int år) ? år : 0;

        Console.Write("Ange ISBN: ");
        nyBok.ISBN = int.TryParse(Console.ReadLine(), out int isbn) ? isbn : 0;

        Böcker.Add(nyBok);
        Console.WriteLine("Ny bok har lagts till.");
    }

    public void VisaAllaBöckerOchFörfattare()
    {
        Console.WriteLine("\n--- Böcker ---");
        if (Böcker.Count == 0)
        {
            Console.WriteLine("Inga böcker finns.");
        }
        foreach (var bok in Böcker)
        {
            Console.WriteLine($"Titel: {bok.Title}, Författare: {bok.Author.Name}, Genre: {bok.Genre}, År: {bok.PublishedYear}");
        }

        Console.WriteLine("\n--- Författare ---");
        if (Författare.Count == 0)
        {
            Console.WriteLine("Inga författare finns.");
        }
        foreach (var författare in Författare)
        {
            Console.WriteLine($"Namn: {författare.Name}, Land: {författare.Country}");
        }
    }

}
