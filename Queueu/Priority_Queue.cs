namespace Queue
{
    using System.Collections;
    using System.Collections.Generic;
    using System;

    public class Priority_Queue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        #region Fields

        private LinkedList<T> _items = new LinkedList<T>();

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
            if (_items.Count == 0)
            {
                _items.AddFirst(item);
            }

            else
            {
                var current = _items.First;

                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    _items.AddLast(item);
                }

                else
                {
                    _items.AddBefore(current, item);
                }
            }
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T value = _items.First.Value;
            _items.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T value = _items.First.Value;

            return value;
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
