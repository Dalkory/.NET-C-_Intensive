namespace s21_d06
{
    public class Store
    {
        public delegate bool CashRegisterComparer(CashRegister cashRegister1, CashRegister cashRegister2);

        private Storage storage;
        private List<CashRegister> cashRegisters;
        private Thread[]? cashierThreads;
        private readonly object cashRegistersLock = new object();
        private readonly object threadsLock = new object();

        public Store(int storageCapacity, int cashRegisterAmount, int timePerItem, int timePerCustomer)
        {
            storage = new Storage(storageCapacity);
            if (cashRegisterAmount < 0)
            {
                cashRegisterAmount = 0;
            }
            cashRegisters = new List<CashRegister>(cashRegisterAmount);
            for (int i = 0; i < cashRegisterAmount; i++)
            {
                var cashRegister = new CashRegister("Register", i, timePerItem, timePerCustomer);
                cashRegisters.Add(cashRegister);
            }
        }

        public void AddCustomerToQueue(Customer customer, CashRegisterComparer comparer)
        {
            int optimalIndex = 0;
            lock (cashRegistersLock)
            {
                customer.FillCart(storage);
                if (customer.ItemsAmount == 0)
                    return;
                if (cashRegisters == null || cashRegisters.Count == 0)
                    return;
                for (int index = 1; index < cashRegisters.Count; ++index)
                {
                    if (!comparer(cashRegisters[optimalIndex], cashRegisters[index]))
                    {
                        optimalIndex = index;
                    }
                }
                cashRegisters[optimalIndex].AddCustomerToQueue(customer);
            }

            lock (threadsLock)
            {
                if (cashierThreads != null)
                {
                    if (!cashierThreads[optimalIndex].IsAlive)
                    {
                        cashierThreads[optimalIndex] = new Thread(cashRegisters[optimalIndex].ProcessCustomers);
                        cashierThreads[optimalIndex].Start();
                    }
                }
            }
        }

        public void OpenRegisters()
        {
            cashierThreads = new Thread [cashRegisters.Count];
            for (var index = 0; index < cashRegisters.Count; ++index)
            {
                cashierThreads[index] = new Thread(cashRegisters[index].ProcessCustomers);
            }

            foreach (var thread in cashierThreads)
            {
                thread.Start();
            }
        }

        public void ProceedAllCustomers()
        {
            if (cashierThreads == null)
                OpenRegisters();
            if (cashierThreads != null)
            {
                foreach (var thread in cashierThreads)
                {
                    if (thread != null && thread.IsAlive)
                        thread.Join();
                }
            }
        }

        public string Results()
        {
            string res = "";
            foreach (var cashRegister in cashRegisters)
            {
                var averageTime = cashRegister.WaitingTime / cashRegister.CustomersProcessed;
                res += $"{cashRegister.Name} #{cashRegister.Id} with: " +
                       $"good service time={cashRegister.TimePerItem} " +
                       $"customer delay={cashRegister.TimePerCustomer} " +
                       $"average proceed time={averageTime:g}{Environment.NewLine}";
            }
            return res;
        }

        public bool IsOpen() => storage != null && !storage.IsEmpty();

        public override string ToString()
        {
            string res = "";
            foreach (var cashRegister in cashRegisters)
            {
                res += $"{cashRegister.Name} #{cashRegister.Id} with {cashRegister.CustomersCount} customers " +
                       $"{cashRegister.ItemsCount} items.{Environment.NewLine}";
            }
            return res;
        }
    }
}