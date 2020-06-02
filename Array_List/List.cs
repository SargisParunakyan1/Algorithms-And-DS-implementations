
namespace Array_List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IList<T>
    {
        #region Fields

        private T[] _items;

        #endregion

        #region Properties

        /// <summary>
        /// Count of the items in list.
        /// </summary>
        public int Count 
        {
            get;
            private set;
        }

        /// <summary>
        /// Is our list readonly?
        /// </summary>
        public bool IsReadOnly 
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Construction

        /// <summary>
        /// Initalizes the new instance of <see cref="List{T}"/> class.
        /// </summary>
        public List() : this(0)
        {

        }

        /// <summary>
        /// Initializes the new instance of <see cref="List{T}"/> class.
        /// </summary>
        /// <param name="length">Lenght of the list.</param>
        public List(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("length");
            }

            _items = new T[length];
        }

        #endregion

        #region Indexer

        /// <summary>
        /// Gets or sets the value at the specified index.
        /// </summary>
        /// <param name="index">Specified index.</param>
        /// <returns><see cref="T"/></returns>
        public T this[int index] 
        {
            get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return _items[index];
            }

            set
            {
                if (index < Count)
                {
                  _items[index] = value;
                }

                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        #endregion

        #region Operations

        /// <summary>
        /// Appends the provided value to the end of the collection.
        /// </summary>
        /// <param name="item">Item which is gonna be inserted at the end of the list.</param>
        public void Add(T item)
        {
            if (_items.Length == Count)
            {
                this.GrowArrayPolicie();
            }

            _items[Count++] = item;
        }

        /// <summary>
        /// Adds the provided value at the specified index in the collection. 
        /// If the specified index is equal to or larger than Count, an exception is thrown
        /// </summary>
        /// <param name="index">Indext at item should be inserted.</param>
        /// <param name="item"><see cref="T"/> item is gonna be inserted.</param>
        public void Insert(int index, T item)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (_items.Length == this.Count)
            {
                this.GrowArrayPolicie();
            }

            Array.Copy(_items, index, _items, index + 1, Count - index);
            Count++;
        }

        /// <summary>
        /// Removes the first item in the collection whose value matches the provided value. 
        /// </summary>
        /// <param name="item">Specified item.</param>
        /// <returns><see cref="bool"/>.</returns>
        public bool Remove(T item)
        {
            for( int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes the value at the specified index.
        /// </summary>
        /// <param name="index">Specified index.</param>
        public void RemoveAt(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            int shiftStart = index + 1;
            if(shiftStart < Count)
            {
                Array.Copy(_items, shiftStart, _items, index, Count - shiftStart);
            }
        }

        /// <summary>
        /// Returns the first index in the collection whose value equals the provided value. 
        /// Returns -1 if no matching value is found.
        /// </summary>
        /// <param name="item">Specified value.</param>
        /// <returns>Index of the specified value, or -1.</returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Returns true if the provided value exists in the collection. 
        /// Otherwise it returns false.
        /// </summary>
        /// <param name="item"></param>
        /// <returns><see cref="bool"/>.</returns>
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        /// <summary>
        /// Clear the list.
        /// </summary>
        public void Clear()
        {
            _items = new T[0];
            Count = 0;
        }

        /// <summary>
        /// Copies the contents of the internal array from start to finish into the provided array starting at the specified array index.
        /// </summary>
        /// <param name="array">External array.</param>
        /// <param name="arrayIndex">Array index.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, Count);
        }

        /// <summary> 
        ///Returns an IEnumerator<T> instance that allows enumerating the array list values in order from first to last.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation

        private void GrowArrayPolicie()
        {
            int newLength = _items.Length == 0 ? 16 : _items.Length * 2;

            T[] newArray = new T[newLength];
            _items.CopyTo(newArray, 0);
            _items = newArray;
        }

        #endregion
    }
}