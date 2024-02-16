using Microsoft.Extensions.Configuration;
using s21_d05_Nasa;

ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var configuration = configurationBuilder.Build();
var api_key = configuration["ApiKey"];

if (args.Length == 0)
{
{
var dateNasaClient = new DateNasaClient(configuration["ApiKey"]);
var result = await dateNasaClient.GetAsync(new DateTime(2024, 2, 9));
Console.WriteLine(result);
}
{
var randomNasaClient = new RandomNasaClient(configuration["ApiKey"]);
var result = await randomNasaClient.GetAsync(3);
Console.WriteLine(result);
}
{
var stringNasaClient = new StringNasaClient(configuration["ApiKey"]);
var result = stringNasaClient.GetAsync("2004-05-01");
Console.WriteLine(result);
}
}
else if (args.Length <= 3 && args[0] == "apod")
{
    int count = int.Parse(args[1]);

    var apodClient = new ApodClient(configuration["ApiKey"]);
    var results = await apodClient.GetAsync(count);
    foreach (var mediaOfToday in results)
    {
        Console.WriteLine(mediaOfToday + Environment.NewLine);
    }
}
else
{
    Console.WriteLine("Input Error.");
}