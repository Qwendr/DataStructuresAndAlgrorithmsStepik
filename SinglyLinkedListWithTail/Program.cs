namespace SinglyLinkedListWithTail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new SinglyLinkedListWithTail<int>();
            list.PushBack(6);
            list.PushBack(7);
            list.PushFront(4);
            list.PushFront(3);
            Console.WriteLine(list.GetListStringToPrint());


            list.RemoveFirst();
            Console.WriteLine(list.GetListStringToPrint());
            list.RemoveLast();
            Console.WriteLine(list.GetListStringToPrint());

            Console.WriteLine(list.Count);

            list.PushBack(10);
            Console.WriteLine(list.GetListStringToPrint());
            list.RemoveNode(list.Find(6));
            Console.WriteLine(list.GetListStringToPrint());
            list.RemoveNode(list.Find(4));
            Console.WriteLine(list.GetListStringToPrint());
            list.RemoveNode(list.Find(10));
            Console.WriteLine(list.GetListStringToPrint());
        }
    }
}