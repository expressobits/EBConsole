namespace ExpressoBits.Console.Utils
{
    public class CircularBuffer<T>
    {
        public readonly T[] Array;
        private int m_StartIndex;

        public int Count { get; private set; }
        public T this[int index] => Array[(m_StartIndex + index) % Array.Length];

        public CircularBuffer(int capacity)
        {
            Array = new T[capacity];
        }

        public void Add(T value)
        {
            if (Count < Array.Length)
            {
                Array[Count++] = value;
            }
            else
            {
                Array[m_StartIndex] = value;
                if (++m_StartIndex >= Array.Length)
                    m_StartIndex = 0;
            }
        }
    }
}