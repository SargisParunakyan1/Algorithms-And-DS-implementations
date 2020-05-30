
namespace Queue_LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class Queue<T> : IEnumerable<T>
    {
        #region Fields

        private LinkedList<T> _list = new LinkedList<T>();

        #endregion

        #region properties
        
        public int Count
        {
            get
            {
               return  _list.Count;
            }
        }

        #endregion

        #region Operations

        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        public T Dequeue()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T value = _list.First.Value;
            _list.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T value = _list.First.Value;

            return value;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return  _list.GetEnumerator();
        }

        #endregion
    }
}
