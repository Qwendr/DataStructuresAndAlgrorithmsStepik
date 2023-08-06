namespace RadixSort
{
    internal class Program
    {   // Эффективен, когда сортируется небольшое количество чисел,
        // значения которых сколько угодно большие
        public static void Main()
        {
            int[] array = { 170, 45, 75, 90, 802, 24, 2, 66 };
            Console.WriteLine("Исходный массив: ");
            PrintArray(array);

            RadixSort(array);
            Console.WriteLine("\nОтсортированный массив: ");
            PrintArray(array);
        }

        public static void RadixSort(int[] array)
        {
            int maxValue = array.Max();
            int radix = 1;

            while (maxValue / radix > 0)
            {
                // Создаем массив счетчиков для каждой цифры.
                int[] counters = new int[10];

                // Считаем количество вхождений каждой цифры в исходном массиве.
                foreach (int value in array)
                {
                    counters[value / radix % 10]++;
                }

                // Суммируем счетчики для каждой цифры, чтобы получить новые индексы.
                for (int i = 1; i < 10; i++)
                {
                    counters[i] += counters[i - 1];
                }

                // Перемещаем элементы из исходного массива в новый массив, отсортированный по текущей цифре.
                int[] sortedArray = new int[array.Length];
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    sortedArray[--counters[array[i] / radix % 10]] = array[i];
                }

                // Заменяем исходный массив отсортированным массивом.
                array = sortedArray;

                // Увеличиваем порядок сортировки в 10 раз, чтобы перейти к следующей цифре.
                radix *= 10;
            }
        }


        public static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

}
}