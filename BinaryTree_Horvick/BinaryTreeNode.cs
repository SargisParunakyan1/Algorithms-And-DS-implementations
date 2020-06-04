
namespace BinaryTree_Horvick
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class BinaryTreeNode<TNode> : IComparable<TNode>
            where TNode:IComparable<TNode>
    {
        #region  Constructor

        public BinaryTreeNode(TNode value)
        {

        }

        #endregion

        #region Properties

        public TNode Value { get; set; }

        public BinaryTreeNode<TNode> LeftNode { get; set; }

        public BinaryTreeNode<TNode> RightNode { get; set; }

        #endregion

        #region Operation

        public int CompareTo([AllowNull] TNode other)
        {
            return Value.CompareTo(other);
        }

        #endregion
    }
}