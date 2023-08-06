namespace SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 1, 23, 542, 2, 109, 0, -89, -3 };
            SelectionSort(array);
            Print(array);
        }
        // Преимущество – минимум обменов
        static void SelectionSort(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int maxElementIndex = i;
                for (int j = 0; j < i; j++) 
                {
                    if (array[j] >= array[maxElementIndex])
                        maxElementIndex = j;
                }
                // Если нашли в подмассиве число большее, чем i, то меняет местами
                /* Если не нашли, значит i - самое большое в подмассиве и оно стоит 
                на своем месте, ничего менять не нужно */
                if(maxElementIndex != i)
                    Swap(array, i, maxElementIndex);
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