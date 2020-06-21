
namespace Hash_Table
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The hash table data chain
    /// </summary>
    /// <typeparam name="TKey">The key type of the hash table</typeparam>
    /// <typeparam name="TValue">The value type of the hash table</typeparam>
    public class HashTableArrayNode<TKey, TValue>
    {
        #region Fields

        private LinkedList<HashTableNodePair<TKey, TValue>> _items;

        #endregion

        #region Properties

        public IEnumerable<TValue> Values 
        {
            get
            {
                if(_items != null) 
                {
                    foreach (HashTableNodePair<TKey,TValue> pair in _items) 
                    {
                        yield return pair.Value;
                    }
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                if (_items != null) 
                {
                    foreach (HashTableNodePair<TKey,TValue> pair in _items) 
                    {
                        yield return pair.Key;
                    }
                }
            }
        }

        public IEnumerable<HashTableNodePair<TKey,TValue>> Items
        {
            get
            {
                if (_items != null) 
                {
                    foreach (HashTableNodePair<TKey,TValue> pair in _items) 
                    {
                        yield return pair;
                    }
                }
            }
        }

        #endregion

        #region Operations

        /// <summary>
        /// Adds the key/value pair to the node.  If the key already exists in the
        /// list an ArgumentException will be thrown
        /// </summary>
        /// <param name="key">The key of the item being added</param>
        /// <param name="value">The value of the item being added</param>
        public void Add(TKey key, TValue value)
        {
            if (_items == null)
            {
                _items = new LinkedList<HashTableNodePair<TKey, TValue>>();
            }

            else 
            {
                // Multiple items might collide and exist in this list - but each
                // key should only be in the list once.
                foreach (HashTableNodePair<TKey,TValue> par in _items) 
                {
                    if (par.Key.Equals(key)) 
                    {
                        throw new ArgumentException("The collection already contains the key.");
                    }
                }
            }

            _items.AddFirst(new HashTableNodePair<TKey, TValue>(key,value));
        }

        /// <summary>
        /// Updates the value of the existing key/value pair in the list.
        /// If the key does not exist in the list an ArgumentException
        /// will be thrown.
        /// </summary>
        /// <param name="key">The key of the item being updated</param>
        /// <param name="value">The updated value</param>
        public void Update(TKey key, TValue value) 
        {
            bool updated = false;

            if (_items != null) 
            {
                foreach (HashTableNodePair<TKey,TValue> pair in _items) 
                {
                    if(pair.Key.Equals(key)) 
                    {
                        pair.Value = value;
                        updated = true;
                        break;
                    }
                }

                if (!updated) 
                {
                    throw new ArgumentException("The collectuion does not contain the given key.");
                }
            }
        }

        /// <summary>
        /// Finds and returns the value for the specified key.
        /// </summary>
        /// <param name="key">The key whose value is sought</param>
        /// <param name="value">The value associated with the specified key</param>
        /// <returns>True if the value was found, false otherwise</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            bool found = false;

            if (_items != null)
            {
                foreach (HashTableNodePair<TKey,TValue> pair in _items ) 
                {
                    if (pair.Key.Equals(key)) 
                    {
                        value = pair.Value;
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        /// <summary>
        /// Removes the item from the list whose key matches
        /// the specified key.
        /// </summary>
        /// <param name="key">The key of the item to remove</param>
        /// <returns>True if the item was removed, false otherwise.</returns>
        public bool Remove(TKey key) 
        {
            bool removed = false;

            LinkedListNode<HashTableNodePair<TKey,TValue>> current = _items.First;

            while (current != null) 
            {
                if (current.Value.Key.Equals(key)) 
                {
                    _items.Remove(current);
                    removed = true;
                    break;
                }

                current = current.Next;
            }

            return removed;
        }

        public void Clear() 
        {
            if (_items != null) 
            {
                _items.Clear();
            }
        }

        #endregion
    }
}