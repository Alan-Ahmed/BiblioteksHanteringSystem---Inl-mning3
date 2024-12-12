using System.Text.Json;

public static class BibliotekJsonHantering
{
    private static readonly string filväg = "LibraryData.json";

    public static Bibliotek LaddaDataFrånJSON()
    {
        try
        {
            if (File.Exists(filväg))
            {
                if (new FileInfo(filväg).Length == 0)
                {
                    Console.WriteLine("JSON-filen är tom. En ny tom databas skapas.");
                    return new Bibliotek();
                }

                string json = File.ReadAllText(filväg);
                var bibliotek = JsonSerializer.Deserialize<Bibliotek>(json);
                return bibliotek ?? new Bibliotek();
            }
            else
            {
                Console.WriteLine("JSON-filen saknas. En ny fil skapas.");
                File.WriteAllText(filväg, JsonSerializer.Serialize(new Bibliotek(), new JsonSerializerOptions { WriteIndented = true }));
                return new Bibliotek();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid inläsning från JSON: {ex.Message}");
            return new Bibliotek();
        }
    }

    public static void SparaDataTillJSON(Bibliotek bibliotek)
    {
        try
        {
            string json = JsonSerializer.Serialize(bibliotek, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filväg, json);
            Console.WriteLine("Data har sparats till JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid sparande till JSON: {ex.Message}");
        }
    }
}
