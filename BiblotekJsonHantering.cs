using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class BibliotekJsonHantering
{
    private static readonly string Filväg = "LibraryData.json";

    public static Bibliotek LaddaDataFrånJSON()
    {
        try
        {
            if (File.Exists(Filväg))
            {
                string json = File.ReadAllText(Filväg);
                Console.WriteLine($"Läser in data från {Filväg}...");

                // Visa hela JSON-strängen för felsökning
                Console.WriteLine($"JSON Innehåll: {json}");

                if (string.IsNullOrEmpty(json) || json == "{}")
                {
                    Console.WriteLine("JSON-filen är tom eller innehåller ogiltiga data.");
                    return new Bibliotek(new List<Bok>(), new List<Författare>());
                }

                var jsonData = JsonSerializer.Deserialize<JsonBibliotek>(json);

                if (jsonData == null || jsonData.Böcker == null || jsonData.Författare == null)
                {
                    Console.WriteLine("Felaktig JSON-struktur eller tomma data.");
                    return new Bibliotek(new List<Bok>(), new List<Författare>());
                }

                Console.WriteLine($"Laddade {jsonData.Böcker.Count} böcker och {jsonData.Författare.Count} författare.");
                return new Bibliotek(jsonData.Böcker, jsonData.Författare);
            }
            else
            {
                Console.WriteLine($"Fil {Filväg} finns inte.");
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Fel vid JSON-deserialisering: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Okänt fel vid läsning från JSON: {ex.Message}");
        }

        return new Bibliotek(new List<Bok>(), new List<Författare>());
    }




    public static void SparaDataTillJSON(Bibliotek bibliotek)
    {
        try
        {
            string json = JsonSerializer.Serialize(bibliotek, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Filväg, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid sparande till JSON: {ex.Message}");
        }
    }
}
