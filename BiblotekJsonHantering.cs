using System;
using System.IO;
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
                string json = File.ReadAllText(filväg);
                var bibliotek = JsonSerializer.Deserialize<Bibliotek>(json);
                return bibliotek ?? new Bibliotek();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid inläsning från JSON: {ex.Message}");
        }
        return new Bibliotek();
    }

    public static void SparaDataTillJSON(Bibliotek bibliotek)
    {
        try
        {
            string json = JsonSerializer.Serialize(bibliotek, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filväg, json);
            MirrorChangesToProjectRoot("LibraryData.json");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid sparande till JSON: {ex.Message}");
        }
    }

    private static void MirrorChangesToProjectRoot(string fileName)
    {
        string outputDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectRootDir = Path.Combine(outputDir, "../../../");
        string sourceFilePath = Path.Combine(outputDir, fileName);
        string destFilePath = Path.Combine(projectRootDir, fileName);

        if (File.Exists(sourceFilePath))
        {
            File.Copy(sourceFilePath, destFilePath, true);
            Console.WriteLine($"{fileName} har speglats till projektroten.");
        }
        else
        {
            Console.WriteLine($"Källfilen {fileName} hittades inte.");
        }
    }
}
