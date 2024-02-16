using System;
using System.Collections.Generic;
using System.Linq;
using s21_d01;
Console.WriteLine("----------ex00----------");
Storage storage = new Storage(10);
Console.WriteLine($"{storage.IsEmpty()}");
storage = new Storage(0);
Console.WriteLine($"{storage.IsEmpty()}");

Console.WriteLine("----------ex01----------");
var customer1 = new Customer("Daniil", 1);
Console.WriteLine(customer1.ToString());
var customer2 = new Customer("Daniil", 1);
var customer3 = new Customer("Arseniy", 1);
Customer nullCustomer = null;
Console.WriteLine($"customer1 == customer2 = {customer1 == customer2}");
Console.WriteLine($"customer1 == customer3 = {customer1 == customer3}");
Console.WriteLine($"customer1 == nullCustomer = {customer1 == nullCustomer}");
Console.WriteLine($"nullCustomer == customer2 = {nullCustomer == customer2}");
Console.WriteLine($"nullCustomer == nullCustomer = {nullCustomer == nullCustomer}");
Console.WriteLine($"customer1 != customer2 = {customer1 != customer2}");
Console.WriteLine($"customer1 != customer3 = {customer1 != customer3}");
Console.WriteLine($"customer1 != nullCustomer = {customer1 != nullCustomer}");
Console.WriteLine($"nullCustomer != customer2 = {nullCustomer != customer2}");

Console.WriteLine("----------ex02----------");
customer1.FillCart(15);
customer2.FillCart(15);
customer3.FillCart(15);
Console.WriteLine($"{customer1} ({customer1.ItemsAmount} items in the cart)");
Console.WriteLine($"{customer2} ({customer2.ItemsAmount} items in the cart)");
Console.WriteLine($"{customer3} ({customer3.ItemsAmount} items in the cart)");

Console.WriteLine("----------ex03----------");
var cashRegister = new CashRegister("Cash Register 1", 1);
CashRegister cashRegister1 = new CashRegister("Register", 1);
CashRegister cashRegister2 = new CashRegister("Register", 1);
Console.WriteLine($"cashRegister1 == cashRegister2 = {cashRegister1 == cashRegister2}");

cashRegister.EnqueueCustomer(customer1);
cashRegister.EnqueueCustomer(customer3);

Console.WriteLine($"Количество клиентов в очереди: {cashRegister.CustomersCount}");
Console.WriteLine($"Первый клиент в очереди: {cashRegister.FirstCustomer()}");
Console.WriteLine($"Удаляем первого клиента(прошел очередь): {cashRegister.DequeueCustomer()}");
Console.WriteLine($"Количество клиентов в очереди после удаления второго клиента: {cashRegister.CustomersCount}");
Console.WriteLine($"Первый клиент в очереди после удаления второго клиента: {cashRegister.FirstCustomer()}");

Console.WriteLine("----------ex04----------");
Store store = new Store(200, 5);
Console.WriteLine($"{store.IsOpen()}");
store = new Store(0, 0);
Console.WriteLine($"{store.IsOpen()}");

Console.WriteLine("----------ex05----------");
customer1 = new Customer("Oleg", 1);
customer2 = new Customer("Masha", 2);
customer3 = new Customer("Nikola", 3);
customer1.FillCart(1);
customer2.FillCart(1);
customer3.FillCart(100);
cashRegister1.EnqueueCustomer(customer1);
cashRegister1.EnqueueCustomer(customer2);
Console.WriteLine("{0} #{1}: {2} ({3}), {4} ({5})", cashRegister1.Name, cashRegister1.Id, customer1.Name, customer1.ItemsAmount, customer2.Name, customer2.ItemsAmount);
var cashRegister3 = new CashRegister("Register", 2);
cashRegister3.EnqueueCustomer(customer3);
Console.WriteLine("{0} #{1}: {2} ({3})", cashRegister3.Name, cashRegister3.Id, customer3.Name, customer3.ItemsAmount);
List<CashRegister> cashRegisters = new List<CashRegister>();
cashRegisters.Add(cashRegister1);
cashRegisters.Add(cashRegister3);
Console.WriteLine("Few Customers: {0} #{1}", CustomerExtensions.FewCustomers(cashRegisters).Name, CustomerExtensions.FewCustomers(cashRegisters).Id);
Console.WriteLine("Few Items: {0} #{1}", CustomerExtensions.FewItems(cashRegisters).Name, CustomerExtensions.FewItems(cashRegisters).Id);

Console.WriteLine("----------ex06----------");
Customer[] customers = new Customer[10];
for (int index = 0; index < customers.Length; ++index)
{
    customers[index] = new Customer($"Name {index}", index);
}

void ProcessCustomers(Store store, Func<List<CashRegister>, CashRegister> cashRegisterSelector)
{
    while (store.IsOpen())
    {
        foreach (var customer in customers)
        {
            customer.FillCart(7);
            var cashRegister = cashRegisterSelector(store.CashRegisters);
            if (cashRegister != null)
            {
                Console.WriteLine($"{customer.Name}, Customer #{customer.Id} ({customer.ItemsAmount} items in cart) - {cashRegister.Name} #{cashRegister.Id } ({cashRegister.CustomersCount} people with {cashRegister.ItemsCount} items behind)");
                cashRegister.EnqueueCustomer(customer);
            }
            else
            {
                Console.WriteLine($"No available cash register for customer {customer.Name}");
                break;
            }
        }
        store.BuyAndLeave();
    }
}

Console.WriteLine("-------Few Customers----");
Store storeFewCustomers = new Store(40, 3);
ProcessCustomers(storeFewCustomers, CustomerExtensions.FewCustomers);

Console.WriteLine("-------Few Items--------");
Store storeFewItems = new Store(40, 3);
ProcessCustomers(storeFewItems, CustomerExtensions.FewItems);
