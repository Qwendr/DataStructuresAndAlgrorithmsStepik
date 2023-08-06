using System.ComponentModel;

namespace DynamicArray
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Пример использования
            var array = new DynamicArray<int>(6);

            array.PushBack(3);
            array.PushBack(1);
            array.PushBack(7);
            array.PushBack(10);
            array.PushBack(5);
            array.PushBack(6);


            array.PopBack();
            Console.WriteLine(array.GetArrayStringToPrint());
            Console.WriteLine(array.GetCount);


            array.PopFront();
            Console.WriteLine(array.GetArrayStringToPrint());
            Console.WriteLine(array.GetCount);


            array.RemoveByIndex(1);
            Console.WriteLine(array.GetArrayStringToPrint());
            Console.WriteLine(array.GetCount);

            array.PopBack();
            array.PopBack();
            array.PopBack();
            Console.WriteLine(array.GetCount);
            array.PopBack();
        }
    }
}