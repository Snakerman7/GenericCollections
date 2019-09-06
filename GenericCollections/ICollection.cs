namespace GenericCollections
{
    public interface ICollection<T>
    {
        void Add(T item);
        bool Remove(T item);
        void Clear();
        bool Contains(T item);
        T[] ToArray();
    }
}
