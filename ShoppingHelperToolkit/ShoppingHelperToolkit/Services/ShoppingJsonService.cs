using System.Text.Json;
using ShoppingHelperToolkit.Models;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ShoppingHelperToolkit.Services
{
    public class ShoppingJsonService
    {
        private readonly JsonSerializerOptions _options = new()
        { 
            PropertyNameCaseInsensitive = true
        };

        public List<Shopping> LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            { 
                return new List<Shopping>();
            }

            try
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<List<Shopping>>(json, _options);
                return data ?? new List<Shopping>();
            }
            catch (JsonException)
            { 
                return new List<Shopping>();
            }

        }
    }
}
