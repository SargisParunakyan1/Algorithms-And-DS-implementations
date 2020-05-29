
namespace Binary_Tree
{
    using System;

    public class Node
    {
        public int iData;       //Key data for the node
        
        public double dData;    //Rest of the data

        public Node LeftChild;  //Left descendant

        public Node RightChild; //Right descendant

        public void DsiplayNode ()
        {
            Console.Write('{');
            Console.Write(iData);
            Console.Write(", ");
            Console.Write(dData);
            Console.Write('}');
        }
    }
}
