using System.ComponentModel.DataAnnotations;

namespace LeftJumpSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 5, 5, 5, 5, 5, 7, 8 };
            int number = 5;
            int index = LeftJumpSearch(array, number); 
            Console.WriteLine(index);
        }
        static int LeftJumpSearch(int[] array, int number)
        {
            if (array[array.Length - 1] < number)
                return -1;

            int B = (int)Math.Sqrt(array.Length);
            int start = 0;
            int end = B - 1;
            while (array[end] < number)
            {
                if (number == array[end])
                    break;
                start += B;
                end += B;
            }
            int index = ReverseLinearSearch(array, number, start, end);
            return index;
        }
        static int ReverseLinearSearch(int[] array, int number, int start, int end)
        {
            if (array[start] == number)
                return start;

            for (int i = end; i >= start; i--)
            {
                if (array[i] < number && array[i + 1] == number)
                    return i + 1;
            }
            return -1;
        }
    }
}