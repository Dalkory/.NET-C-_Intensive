using System.Collections.Concurrent;

namespace s21_d06
{
    public class CashRegister : IEquatable<CashRegister>
    {
        public string Name { get; }
        public int Id { get; }
        public int CustomersProcessed { get; private set; } = 0;
        public int CustomersCount => customersQueue.Count;
        private BlockingCollection<Customer> customersQueue;
        public int ItemsCount { get { return customersQueue.Sum(customer => customer.ItemsAmount); } }

        public TimeSpan WaitingTime { get; private set; } = default;
        public TimeSpan TimePerItem { get; private set; }
        public TimeSpan TimePerCustomer { get; private set; }
        private static readonly Random random = new Random();

        public CashRegister(string name, int id, int timePerItem, int timePerCustomer)
        {
            Name = name;
            Id = id;
            customersQueue = new BlockingCollection<Customer>(new ConcurrentQueue<Customer>());
            timePerItem = random.Next(1, timePerItem + 1);
            TimePerItem = new TimeSpan(0, 0, 0, timePerItem);
            timePerCustomer = random.Next(1, timePerCustomer + 1);
            TimePerCustomer = new TimeSpan(0, 0, 0, timePerCustomer);
        }

        public void AddCustomerToQueue(Customer customer)
        {
            customersQueue.Add(customer);
        }

        public Customer? GetFirstCustomer()
        {
            if (customersQueue.Count > 0)
            {
                return customersQueue.First();
            }
            return null;
        }

        public void ProcessCustomers()
        {
            while (Process()) { }
        }

        public bool Process()
        {
            if (customersQueue.Count > 0)
            {
                var customer = customersQueue.First();
                customersQueue.Take();
                ++CustomersProcessed;
                var workTime = TimePerItem * customer.ItemsAmount + TimePerCustomer;
                WaitingTime += workTime;
                Thread.Sleep(workTime);
                Console.WriteLine(
                    $"{DateTime.Now.ToString("HH:mm:ss")}: {Name} #{Id} finished processing {customer.Name}" +
                    $" with {customer.ItemsAmount} items" +
                    $" ({CustomersCount} customers and {ItemsCount} items left in the queue). " +
                    $"Total time spent: {WaitingTime}"
                );
                return true;
            }
            return false;
        }

        public bool Equals(CashRegister? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CashRegister)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} #{Id}";
        }
    }
}