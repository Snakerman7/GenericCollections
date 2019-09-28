using System;

namespace GenericCollections
{
    public class Queue<T>
    {
        private LinkedList<T> _data;

        public Queue()
        {
            _data = new LinkedList<T>();
        }

        public int Count
        {
            get => _data.Count;
        }

        public void Enqueue(T item)
        {
            _data.AddFirst(item);
        }

        public T Dequeue()
        {
            if(_data.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T res = _data.Last.Value;
            _data.RemoveLast();
            return res;
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T item)
        {
            return _data.Contains(item);
        }

        public T Peek()
        {
            if (_data.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return _data.Last.Value;
        }

        public T[] ToArray()
        {
            return _data.ToArray();
        }
    }
}
