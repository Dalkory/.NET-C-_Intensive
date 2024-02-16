using System;
using System.Collections.Generic;

namespace s21_d01
{
    public class Store 
    {
        private Storage _storage;
        private List<CashRegister> _CashRegisters;

        public List<CashRegister> CashRegisters => _CashRegisters;

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
                var customer = cashRegister.FirstCustomer();
                while (customer != null)
                {
                    if(customer.ItemsAmount > _storage.Count) 
                    {
                        customer.Buy(_storage.GetItems(customer.ItemsAmount));
                        if (customer.ItemsAmount != 0)
                        {
                            Console.WriteLine("{0}, Customer #{1} ({2} items left in cart)", customer.Name, customer.Id, customer.ItemsAmount);
                            return;
                        }
                    } 
                    // else
                    // {
                    //     customer.Buy(_storage.GetItems(customer.ItemsAmount));
                    //     if (customer.ItemsAmount != 0)
                    //     {
                    //         Console.WriteLine("{0}, Customer #{1} ({2} items left in cart)", customer.Name, customer.Id, customer.ItemsAmount);
                    //         return;
                    //     }
                    // }
                    cashRegister.DequeueCustomer();
                    customer = cashRegister.FirstCustomer();
                }
            }
        }

        public bool IsOpen() => !_storage.IsEmpty();
    }
}