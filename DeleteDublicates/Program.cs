using System.Xml.Linq;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countElements = int.Parse(Console.ReadLine());
            List<int> elements = Console.ReadLine().Split().ToList().ConvertAll(int.Parse);
            for (int i = 0; i < elements.Count; i++)
            {
                for (int j = i + 1; j < elements.Count; j++)
                {
                    if (elements[i] == elements[j])
                        elements.Remove(elements[j]);
                }
            }
            Print(elements);
        }
        static void Print<T>(ICollection<T> elements)
        {
            foreach (T element in elements)
                Console.Write(element + " ");
            Console.WriteLine();
        }
    }
}