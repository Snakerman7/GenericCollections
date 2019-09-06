using System;

namespace GenericCollections
{
    public sealed class BinaryTreeNode<T>  where T : IComparable<T>
    {
        public T Value { get; internal set; }
        public BinaryTreeNode<T> Left { get; internal set; }
        public BinaryTreeNode<T> Right { get; internal set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }
    }

    public class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }
        public int Count { get; private set; }

        public void Add(T item)
        {
            Root = Insert(Root, item);
        }

        public bool Contains(T item)
        {
            return Search(Root, item) != null;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public T[] ToArray()
        {
            T[] resArr = new T[Count];
            FillArrayInOrder(Root, resArr, 0);
            return resArr;
        }

        private BinaryTreeNode<T> Insert(BinaryTreeNode<T> root, T item)
        {
            if (root is null)
            {
                root = new BinaryTreeNode<T>(item);
                Count++;
                return root;
            }
            if (item.CompareTo(root.Value) < 0)
            {
                root.Left = Insert(root.Left, item);
            }
            else if (item.CompareTo(root.Value) > 0)
            {
                root.Right = Insert(root.Right, item);
            }
            return root;
        }

        private BinaryTreeNode<T> Search(BinaryTreeNode<T> root, T item)
        {
            if (root is null)
            {
                return null;
            }
            if (root.Value.CompareTo(item) > 0)
            {
                return Search(root.Left, item);
            }
            else if (root.Value.CompareTo(item) < 0)
            {
                return Search(root.Right, item);
            }
            return root;
        }

        private int FillArrayInOrder(BinaryTreeNode<T> root, T[] arr, int curIndex)
        {
            if (root != null)
            {
                curIndex = FillArrayInOrder(root.Left, arr, curIndex);
                arr[curIndex++] = root.Value;
                curIndex = FillArrayInOrder(root.Right, arr, curIndex);
            }
            return curIndex;
        }
    }
}
