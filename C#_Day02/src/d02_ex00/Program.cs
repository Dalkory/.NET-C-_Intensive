using s21_d02_ex00;
using s21_d02_Models;

if (args.Length != 2)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return (-1);
}

Exchanger exchanger = new Exchanger(args[1]);
if (!ExchangeSum.TryParse(args[0], out var originalSum))
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return (-1);
}

Console.WriteLine($"Amount in the original currency: {originalSum}");

bool hasConversions = false;
foreach (var convertedSum in exchanger.Convert(originalSum))
{
    hasConversions = true;
    Console.WriteLine($"Amount in {convertedSum.CurrencyCode}: {convertedSum}");
}

if (!hasConversions)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return (-1);
}

return (0);