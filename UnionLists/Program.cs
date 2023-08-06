namespace UnionLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countElements = int.Parse(Console.ReadLine());
            List<int> elementsA = Console.ReadLine().Split().ToList().ConvertAll(int.Parse);
            countElements = int.Parse(Console.ReadLine());
            List<int> elementsB = Console.ReadLine().Split().ToList().ConvertAll(int.Parse);
            List<int> resultElements = new List<int>();

            foreach (int element in elementsA)
                resultElements.Add(element);

            foreach (int element in elementsB)
                resultElements.Add(element);

            resultElements.Sort();
            Print(resultElements);
        }
        static void Print<T>(ICollection<T> elements)
        {
            foreach (T element in elements)
                Console.Write(element + " ");
            Console.WriteLine();
        }
    }
}