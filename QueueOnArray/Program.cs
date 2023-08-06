namespace QueueOnArray
{
    public class Program
    {
        static void Main(string[] args)
        {
            QueueOnArray<int> queue = new QueueOnArray<int>();
            queue.Push(3);
            queue.Push(4);
            queue.Push(6);
            Console.WriteLine(queue.Print());

            queue.Clear();
            Console.WriteLine(queue.IsEmpty);
            Console.WriteLine(queue.Print());
        }
    }
}