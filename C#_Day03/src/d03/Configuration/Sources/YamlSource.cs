using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace s21_d03_Sources
{
    public class YamlSource : IConfigurationSource
    {
        private string FilePath;

        public YamlSource(string filePath, int priority)
        {
            FilePath = filePath;
            Priority = priority;
        }

        public int Priority { get; }

        public Dictionary<string, string> GetParams()
        {
            try
            {
                string yaml = File.ReadAllText(FilePath);
                var deserializer = new DeserializerBuilder().Build();
                var parameters = deserializer.Deserialize<Dictionary<string, object>>(yaml);
                Dictionary<string, string> result = new Dictionary<string, string>();

                foreach (var param in parameters)
                {
                    if (param.Value is bool boolValue)
                    {
                        result.Add(param.Key, boolValue.ToString());
                    }
                    else if (param.Value is int intValue)
                    {
                        result.Add(param.Key, intValue.ToString());
                    }
                    else if (param.Value is string stringValue)
                    {
                        result.Add(param.Key, stringValue);
                    }
                }

                return result;
            }
            catch (YamlException)
            {
                Console.WriteLine("Invalid YAML data. Check your input and try again.");
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