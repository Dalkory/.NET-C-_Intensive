namespace s21_d01
{
    public class CashRegister 
  {
        public string Name { get; }
        public int Id { get; }

        public CashRegister(string name, int id)
        {
            Name = name;
            Id = id;
            ItemsAmount = 0;
            _random ??= new Random();
        }

        public void FillCart(int MaxItems)
        {
            ItemsAmount = _random.Next(1, MaxItems + 1);
        }

        public override string ToString()
        {
            return $"{Name}, CashRegister #{Id}";
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