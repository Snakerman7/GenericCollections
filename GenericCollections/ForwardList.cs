namespace GenericCollections
{
    public sealed class ForwardListNode<T>
    {
        public ForwardListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public ForwardListNode<T> Next { get; internal set; }
    }

    public class ForwardList<T> : ICollection<T>
    {
        public ForwardListNode<T> First { get; private set; }
        public ForwardListNode<T> Last { get; private set; }
        public int Count { get; private set; }

        public ForwardList()
        {
            Count = 0;
        }

        public void Add(T item)
        {
            Count++;
            var node = new ForwardListNode<T>(item);
            if (Last == null)
            {
                Last = node;
                First = Last;
                return;
            }
            Last.Next = node;
            Last = node;
        }

        public void AddFirst(T item)
        {
            var node = new ForwardListNode<T>(item);
            if (First == null)
            {
                Last = node;
                First = Last;
                return;
            }
            node.Next = First;
            First = node;
            Count++;
        }

        public void Insert(ForwardListNode<T> node, T item)
        {
            var newNode = new ForwardListNode<T>(item);
            newNode.Next = node.Next;
            node.Next = newNode;
            Count++;
        }

        public bool Remove(T item)
        {
            if (Count == 1)
            {
                if (First.Value.Equals(item))
                {
                    First = Last = null;
                    Count--;
                    return true;
                }
            }
            ForwardListNode<T> node = First;
            ForwardListNode<T> prev = null;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    prev.Next = node.Next;
                    Count--;
                    return true;
                }
                prev = node;
                node = node.Next;
            }
            return false;
        }

        public void Clear()
        {
            if (First == null)
            {
                return;
            }
            var node = First;
            while (node.Next != null)
            {
                var temp = node.Next;
                node.Next = null;
                node = temp;
            }
            First = null;
            Last = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (First == null)
            {
                return false;
            }
            var node = First;
            do
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            } while (node != null);
            return false;
        }

        public T[] ToArray()
        {
            if (First == null)
                return null;
            T[] resArray = new T[Count];
            var node = First;
            int index = 0;
            do
            {
                resArray[index++] = node.Value;
                node = node.Next;
            } while (node != null);
            return resArray;
        }
    }
}
