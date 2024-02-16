using s21_d03_Configuration;
using s21_d03_Sources;

if (args.Length < 4)
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return;
}

string jsonPath = args[0];
int jsonPriority = Convert.ToInt32(args[1]);
string yamlPath = args[2];
int yamlPriority = Convert.ToInt32(args[3]);

IConfigurationSource jsonSource = new JsonSource(jsonPath, jsonPriority);
IConfigurationSource yamlSource = new YamlSource(yamlPath, yamlPriority);
IConfigurationSource envSource = new EnvSource();
Configuration configuration = new Configuration(jsonSource, yamlSource, envSource);
Console.WriteLine(configuration);