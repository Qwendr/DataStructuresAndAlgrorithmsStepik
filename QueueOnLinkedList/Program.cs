namespace QueueOnLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new QueueOnLinkedList<int>();
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