namespace Opcion1LosCules;
using Newtonsoft.Json;

public class FileStorage<T> : IStorage<T>
{
    private readonly string _filePath;

    public FileStorage(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(List<T> items)
    {
        var jsonData = JsonConvert.SerializeObject(items, Formatting.Indented);
        File.WriteAllText(_filePath, jsonData);
    }

    public List<T> Load()
    {
        if (File.Exists(_filePath))
        {
            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
        }
        return new List<T>();
    }
}
