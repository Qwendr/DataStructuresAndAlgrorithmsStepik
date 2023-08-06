using System.Data;

namespace SearchAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 2, 3, 4, 5, };
            int index = LinearSearch<int>(array, 1);
            Console.WriteLine(index);
        }
        static int LinearSearch<T>(T[] array, T number) where T: IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
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