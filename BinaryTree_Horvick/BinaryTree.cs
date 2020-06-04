
namespace BinaryTree_Horvick
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryTree<T> : IEnumerable<T>
        where T: IComparable<T>
    {             
        #region Fields

        private BinaryTreeNode<T> _head;

        private int _count;

        #endregion

        #region Properties

        public int Count { get; private set; }

        #endregion

        #region Add

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            }

            else
            {
                AddTo(_head, value);
            }

            _count++;
        }

        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            if (node.Value.CompareTo(value) > 0)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new BinaryTreeNode<T>(value);
                }

                else
                {
                    AddTo(node.LeftNode, value);
                }
            }

            else
            {
                if (node.RightNode == null)
                {
                    node.RightNode = new BinaryTreeNode<T>(value);
                }

                else
                {
                    AddTo(node.RightNode, value);
                }
            }
        }

        #endregion

        #region Remove

        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;

            current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }

            _count--;

            //Case 1: If current has no right child, then curent's left node replaces current itself.
            if (current.RightNode == null)
            {
                if( parent == null )
                {
                    _head = current.LeftNode;
                }

                else
                {
                    int result = parent.CompareTo(current.Value);

                    if (result > 0)
                    {
                        parent.LeftNode = current.LeftNode;
                    }

                    else
                    {
                        parent.RightNode = current.LeftNode;
                    }
                }
            }

            //Case 2: If currents right child has no left child,
            //then currents right  child replaces current.
            else if (current.RightNode.LeftNode == null)
            {
                current.RightNode.LeftNode = current.LeftNode;

                if (parent == null)
                {
                    _head = current.RightNode;
                }

                else
                {
                    int result = parent.CompareTo(value);

                    if (result > 0)
                    {
                        parent.LeftNode = current.RightNode;
                    }

                    else if (result < 0)
                    {
                        parent.RightNode = current.RightNode;
                    }
                }
            }

            //Case 3: If current's right child has left child,
            //replace current with current's right child's left-most child. 
            else
            {
                BinaryTreeNode<T> leftMost = current.RightNode.LeftNode;
                BinaryTreeNode<T> leftMostParent = current.RightNode;

                while (leftMost.LeftNode != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.LeftNode;
                }

                //The parent's left subtree becomes the leftmoste's right subtree.
                leftMostParent.LeftNode = leftMost.RightNode;

                leftMost.LeftNode = current.LeftNode;
                leftMost.RightNode = current.RightNode;

                if (parent == null)
                {
                    _head = leftMost;
                }

                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.LeftNode = leftMost;
                    }

                    else if (result < 0)
                    {
                        parent.RightNode = leftMost;
                    }
                }
            }

            return true;
        }

        #endregion

        #region Traversals

        #region Pre-Order Traversal

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        public void PreOrderTraversal(Action<T> action , BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.LeftNode);
                PreOrderTraversal(action, node.RightNode);
            }
        }

        #endregion

        #region Post-Order Traversal

        public void PosOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }

        public void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.LeftNode);
                PostOrderTraversal(action, node.RightNode);
                action(node.Value);
            }
        }

        #endregion

        #region In-Order traversal

        public void InorderTraversal(Action<T> action)
        {
            InorderTraversal(action, _head);
        }

        public void InorderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InorderTraversal(action,node.LeftNode);
                action(node.Value);
                InorderTraversal(action,node.RightNode);
            }
        }

        #endregion

        #region Non-Recursive In-Order traversal

        public IEnumerator<T> InOrderTraversal()
        {
            if (_head != null)
            {
                BinaryTreeNode<T> current = _head;
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();

                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.LeftNode != null)
                        {
                            stack.Push(current);
                            current = current.LeftNode;
                        }
                    }

                    yield return current.Value;

                    if (current.RightNode != null)
                    {
                        current = current.RightNode;

                        goLeftNext = true;
                    }

                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Imlementation

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = _head;
            parent = null;

            while (current != null)
            {
                if (current.Value.CompareTo(value) > 0)
                {
                    parent = current;
                    current = current.LeftNode;
                }

                else if (current.Value.CompareTo(value) < 0)
                {
                    parent = current;
                    current = current.RightNode;
                }

                else
                {
                    break;
                }
            }

            return current;
        }


        #endregion

        #region Other

        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent = null;
            return  FindWithParent(value, out parent) != null;
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}