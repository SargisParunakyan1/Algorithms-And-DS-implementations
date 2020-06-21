
namespace Buble_Sort
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class BubleSorting<T>  where T: IComparable<T>
    {
        public static  void Sort(T[] unsorted)
        {
            bool swapped;

            do
            {

                swapped = false;
                
                for (int i = 1; i < unsorted.Length; i++) 
                {
                    if (unsorted[i-1].CompareTo(unsorted[i]) > 0) 
                    {
                        Swap(unsorted, i - 1, i);
                        swapped = true;
                    }
                }

            }while (swapped != false);
        }

        private static void Swap(T[] target, int left, int right)
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

                BubleSorting<int>.Sort(integers);
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