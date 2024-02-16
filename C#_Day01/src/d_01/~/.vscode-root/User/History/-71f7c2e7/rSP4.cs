namespace s21_d01
{
    public class Storage 
    {
        int Count = 0;
        int Capacity = 0;

        public Storage(int capacity) {
            if (items > 0) {
                Capacity = capacity;
            } else {
                Capacity = 0;
            }
            Count = Capacity;
        }

        public bool isEmpty() => Count == 0;
    }
}