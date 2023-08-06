namespace NearBiggestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            List<int> elements = Console.ReadLine().Split().ToList().ConvertAll(int.Parse);
            List<int> resultElements = new List<int>();
            for(int i = 0; i < elements.Count; i++)
            {
                int nextNumberBiggerThenCurrent = FindNextBiggerElementThen(elements, i);
                resultElements.Add(nextNumberBiggerThenCurrent);
            }
            Print(resultElements);
        }
        static void Print<T>(ICollection<T> elements)
        {
            foreach (T element in elements)
                Console.Write(element + " ");
            Console.WriteLine();
        }

        static int FindNextBiggerElementThen(List<int> elements, int numberIndex)
        {
            int maxNumber = 0;
            for(int i = numberIndex + 1; i < elements.Count; i++)
            {
                if (elements[numberIndex] < elements[i])
                    return elements[i];
            }
            return maxNumber;
        }

    }
}