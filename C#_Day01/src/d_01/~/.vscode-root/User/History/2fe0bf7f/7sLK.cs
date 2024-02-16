namespace s21_d01
{
    public class Customers
    {
        string name;
        int id;
        
        public Customer(string Name, int Id)
        {
            id = Id;
            name = Name;
        }

        public override string ToString()
        {
            return $"{name}, customer #{id}"
        }
    }
}