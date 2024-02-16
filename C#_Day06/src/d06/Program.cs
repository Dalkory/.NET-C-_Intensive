using System.Globalization;
using s21_d06;
using Microsoft.Extensions.Configuration;

ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var conf = configurationBuilder.Build();
if (!int.TryParse(conf["timePerItem"], out var timePerItem) || !int.TryParse(conf["timePerCustomer"], out var timePerCustomer))
{
    Console.WriteLine("Error \"appsettings.json\" file parameters.");
    return;
}

var cultureInfo = new CultureInfo("en-GB");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
Thread.CurrentThread.CurrentCulture = cultureInfo;

var store1 = new Store(50, 4, timePerItem, timePerCustomer);
var store2 = new Store(50, 4, timePerItem, timePerCustomer);
var customersAmount = 10;
var customers = new Customer [customersAmount];
int index = 0;
for (; index < customersAmount; ++index)
{
    customers[index] = new Customer($"Customer {index + 1}", index + 1);
    customers[index].ShoppingList(7);
}


customers.AsParallel().ForAll(customer =>
{
    if (store1.IsOpen())
        store1.AddCustomerToQueue(customer, CustomerExtensions.FewCustomers);
});
Console.WriteLine("\nSTORE 1\n");
Console.WriteLine(store1);


customers.AsParallel().ForAll(customer =>
{
    if (store2.IsOpen())
        store2.AddCustomerToQueue(customer, CustomerExtensions.FewCustomers);
});
Console.WriteLine("\nSTORE 2\n");
Console.WriteLine(store2);


store1.OpenRegisters();
Console.WriteLine("\nSTORE 1\n");
TimeSpan timeSpan = new TimeSpan(hours: 0, minutes: 0, seconds: 7);
while (store1.IsOpen())
{
    Thread.Sleep(timeSpan);
    var customer = new Customer($"New Customer {index + 1}", index + 1);
    customer.ShoppingList(7);
    ++index;
    store1.AddCustomerToQueue(customer, CustomerExtensions.FewItems);
}
store1.ProceedAllCustomers();
Console.WriteLine("\nSTORE 1\n");
Console.WriteLine(store1.Results());


store2.OpenRegisters();
Console.WriteLine("\nSTORE 2\n");
while (store2.IsOpen())
{
    Thread.Sleep(timeSpan);
    var customer = new Customer($"New Customer {index + 1}", index + 1);
    customer.ShoppingList(7);
    ++index;
    store2.AddCustomerToQueue(customer, CustomerExtensions.FewCustomers);
}
store2.ProceedAllCustomers();
Console.WriteLine("\nSTORE 2\n");
Console.WriteLine(store2.Results());