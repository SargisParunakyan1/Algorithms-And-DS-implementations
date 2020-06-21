
namespace Hash_Table
{
    public class HashTableNodePair<TKey, TValue>
    {
        #region Properties

        public TKey Key { get; private set; }

        public TValue Value { get; private set; }

        #endregion

        #region Construction

        public HashTableNodePair(TKey key, TValue value) 
        {
            Key = key;
            Value = value;
        }

        #endregion
    }
}