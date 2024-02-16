using System;

namespace s21_d01
{
    public class Customer
    {
        public string Name { get; }
        public int Id { get; }
        public int ItemsAmount { get; private set; }
        private static Random? _random = null;

        public Customer(string name, int id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Id = id;
            ItemsAmount = 0;
            _random ??= new Random();
        }

        public void FillCart(int MaxItems)
        {
            ItemsAmount = _random.Next(1, MaxItems + 1);
        }

        public void Buy(int ItemsToBuy)
        {
            if(ItemsToBuy > ItemsAmount)
            {
                ItemsAmount = 0;
            }
            ItemsAmount -= ItemsToBuy;
        }

        public override string ToString()
        {
            return $"{Name}, customer #{Id}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Customer)obj;
            return Id == other.Id && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id);
        }

        public static bool operator ==(Customer left, Customer right)
        {
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Customer left, Customer right)
        {
            return !(left == right);
        }
    }
}