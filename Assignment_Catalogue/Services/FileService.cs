namespace Assignment_Catalogue.Services;

public class FileService
{
    public static void SaveToFile(string contentAsJson, string _filePath) // method used with SaveContactsToFile, uses a streamwriter and a provided filepath to save the contents of the file as Json.
    {
        using var sw = new StreamWriter(_filePath);
        sw.WriteLine(contentAsJson);
    }

    public static string ReadFromFile(string _filePath) // method that checks if the file exist, and if it does it uses a streamreader with the filepath that is provided.
    {
        if (File.Exists(_filePath))
        {
            using var sr = new StreamReader(_filePath);
            return sr.ReadToEnd();
        }

        return null!;
    }
}
