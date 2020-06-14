
namespace Hash_Table
{
    using System;
    using System.Collections.Generic;

    public class HashTableArray<TKey,TValue>
    {
        #region Fields

        private HashTableArrayNode<TKey, TValue>[] _array;

        #endregion

        #region Properties

        /// <summary>
        /// The capacity of the hash table array
        /// </summary>
        public int Capacity
        {
            get 
            {
                return _array.Length;
            }
        }

        public IEnumerable<TKey> Keys 
        {
            get
            {
                foreach (HashTableArrayNode<TKey,TValue> node in _array) 
                {
                    foreach (TKey key in node.Keys) 
                    {
                        yield return key;
                    }
                }
            }
        }

        public IEnumerable<TValue> Values 
        {
            get 
            {
                foreach (HashTableArrayNode<TKey,TValue> node in _array) 
                {
                    foreach (TValue value in node.Values) 
                    {
                        yield return value;
                    }
                }
            }
        }

        public IEnumerable<HashTableNodePair<TKey,TValue>> Node 
        {
            get 
            {
                foreach (HashTableArrayNode<TKey,TValue> node in _array) 
                {
                    foreach (HashTableNodePair<TKey,TValue> pair in node.Items) 
                    {
                        yield return pair;
                    }
                }
            }
        }

        #endregion

        #region Construction

        /// <summary>
        /// Constructs a new hash table array with the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity of the array</param>
        public HashTableArray(int capacity) 
        {
            _array = new HashTableArrayNode<TKey, TValue>[capacity];
            for (int i = 0; i < _array.Length; i++) 
            {
                _array[i] = new HashTableArrayNode<TKey, TValue>();
            }
        }

        #endregion

        #region Operations

        /// <summary>
        /// Adds the key/value pair to the node.  If the key already exists in the
        /// node array an ArgumentException will be thrown
        /// </summary>
        /// <param name="key">The key of the item being added</param>
        /// <param name="value">The value of the item being added</param>
        public void AddKey(TKey key, TValue value) 
        {
            _array[GetIndex(key)].Add(key,value);
        }

        /// <summary>
        /// Updates the value of the existing key/value pair in the node array.
        /// If the key does not exist in the array an ArgumentException
        /// will be thrown.
        /// </summary>
        /// <param name="key">The key of the item being updated</param>
        /// <param name="value">The updated value</param>
        public void Update(TKey key, TValue value) 
        {
            _array[GetIndex(key)].Update(key, value);
        }

        /// <summary>
        /// Removes the item from the node array whose key matches
        /// the specified key.
        /// </summary>
        /// <param name="key">The key of the item to remove</param>
        /// <returns>True if the item was removed, false otherwise.</returns>
        public bool Remove(TKey key, TValue value) 
        {
           return _array[GetIndex(key)].Remove(key);
        }

        /// <summary>
        /// Finds and returns the value for the specified key.
        /// </summary>
        /// <param name="key">The key whose value is sought</param>
        /// <param name="value">The value associated with the specified key</param>
        /// <returns>True if the value was found, false otherwise</returns>
        public bool TryGetValue(TKey key, out TValue value) 
        {
            return _array[GetIndex(key)].TryGetValue(key, out value);
        }

        /// <summary>
        /// Removes every item from the hash table array
        /// </summary>
        public void Clear() 
        {
            foreach (HashTableArrayNode<TKey, TValue> node in _array) 
            {
                node.Clear();
            }
        }

        #endregion

        #region Implementation

        private int GetIndex(TKey key) 
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }

        #endregion
    }
}
