namespace RightBinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 5, 5, 5, 5, 5, 7, 8 };
            int number = 5;
            int index = RightBinarySearch<int>(array, number);
            Console.WriteLine(index);
        }
        static int RightBinarySearch<T>(T[] array, T number)
            where T : IComparable<T>
        {
            int left = -1;
            int right = array.Length - 1;
            while (left + 1 < right) 
            {
                int middle = left + (right - left)/2;
                if (number.CompareTo(array[middle]) == -1)
                    right = middle;
                else
                    left = middle;
            }
            if (number.CompareTo(array[left]) == 0)
                return left;
            return -1;
        }
    }
}