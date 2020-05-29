
namespace Stack_Array
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        #region Fields
        
        private T[] items = new T[0];

        private int size = 0;

        #endregion

        #region Operations

        public void Push(T item)
        {
            if (size == items.Length)
            {
                int newLength = size == 0 ? 4 : size * 2;
                T[] newArray = new T[newLength];
                items.CopyTo(newArray, 0);
                items = newArray;
            }

            items[size++] = item;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            size--;
            var value = items[size];

            return value;
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return items[size - 1];
        }

        public void Clear()
        {
            size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = size - 1; size >= 0; size --)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}