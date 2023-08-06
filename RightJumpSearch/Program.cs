using System.ComponentModel.DataAnnotations;

namespace RightJumpSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 5, 5, 5, 5, 5, 5, 5, 7, 8 };
            int number = 5;
            int index = RightJumpSearch(array, number);
            Console.WriteLine(index);
        }
        // ! Для отсортированного списка
        static int RightJumpSearch(int[] array, int number)
        {
            // Выход, если искомое число больше последнего
            if (number > array[array.Length - 1])
            {
                return -1;
            }

            int B = (int)Math.Sqrt(array.Length);
            int start = 0;
            int end = B - 1;
            // Пока последний элемент отрезка не равен последнему в массиве
            while (end != array.Length - 1)
            {
                /* Если последнее число отрезка не равно искомому числу
                и число после него тоже не равно искомому числу */
                if (!(array[end] == number && array[end + 1] == number))
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