namespace SimpleInsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 1, 23, 542, 2, 109, 0, -89, -3 };
            SimpleInsertionSort(array);
            Print(array);
        }
        // Эффективен, когда массив частично отсортирован
        // И когда количество элементов массива меньше 10
        static void SimpleInsertionSort(int[] array)
        {
            // Буфер, где будет хранится элемент вставки
            int buffer;
            for (int i = 1; i < array.Length; i++) 
            {
                buffer = array[i];
                // Индекс, в который после цикла вставить буфер
                int bufferIndex = i;
                // Пока не первый элемент массива и индекс буфера больше буфера
                while(bufferIndex != 0 && array[bufferIndex - 1] > buffer)
                {
                    // Число перед буфером больше буфера, значит сдвигаем это число
                    // на один индекс вперед, а индекс буфера становится на один меньше,
                    // тот индекс, на котором был больший элемент
                    array[bufferIndex] = array[bufferIndex - 1];
                    bufferIndex--;
                }
                // Мы нашли элемент перед буфером,
                // который меньше буфера - array[bufferIndex - 1] > buffer
                // Или буфер самый маленький и ставим его на первый индекс
                array[bufferIndex] = buffer;
            }
        }

        static void Print(int[] array)
        {
            foreach (int element in array)
                Console.Write(element + " ");
        }
    }
}