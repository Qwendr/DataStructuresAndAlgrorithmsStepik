namespace SetOnArray
{
    public class Program
    {
        static void Main(string[] args)
        {
            var set1 = new SetOnArray<int>();
            set1.Add(3);
            set1.Add(4);
            set1.Add(6);
            Console.WriteLine(set1.Print());

            var set2 = new SetOnArray<int>();
            set2.Add(3);
            set2.Add(2);
            set2.Add(4);
            set2.Add(10);
            Console.WriteLine(set2.Print());
            Console.WriteLine(set1.IsSubsetOf(set2));
        }
    }
}