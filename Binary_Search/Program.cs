using System;

namespace Binary_Search
{
    public class BinarySearch
    {
        public static bool Search(int[] sortedArr, int key)
        {
            if (sortedArr == null)
            {
                throw new ArgumentException("Array is null.");
            }

            if (sortedArr.Length == 1)
            {
                if (sortedArr[0] == key)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            int min = 0;
            int max = sortedArr.Length - 1;

            while (max >= min )
            {
                int mid = (min + max) / 2;

                if (sortedArr[mid] == key)
                {
                    return true;
                }

                else if (sortedArr[mid] > key)
                {
                    max = mid - 1;
                }

                else
                {
                    min = mid + 1;
                }
            }

            return false;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to  Binary Search.");
            Console.WriteLine();

            Console.WriteLine("Input sorted array please.");
            Console.WriteLine();

            int[] sortedArry = new int[10];
            for (int i = 0; i < sortedArry.Length; i++)
            {
                sortedArry[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Please input the key.");
            Console.WriteLine();

            int key = int.Parse(Console.ReadLine());

            if (BinarySearch.Search(sortedArry, key))
            {
                Console.WriteLine("Key with value : {0} is found in the array.", key.ToString());
            }

            else
            {
                Console.WriteLine("Key with value : {0} is not found in the array,", key.ToString());
            }

            Console.ReadKey();
        }
    }
}
