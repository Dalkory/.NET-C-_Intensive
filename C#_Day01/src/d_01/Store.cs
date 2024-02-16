
using System;
using System.Collections.Generic;

namespace s21_d01
{
    public class Store 
    {
        private Storage _storage;
        private List<CashRegister> _CashRegisters;

        public List<CashRegister> CashRegisters => new List<CashRegister>(_CashRegisters);

        public Store(int StorageCapacity, int CashRegisterAmount)
        {
            _storage = new Storage(StorageCapacity);
            if (CashRegisterAmount < 0) 
            {
                CashRegisterAmount = 0;
            }
            _CashRegisters = new List<CashRegister>(CashRegisterAmount);
            for (int i = 0; i < CashRegisterAmount; i++)
            {
                _CashRegisters.Add(new CashRegister("Register", i));
            }
        }

        public void BuyAndLeave()
        {
            foreach (var cashRegister in _CashRegisters)
            {
                while (cashRegister.CustomersCount > 0)
                {
                    var customer = cashRegister.DequeueCustomer();
                    if (customer != null)
                    {
                        customer.Buy(_storage.GetItems(customer.ItemsAmount));
                        if (customer.ItemsAmount != 0)
                        {
                            Console.WriteLine("{0}, Customer #{1} ({2} items left in cart)", customer.Name, customer.Id, customer.ItemsAmount);
                        }
                    }
                }
            }
        }

        public bool IsOpen() => _storage != null && !_storage.IsEmpty();
    }
}