using System.IO;
using System.Text.Json;
using ShoppingHelper.Models;

namespace ShoppingHelper.Services;

public class ShoppingFileService
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    public List<Shopping> LoadShoppings(string filePath)
    {
        if (!File.Exists(filePath))
            return new List<Shopping>();

        var json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<Shopping>>(json, _options)
               ?? new List<Shopping>();
    }
}
