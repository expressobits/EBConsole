namespace ExpressoBits.Console.Utils
{
    public class CircularBuffer<T>
    {
        public T[] array;
        private int m_StartIndex;

        public int Count { get; private set; }
        public T this[int index] => array[(m_StartIndex + index) % array.Length];

        public CircularBuffer(int capacity)
        {
            array = new T[capacity];
        }

        public void Add(T value)
        {
            if (Count < array.Length)
            {
                array[Count++] = value;
            }
            else
            {
                array[m_StartIndex] = value;
                if (++m_StartIndex >= array.Length)
                    m_StartIndex = 0;
            }
        }
    }
}