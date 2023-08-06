namespace DoubleCircularLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new DoubleCircularLinkedList<int>();

            list.PushBack(6);
            list.PushBack(7);
            list.PushFront(4);
            list.PushFront(3);
            Console.WriteLine(list.GetListStringToPrint(true));

            list.RemoveFirst();
            Console.WriteLine(list.GetListStringToPrint(true));

            list.RemoveLast();
            Console.WriteLine(list.GetListStringToPrint(true));

            Console.WriteLine(list.Count);

            list.PushBack(10);
            Console.WriteLine(list.GetListStringToPrint(true));

            var node = list.Find(6);
            list.RemoveNode(node);
            Console.WriteLine(list.GetListStringToPrint(true));

            node = list.Find(4);
            list.RemoveNode(node);
            Console.WriteLine(list.GetListStringToPrint(true));

            node = list.Find(10);
            list.RemoveNode(node);
            Console.WriteLine(list.GetListStringToPrint(true));
        }
    }
}