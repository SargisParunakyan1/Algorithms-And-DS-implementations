
namespace Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Queue_List<T> : IEnumerable<T>
    {
        #region Fields

        private List<T> _items = new List<T>();

        #endregion

        #region Properties

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        #endregion

        #region Operations

        public void Enqueue(T item)
        {
            _items.Add(item);
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T item = _items.FirstOrDefault();
            _items.RemoveAt(0);

            return item;
        }

        public T  Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T item = _items.FirstOrDefault();

            return item;
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        #endregion
    }
}