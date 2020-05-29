
namespace Buble_Sort
{
    using System;

    public class BubleSorting
    {
        public static void Sort(int[] unsorted)
        {
            if (unsorted == null)
            {
                throw new ArgumentException("Array could not be sorted. It is null.");
            }

            if (unsorted.Length == 1)
            {
                return;
            }


            for (int j = 0; j < unsorted.Length; j++)
            {
                for (int i = j + 1; i < unsorted.Length; i++)
                {
                    if (unsorted[j] > unsorted[i])
                    {
                        Swap(unsorted, j, i);
                    }
                }
            }
        }

        private static void Swap(int[] target, int left, int right)
        {
            var temp = target[left];
            target[left] = target[right];
            target[right] = temp;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Buble sort programm.");
                Console.WriteLine();

                Console.WriteLine("Please input the unsorted array, and press ENTER.");
                Console.WriteLine();

                int[] integers = new int[10];
                for (int i = 0; i < integers.Length; i++)
                {
                    integers[i] = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Array after sorting like this.");
                Console.WriteLine();

                BubleSorting.Sort(integers);
                foreach(int i in integers)
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine();
                Console.ReadKey();
            }

            catch(Exception ex)
            {
                Console.WriteLine("Exception has happened.Exception message is : {0}", ex.Message);
            }
        }
    }
}