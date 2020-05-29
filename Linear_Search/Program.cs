
namespace Linear_Search
{
    using System;

    public class Program
    {
        public class LinearSearching
        {
            public static bool Search(int[] ints, int key)
            {
                if (ints == null)
                {
                    throw new ArgumentException("Array is null.");
                }

                if(ints.Length == 1)
                {
                    if(ints[0] == key)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }

                for (int i = 0; i < ints.Length; i++)
                {
                    if(ints[i] == key)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
