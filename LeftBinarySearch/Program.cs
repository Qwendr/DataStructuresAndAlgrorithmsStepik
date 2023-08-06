using System.Diagnostics;

namespace LeftBinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 5, 5, 5, 5, 5, 7, 8 };
            int number = 5;
            int index = LeftBinarySearch<int>(array, number);
            Console.WriteLine(index);
        }
        static int LeftBinarySearch<T>(T[] array, T number)
            where T : IComparable<T>
        {
            int left = -1;
            int right = array.Length - 1;
            while (left + 1 < right)
            {
                int middle = left + (right - left)/2;
                if (number.CompareTo(array[middle]) == 1)
                    left = middle;
                else
                    right = middle;
            }
            if (number.CompareTo(array[right]) == 0)
                return right;
            return -1;
        }
    }
}