
namespace Binary_Tree
{
    using System;

    public class TreeApp
    {
        public static void Main()
        {
            int value;

            Tree theTree = new Tree();

            theTree.Insert(50, 1.5);
            theTree.Insert(60, 1.5);
            theTree.Insert(75, 1.5);
            theTree.Insert(15, 1.5);
            theTree.Insert(100, 1.5);
            theTree.Insert(150, 1.5);
            theTree.Insert(11, 1.5);

            while (true)
            {
                Console.Write("Enter the first letter of show.");
                Console.WriteLine("insert,find,delete or traverse");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 's':
                        theTree.DisplayTree();
                        break;
                    case 'i':
                        Console.WriteLine("Enter the value first: ");
                        value = int.Parse(Console.ReadLine());
                        theTree.Insert(value, value + 0.9);
                        break;
                    case 'f':
                        Console.WriteLine("Enter the value to find: ");
                        value = int.Parse(Console.ReadLine());
                        Node found = theTree.FindKey(value);
                        Console.Write("\n");
                        break;
                }
            }
        }
    }
}
