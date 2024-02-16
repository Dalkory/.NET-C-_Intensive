namespace s21_d01
{
    public class CashRegister 
    {
        public string Name { get; }
        public int Id { get; }
        private Queue<Customer> _customerQueue = new Queue<Customer>();

        public CashRegister(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public void EnqueueCustomer(Customer customer)
        {
            _customerQueue.Enqueue(customer);
        }

        public Customer DequeueCustomer()
        {
            return _customerQueue.Dequeue();
        }

        public override string ToString()
        {
            return $"{Name} #{Id}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (CashRegister)obj;
            return Id == other.Id && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id);
        }

        public static bool operator ==(CashRegister left, CashRegister right)
        {
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(CashRegister left, CashRegister right)
        {
            return !(left == right);
        }
    }
}