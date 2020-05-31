
namespace Stack_Array
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Stack_List<T> : IEnumerable<T>
    {
        #region Fields

        private List<T> _items = new List<T>();

        #endregion

        #region Porperties

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        #endregion

        #region Operations

        public void Push(T item)
        {
            _items.Add(item);
        }

        public T Pop()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T item = _items.LastOrDefault();
            _items.RemoveAt(_items.Count - 1);

            return item;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T item = _items.LastOrDefault();

            return item;
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}