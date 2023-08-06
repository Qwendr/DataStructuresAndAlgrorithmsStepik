using System.Diagnostics;

namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 1,23, 542, 2, 109, 0, -89, -3 };
            BubbleSort(array);
            Print(array);
        }

        // Преимущество - легок в реализации
        static void BubbleSort(int[] array) 
        {
            for(int i = array.Length - 1; i > 0; i--)
            {
                bool isSwapped = false;
                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                        isSwapped = true;
                    }
                }
                if (!isSwapped)
                    return;
            }
        }

        static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        static void Print(int[] array)
        {
            foreach (int element in array)
                Console.Write(element + " ");
        }
    }
}