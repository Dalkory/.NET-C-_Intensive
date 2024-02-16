using System.Text.Json;

namespace s21_d03_Sources
{
    public class JsonSource : IConfigurationSource
    {
        private string FilePath;

        public JsonSource(string filePath, int priority)
        {
            FilePath = filePath;
            Priority = priority;
        }

        public int Priority { get; }

        public Dictionary<string, string> GetParams()
        {
            try
            {
                string json = File.ReadAllText(FilePath);
                Dictionary<string, object>? parameters = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                Dictionary<string, string> result = new Dictionary<string, string>();

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        if (param.Value is JsonElement jsonElement)
                        {
                            if (jsonElement.ValueKind == JsonValueKind.True || jsonElement.ValueKind == JsonValueKind.False)
                            {
                                result.Add(param.Key, jsonElement.GetBoolean().ToString());
                            }
                            else if (jsonElement.ValueKind == JsonValueKind.Number)
                            {
                                result.Add(param.Key, jsonElement.GetInt32().ToString());
                            }
                            else if (jsonElement.ValueKind == JsonValueKind.String)
                            {
                                result.Add(param.Key, jsonElement.GetString() ?? string.Empty);
                            }
                        }
                    }
                }

                return result;
            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid JSON data. Check your input and try again.");
                return new Dictionary<string, string>();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {FilePath}");
                return new Dictionary<string, string>();
            }
        }
    }
}