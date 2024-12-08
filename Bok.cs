using System;
using System.Collections.Generic;
using System.Linq;

public class Bok
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public string Författare { get; set; }
    public string Genre { get; set; }
    public int Publiceringsår { get; set; }
    public string Isbn { get; set; }
    public List<int> Recensioner { get; set; } = new List<int>();

    public double GenomsnittligtBetyg => Recensioner.Count > 0 ? Recensioner.Average() : 0;

    public void LäggTillBetyg(int betyg)
    {
        if (betyg >= 1 && betyg <= 5)
            Recensioner.Add(betyg);
        else
            Console.WriteLine("Ogiltigt betyg, ange ett tal mellan 1 och 5.");
    }
}