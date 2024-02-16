namespace s21_d06
{
    public class Storage 
    {
        public int Count { get; private set; }
        public int Capacity { get; }

        private readonly object itemsLock = new object();

        public Storage(int capacity) 
        {
            Capacity = capacity > 0 ? capacity : 0;
            Count = Capacity;
        }

        public int GetItems(int ItemsAmount) 
        {
            lock (itemsLock)
            {
                if (ItemsAmount > Count)
                {
                    ItemsAmount = Count;
                    Count = 0;
                }
                else
                {
                    Count -= ItemsAmount;
                }
                return ItemsAmount;
            }
        }

        public bool IsEmpty() => Count == 0;
    }
}