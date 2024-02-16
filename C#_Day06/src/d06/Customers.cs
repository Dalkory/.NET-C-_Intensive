namespace s21_d06
{
    public class Customer : IEquatable<Customer>
    {
        public string Name { get; }
        public int Id { get; }
        public int ItemsAmount { get; private set; }
        private static Random _random = new Random();

        public Customer(string name, int id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Id = id;
            ItemsAmount = 0;
            _random ??= new Random();
        }

        public void ShoppingList(int MaxCapacity)
        {
            ItemsAmount = _random.Next(1, MaxCapacity + 1);
        }

        public void FillCart(Storage storage)
        {
            ItemsAmount = storage.GetItems(ItemsAmount);
        }

        public static bool operator ==(Customer? customer1, Customer? customer2)
        {
            if (ReferenceEquals(customer1, customer2))
                return true;
            if (ReferenceEquals(customer1, null))
                return false;
            if (ReferenceEquals(customer2, null))
                return false; 
            if (customer1.Id == customer2.Id 
                && customer1.Name == customer2.Name)
                return true;
            return false;
        }

        public static bool operator !=(Customer? customer1, Customer? customer2)
        {
            if (ReferenceEquals(customer1, customer2))
                return false;
            if (ReferenceEquals(customer1, null))
                return true;
            if (ReferenceEquals(customer2, null))
                return true; 
            if (customer1.Id != customer2.Id
                || customer1.Name != customer2.Name) 
                return true; 
            return false;
        }

        public bool Equals(Customer? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public override string ToString()
        {
            return $"{Name}, customer #{Id}";
        }
    }
}