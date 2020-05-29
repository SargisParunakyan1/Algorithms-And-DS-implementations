
namespace Doubly_LinkedList
{
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : ICollection<T>
    {
        #region Properties

        public Node<T> Head
        {
            get;
            private set;
        }

        public Node<T> Tail
        {
            get;
            private set;
        }

        public int Count 
        {
            get;
            private set;
        }

        public bool IsReadOnly 
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Operations

        #region Add

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        public void AddFirst(Node<T> node)
        {
            Node<T> temp = Head;

            Head = node;

            Head.Next = temp;

            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }

            else
            {
                temp.Previous = Head;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        public void AddLast(Node<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }

            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }

        #endregion

        #region Remove

        public bool Remove(T item)
        {
            Node<T> previous = null;
            Node<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    //This means it is a node in the midle or end
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        //Last node
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }

                        else
                        {
                            current.Next.Previous = previous;
                        }

                        Count--;
                    }

                    else
                    {
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;

            }

            return false;
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }

                else
                {
                    Head.Previous = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }

                else
                {
                    Tail.Previous.Next = null;
                    Tail = Tail.Previous;
                }

                Count--;
            }
        }

        #endregion

        public bool Contains(T item)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();

        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        #endregion
    }
}
