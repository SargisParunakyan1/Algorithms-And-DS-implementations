

namespace Single_LinkedList
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : ICollection<T>
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

        #endregion

        #region Construction

        #endregion

        #region Operations

        #region Add

        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        public void AddFirst(Node<T> node)
        {
            //Save of the head's node so we do not lost it.
            Node<T> temp = Head;

            //Point heas as new created node.
            Head = node;

            //Insert the rest of the list behind the head.
            Head.Next = temp;

            //Since list has one node both 
            //tail and head shoud point to this single node.
            if (Count == 1)
            {
                Tail = Head;
            }

            Count++;
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
            }

            Count++;
        }

        #endregion

        #region Remove

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
            }
        }

        public void RemovelAst()
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
                    Node<T> current = Head;
                    while (current.Next != Tail)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    Tail = current;

                    Count--;
                }
            }
        }

        #endregion

        #endregion

        #region ICollection

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

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            Node<T> current = Head;
            if (current != null)
            {
                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        return true;
                    }

                    current = current.Next;
                }

                return false;
            }

            return false;
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

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            Node<T> previous = null;
            Node<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            Tail = previous;
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

        IEnumerator IEnumerable.GetEnumerator()
        {

            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        #endregion
    }
}