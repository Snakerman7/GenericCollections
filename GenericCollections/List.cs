using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCollections
{
    public class List<T> : ICollection<T>, IEnumerable<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _data;
        public int Count { get; private set; }
        public int Capacity
        {
            get => _data.Length;
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Resize(value);
            }
        }

        public List()
            : this(DEFAULT_CAPACITY) { }

        public List(int capacity)
        {
            _data = new T[capacity];
        }

        public void Add(T item)
        {
            if (Count == _data.Length)
            {
                Resize(_data.Length * 2);
            }
            _data[Count++] = item;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();
            if (Count == _data.Length)
            {
                Resize(_data.Length * 2);
            }
            for (int i = Count; i > index; i--)
            {
                _data[i] = _data[i - 1];
            }
            _data[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if(index != -1)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);
            Count--;
            for (int i = index; i < Count; i++)
            {
                _data[i] = _data[i + 1];
            }
            _data[Count] = default(T);
        }

        public void Clear()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                _data[i] = default(T);
            }
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_data[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_data[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return _data[index];
            }
            set
            {
                CheckIndex(index);
                _data[index] = value;
            }
        }

        public T[] ToArray()
        {
            T[] resArray = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                resArray[i] = _data[i];
            }
            return resArray;
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                T temp = _data[i];
                _data[i] = _data[Count - i - 1];
                _data[Count - i - 1] = temp;
            }
        }

        private void Resize(int newSize)
        {
            if (newSize > _data.Length)
            {
                T[] tempArray = new T[newSize];
                for (int i = 0; i < Count; i++)
                {
                    tempArray[i] = _data[i];
                }
                _data = tempArray;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
