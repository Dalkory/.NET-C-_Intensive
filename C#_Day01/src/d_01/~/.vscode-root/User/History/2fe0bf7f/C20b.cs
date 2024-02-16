using System;

namespace s21_d01
{
    public class Customer
    {
        public string Name { get; }
        public int Id { get; }

        public Customer(string name, int id)
        {
            Name = name;
            Id = id;
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
            return !(left.Equals(right));
        }
    }
}