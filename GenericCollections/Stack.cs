namespace GenericCollections
{
    public class Stack<T>
    {
        private LinkedList<T> _data;

        public Stack()
        {
            _data = new LinkedList<T>();
        }

        public void Puch(T item)
        {
            _data.AddFirst(item);
        }

        public object Pop()
        {
            object item = _data.First.Value;
            _data.RemoveFirst();
            return item;
        }

        public object Peek()
        {
            return _data.First.Value;
        }

        public bool Contains(T item)
        {
            return _data.Contains(item);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public T[] ToArray()
        {
            return _data.ToArray();
        }
    }
}
