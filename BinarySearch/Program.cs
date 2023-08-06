namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            int number = 4;
            int index = BinarySearch<int>(array, number);
            Console.WriteLine(index);
        }
        static int BinarySearch<T>(T[] array, T number) where T : IComparable<T>
        {
            int left = 0;
            int right = array.Length - 1;
            for (int i = 0; i < array.Length; i++) 
            {
                int middle = left + (right - left)/2;
                if (number.CompareTo(array[middle]) == 0)
                {
                    return middle;
                }

                if (number.CompareTo(array[middle]) == 1) 
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            return -1;
        }
    }
}