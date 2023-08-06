namespace StackOnList
{
    public class Program
    {
        static void Main(string[] args)
        {
            StackOnList<int> stack = new StackOnList<int>();
            stack.Push(3);
            stack.Push(4);
            stack.Push(6);
            Console.WriteLine(stack.Print());

            stack.Clear();
            Console.WriteLine(stack.IsEmpty);
            Console.WriteLine(stack.Print());

        }
    }
}