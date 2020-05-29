
namespace Binary_Tree
{
    using System;
    using System.Collections;

    /// <summary>
    /// Binary tree representation.
    /// </summary>
    public class Tree
    {
        #region Fields

        private Node root;  //First node of the tree, in other words ROOT of the tree.

        #endregion

        #region Operations

        /// <summary>
        /// Initializes the new instance of <see cref="Tree"/> class.
        /// </summary>
        public Tree()
        {
            root = null;
        }

        /// <summary>
        /// Find node in tree by the key.
        /// </summary>
        /// <param name="key">Key value of the node.</param>
        /// <returns><see cref="Node"/></returns>
        public Node FindKey(int key)
        {
            Node current = root; //Starting from root object.

            if (current != null) //Checking if tree is empty or no.
            {
                while (current.iData != key) //If iData is not eqaul to key then continue search
                {
                    if (current.iData > key)
                    {
                        current = current.LeftChild;
                    }

                    else
                    {
                        current = current.RightChild;
                    }

                    if (current == null)
                        return null;
                }
            }

            else
            {
                return null; //Tree is empty.
            }

            return current; //Successfuly find node with the given key.
        }

        /// <summary>
        /// Insert new node in Tree.
        /// </summary>
        /// <param name="id">Key data.</param>
        /// <param name="dd">Rest of the data.</param>
        public void Insert(int id, double dd)
        {
            Node newNode = new Node();
            newNode.iData = id;
            newNode.dData = dd;

            if (root == null)
            {
                root = newNode;
            }

            else
            {
                Node current = root;
                Node parent = null;

                while (true)
                {
                    parent = current; //Store current node to his parent node.

                    if (current.iData > id) // Traverse to the left?
                    {
                        current = current.LeftChild; 
                        if (current == null) //if current is null, then we find possiton fo the insertion.
                        {
                            parent.LeftChild = newNode;
                            return;
                        }
                    }
                    else  //Or traverse to the right.
                    {
                        current = current.RightChild;
                        if (current == null)
                        {
                            parent.RightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Delete the node with the given key.
        /// </summary>
        /// <param name="key">Key vaue of the node.</param>
        /// <returns>Returns <see cref="bool"/></returns>
        public bool Delete(int key)
        {
            Node current = root;
            Node parent = root;

            bool isLeftChild = true;

            while (current.iData != key)
            {
                parent = current;
                if (current.iData > key)             //Traverse left?
                {
                    isLeftChild = true;
                    current = current.LeftChild;
                }

                else                                  //Traverse right?
                {
                    isLeftChild = false;
                    current = current.RightChild;
                }

                if (current == null)
                {
                    return false;
                }
            }

            //If node does not have any descendants,it is just going to be deleted.
            if (current.LeftChild == null && current.RightChild == null)
            {
                if (current == root)
                {
                    root = null;
                }

                else if (isLeftChild)
                {
                    parent.LeftChild = null;
                }

                else
                {
                    parent.RightChild = null;
                }
            }

            //If node does not have  righ descendant.
            else if (current.RightChild == null)
            {
                if (current == root )
                {
                    root = current.LeftChild;
                }

                else if (isLeftChild)
                {
                    parent.LeftChild = current.LeftChild;
                }

                else
                {
                    parent.RightChild = current.RightChild;
                }
            }

            //If node does not have left descendant.
            else if (current.LeftChild == null)
            {
                if (current == root)
                {
                    root = current.RightChild;
                }

                else if (isLeftChild)
                {
                    parent.LeftChild = current.LeftChild;
                }

                else
                {
                    parent.RightChild = current.RightChild;
                }
            }

            else //Node has both, right and left descendants.
            {
                Node successor = GetSuccessor(current);

                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = successor;
                }

                else
                {
                    parent.RightChild = successor;
                }
            }

            return true;
        }

        /// <summary>
        /// Traverse tree in various ways.
        /// </summary>
        /// <param name="traverseType">Traverse type.</param>
        public void Traverse(int traverseType)
        {
            switch (traverseType)
            {
                case 1:
                    Console.WriteLine("\nPreOrder traversal: ");
                    PreOrder(root);
                    break;
                case 2:
                    Console.WriteLine("\nInorder traversal: ");
                    InOrder(root);
                    break;
                case 3:
                    Console.WriteLine("\nPostOrder traversal: ");
                    PostOrder(root);
                    break;
            }
        }

        /// <summary>
        /// Dipslay tree.
        /// </summary>
        public void DisplayTree()
        {
            Stack globalStack = new Stack();
            globalStack.Push(root);

            int nBlanks = 32;
            
            bool isRowEmpty = false;

            Console.WriteLine("..............................................");
            
            while (isRowEmpty == false)
            {
                Stack localStack = new Stack();
                isRowEmpty = true;

                for (int j = 0; j < nBlanks; j++)
                {
                    Console.Write("  ");
                }

                while (globalStack.Count != 0)
                {
                    Node temp = (Node)globalStack.Pop();
                    if (temp != null)
                    {
                        Console.Write(temp.iData);
                        Console.Write(temp.LeftChild);
                        Console.Write(temp.RightChild);

                        if (temp.LeftChild != null ||
                                                        temp.RightChild != null)
                        {
                            isRowEmpty = false;
                        }

                        else
                        {
                            Console.Write(" -- ");
                            localStack.Push(null);
                            localStack.Push(null);
                        }

                        for (int j = 0; j < nBlanks * 2 - 2; j++)
                        {
                            Console.Write(' ');
                        }

                        Console.WriteLine();
                        nBlanks /= 2;

                        while (localStack.Count != 0)
                        {
                            globalStack.Push(localStack.Pop());
                        }

                        Console.WriteLine(".....................................");
                    }
                }
            }
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Get successor for the deleted node.
        /// </summary>
        /// <param name="node">Successor node.</param>
        /// <returns><see cref="Node"/></returns>
        private Node GetSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node current = delNode.RightChild;

            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.LeftChild;
            }

            if (successor != delNode.RightChild)
            {
                successorParent.LeftChild = successor.RightChild;
                successor.RightChild = delNode.RightChild;
            }

            return successor;
        }

        private void PreOrder(Node root)
        {
            if (root != null)
            {
                Console.WriteLine(root.iData + "  ");
                PreOrder(root.LeftChild);
                PreOrder(root.RightChild);
            }
        }

        private void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.LeftChild);
                Console.WriteLine(root.iData + "  ");
                InOrder(root.RightChild);
            }
        }

        private void PostOrder(Node root)
        {
            PostOrder(root.LeftChild);
            PostOrder(root.RightChild);
            Console.WriteLine(root.iData + "  ");
        }

        #endregion
    }
}