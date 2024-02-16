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
    }
}