namespace s21_d01
{
    public class Storage 
    {
        public int Count { get; private set; }
        public int Capacity { get; }

        public Storage(int capacity) 
        {
            Capacity = capacity > 0 ? capacity : 0;
            Count = Capacity;
        }

        public int GetItems(int ItemsAmount) 
        {
            if (ItemsAmount > Count)
            {
                ItemsAmount = Count;
                Count = 0;
                return ItemsAmount;
            }
            Count -= ItemsAmount;
            return ItemsAmount;
        }

        public bool IsEmpty() => Count == 0;
    }
}