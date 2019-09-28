using System;

namespace GenericCollections
{
    public sealed class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; internal set; }
        public LinkedListNode<T> Previous { get; internal set; }
    }

    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> First { get; private set; }
        public LinkedListNode<T> Last { get; private set; }
        public int Count { get; private set; }

        public void Add(T item)
        {
            Count++;
            var node = new LinkedListNode<T>(item);
            if (Last == null)
            {
                Last = node;
                First = Last;
            }
            else
            {
                Last.Next = node;
                node.Previous = Last;
                Last = node;
            }
        }

        public void AddFirst(T item)
        {
            Count++;
            var node = new LinkedListNode<T>(item);
            if (First == null)
            {
                First = node;
                Last = First;
            }
            else
            {
                First.Previous = node;
                node.Next = First;
                First = node;
            }
        }

        public bool Remove(T item)
        {
            if (Count == 1)
            {
                if (First.Value.Equals(item))
                {
                    First = Last = null;
                    return true;
                }
            }
            else
            {
                var node = First;
                while (node != null)
                {
                    if (node.Value.Equals(item))
                    {
                        node.Previous.Next = node.Next;
                        node.Next.Previous = node.Previous;
                        Count--;
                        return true;
                    }
                    node = node.Next;
                }
            }
            return false;
        }

        public void RemoveFirst()
        {
            if (First != null)
            {
                if (Count > 1)
                {
                    First = First.Next;
                    First.Previous = null;
                    Count--;
                }
                else
                {
                    First = null;
                    Last = null;
                    Count--;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void RemoveLast()
        {
            if (Last != null)
            {
                if (Count > 1)
                {
                    Last = Last.Previous;
                    Last.Next = null;
                    Count--;
                }
                else
                {
                    First = null;
                    Last = null;
                    Count--;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public bool Contains(T item)
        {
            var node = First;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public T[] ToArray()
        {
            if (Count == 0)
            {
                return null;
            }
            T[] resArr = new T[Count];
            var node = First;
            for (int i = 0; node != null; i++, node = node.Next)
            {
                resArr[i] = node.Value;
            }
            return resArr;
        }

        public void Clear()
        {
            LinkedListNode<T> node;
            while (First != null)
            {
                node = First;
                First = node.Next;
                node.Next = null;
                node.Previous = null;
            }
            Last = null;
            Count = 0;
        }
    }
}
