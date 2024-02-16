using System.Text;
using s21_d03_Sources;

namespace s21_d03_Configuration
{
    public class Configuration
    {
        private Dictionary<string, string> Params; // hash-table

        public Configuration(params IConfigurationSource[] sources)
        {
            Array.Sort(sources, (source1, source2) => source2.Priority - source1.Priority);
            Params = new Dictionary<string, string>();
            foreach (var source in sources)
            {
                var sourceParams = source.GetParams();
                foreach (var param in sourceParams)
                {
                    if (!Params.ContainsKey(param.Key))
                    {
                        Params.Add(param.Key, param.Value);
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Configuration");
            foreach (var param in Params)
            {
                sb.AppendLine($"{param.Key}: {param.Value}");
            }
            return sb.ToString();
        }
    }
}

