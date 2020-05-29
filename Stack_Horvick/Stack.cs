
namespace Stack_LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        #region Fields 

        private LinkedList<T> list = new LinkedList<T>();

        #endregion

        #region Properties

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        #endregion

        #region Operations

        public void Push(T item)
        {
            list.AddFirst(item);
        }

        public T Pop(T item)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T value = list.First.Value;
            list.RemoveFirst();

            return value;
        }

        public T Peek ()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T value = list.First.Value;

            return value;
        }

        public void Clear()
        {
            list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion
    }
}