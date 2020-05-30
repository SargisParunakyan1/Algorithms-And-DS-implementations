
namespace Queueu
{
    namespace Queue
    {
        using System;
        using System.Collections;
        using System.Collections.Generic;

        public class Queue_Array<T> : IEnumerable<T>
        {
            #region Fields 

            T[] _items = new T[0];

            private int _head = 0;

            private int _size = 0;

            private int _tail = -1;

            #endregion

            #region Properties

            public int Count
            {
                get
                {
                    return _size;
                }
            }

            #endregion

            #region Operations

            public void Enqueue(T item)
            {
                //If array needs to grow
                if (_size == _items.Length)
                {
                    int newLength = (_size == 0) ? 4 : (_size * 2);

                    T[] newArray = new T[newLength];

                    if (_size > 0)
                    {
                        int targetIndex = 0;

                        if (_tail < _head)
                        {
                            for (int index = _head; index < _items.Length; index++)
                            {
                                newArray[targetIndex] = _items[index];
                                targetIndex++;
                            }

                            for (int index = 0; index <= _tail; index++)
                            {
                                newArray[targetIndex] = _items[index];
                            }
                        }

                        else
                        {
                            for (int index = 0; index < _items.Length; index++)
                            {
                                newArray[targetIndex] = _items[index];
                                targetIndex++;
                            }
                        }

                        _head = 0;
                        _tail = targetIndex - 1;
                    }

                    else
                    {
                        _head = 0;
                        _tail = 0;
                    }

                    _items = newArray;
                }

                if (_tail == _items.Length - 1)
                {
                    _tail = 0;
                }

                else
                {
                    _tail++;
                }

                _items[_tail] = item;
                _size++;
            }

            public T Dequeue()
            {
                if (_size == 0)
                {
                    throw new InvalidOperationException("The dequeue is empty.");
                }

                T value = _items[_head];

                if (_head == _items.Length - 1)
                {
                    _head = 0;
                }

                else
                {
                    _head++;
                }

                return value;
            }

            public T Peek()
            {
                if (_size == 0)
                {
                    throw new InvalidOperationException("The queue is empty.");
                }

                T value = _items[_head];

                return value;
            }

            public void Clear()
            {
                _size = 0;
                _head = 0;
                _tail = -1;
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (_size > 0)
                {
                    if (_head > _tail)
                    {
                        //Head -> end
                        for (int index = _head; index < _items.Length; index++)
                        {
                            yield return _items[index];
                        }

                        //0 -> tail
                        for (int index = 0; index <= _tail; index++)
                        {
                            yield return _items[index];
                        }
                    }

                    else
                    {
                        //head -> tail
                        for (int index = _head; index <= _tail; index++)
                        {
                            yield return _items[index];
                        }
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            #endregion
        }
    }
}