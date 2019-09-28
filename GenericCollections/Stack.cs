using System;

namespace GenericCollections
{
    public class Stack<T>
    {
        private LinkedList<T> _data;

        public int Count
        {
            get => _data.Count;
        } 

        public Stack()
        {
            _data = new LinkedList<T>();
        }

        public void Puch(T item)
        {
            _data.AddFirst(item);
        }

        public T Pop()
        {
            if (_data.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T item = _data.First.Value;
            _data.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            if (_data.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
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
