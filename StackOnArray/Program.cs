namespace StackOnArray
{
    public class Program
    {
        static void Main(string[] args)
        {
            StackOnArray<int> stack = new StackOnArray<int>();
            
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