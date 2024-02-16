using System;

namespace s21_d01
{
    public class Customers
    {
        string name;
        int id;

        public Customers(string Name, int Id)
        {
            id = Id;
            name = Name;
        }

        public override string ToString()
        {
            return $"{name}, customer #{id}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Customers)obj;
            return id == other.id && name == other.name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, id);
        }
    }
}