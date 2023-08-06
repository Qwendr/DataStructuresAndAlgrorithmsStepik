namespace CountingSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -4, 2, 2, 8, 3, 3, 1 };
            CountingSortAlgorithm(arr);
            PrikntArray(arr);
        }
        public static void CountingSortAlgorithm(int[] array)
        {
            // Находим максимальное и минимальное значения в массиве
            int maxValue = array[0];
            int minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                    maxValue = array[i];
                if (array[i] < minValue)
                    minValue = array[i];
            }

            // Вычисляем диапазон значений
            int range = maxValue - minValue + 1;

            // Создаем массив для подсчета частоты вхождения каждого значения
            int[] countArray = new int[range];

            // Заполняем countArray
            for (int i = 0; i < array.Length; i++)
            {
                countArray[array[i] - minValue]++;
            }

            // Перезаписываем исходный массив в отсортированном порядке
            int arrayIndex = 0;
            for (int i = 0; i < range; i++)
            {
                while (countArray[i] > 0)
                {
                    array[arrayIndex] = i + minValue;
                    arrayIndex++;
                    countArray[i]--;
                }
            }
        }

        static void PrikntArray(int[] array)
        {
            foreach (int element in array)
                Console.Write(element + " ");
        }
    }
}