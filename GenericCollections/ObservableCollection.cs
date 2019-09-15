using System;

namespace GenericCollections
{
    public enum NotifyCollectionChangedAction
    {
        Add,
        Move,
        Remove,
        Replace,
        Reset
    }

    public class NotifyCollectionChangedEventArgs
    {
        public NotifyCollectionChangedAction Action { get; }
        public object NewItem { get; }
        public object OldItem { get; }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action)
            :this(action, null, null)
        {
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem)
            : this(action, newItem, null)
        {
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem)
        {
            Action = action;
            NewItem = newItem;
            OldItem = oldItem;
        }
    }

    public delegate void NotifyCollectionChangedEventHandler(object sender,
        NotifyCollectionChangedEventArgs e);

    public class ObservableCollection<T>
    {
        private List<T> _items;
        public int Count
        {
            get => _items.Count;
        }
        public T this[int index]
        {
            get
            {
                return _items[index];
            }

            set
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, _items[index]));
                _items[index] = value;
            }
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ObservableCollection()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public void Insert(int index, T item)
        {
            _items.Insert(index, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
        }

        public bool Remove(T item)
        {
            bool res = _items.Remove(item);
            if (res)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            }
            return res;
        }

        public void Move(int oldIndex, int newIndex)
        {
            T item = _items[oldIndex];
            _items.RemoveAt(oldIndex);
            _items.Insert(newIndex, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move));
        }

        public void Clear()
        {
            _items.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }
    }
}
