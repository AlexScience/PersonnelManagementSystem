using System.Text.Json;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Infrastructure.FileStorage;

public class FileDataStorage<T> : IDataStorage<T>
    where T : IEntity
{
    private readonly string _path;

    protected FileDataStorage(string path)
    {
        _path = path;
    }

    public void Save(T obj)
    {
        var items = GetItems().ToList();

        var found = items.FirstOrDefault(c => c.Id == obj.Id);
        if (found != null)
        {
            items.Remove(found);
        }

        items.Add(obj);
        var serialized = JsonSerializer.Serialize(items);
        WriteToFile(_path, serialized);
    }

    public T Fetch(Guid id)
    {
        var items = GetItems().ToList();
        var found = items.FirstOrDefault(c => c.Id == id);
        return found ?? throw new InvalidOperationException("Объект не найден");
    }

    public IEnumerable<T> FetchAll()
    {
        return GetItems();
    }

    private IEnumerable<T> GetItems()
    {
        List<T> items;
        var content = ReadFile(_path);
        if (string.IsNullOrEmpty(content))
        {
            items = new List<T>();
        }
        else
        {
            items = JsonSerializer.Deserialize<List<T>>(content) ?? new List<T>();
        }

        return items;
    }

    private string ReadFile(string path)
    {
        using var stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
        var reader = new StreamReader(stream);
        var text = reader.ReadToEnd();
        return text;
    }

    private void WriteToFile(string path, string content)
    {
        using var stream = File.OpenWrite(path);
        using var writer = new StreamWriter(stream);
        writer.Write(content);
    }
}