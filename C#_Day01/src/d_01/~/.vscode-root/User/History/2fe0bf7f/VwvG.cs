using System;

namespace s21_d01
{
    public class Customers
    {
        string name;
        int id;
        private static Random _random = null;

        public Customer(string Name, int Id)
        {
            id = Id;
            name = Name;
            _random ??=new Random();
        }

        public override string ToString()
        {
            return $"{name}, customer #{id}";
        }
    }
}