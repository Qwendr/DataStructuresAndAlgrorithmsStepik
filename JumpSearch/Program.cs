using System.ComponentModel.DataAnnotations;

namespace JumpSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            int number = 4;
            int index = JumpSearch(array, number);
            Console.WriteLine(index);
        }
        static int JumpSearch(int[] array, int number)
        {
            if (number > array[array.Length - 1])
            {
                return -1;
            }

            int B = (int)Math.Sqrt(array.Length);
            int start = 0;
            int end = B - 1;
            while (array[end] < number) 
            {
                if (end == array.Length - 1)
                    break;

                start += B;
                end = Math.Min(array.Length - 1, end + B);
            }
            int index = ReverseLinearSearch(array, number, start, end);
            return index;
        }
        static int ReverseLinearSearch<T>(T[] array, T number, int start, int end) 
            where T : IComparable<T>
        {
            for (int i = end; i >= start; i--)
            {
                if (array[i].CompareTo(number) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}