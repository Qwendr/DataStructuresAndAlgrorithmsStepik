namespace ReversalSequence
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int number = int.Parse(Console.ReadLine());
            while(number != 0)
            {
                stack.Push(number);
                number = int.Parse(Console.ReadLine());
            }
            foreach (int item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}