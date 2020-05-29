
namespace Doubly_LinkedList
{
    public class Node<T>
    {
        #region Proerties

        public T Value { get; set; }

        public Node<T> Next { get; set; }
        
        public Node<T> Previous { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Initalizes the new instacne of <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="value">Value of the node.</param>
        public Node(T value)
        {
            Value = value;
        }

        #endregion
    }
}
