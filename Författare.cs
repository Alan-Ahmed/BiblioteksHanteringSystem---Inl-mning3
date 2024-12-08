using System.Collections.Generic;

public class Författare
{
    public int Id { get; set; }
    public string Namn { get; set; }
    public string Land { get; set; }
    public List<Bok> Böcker { get; set; } = new List<Bok>();
}