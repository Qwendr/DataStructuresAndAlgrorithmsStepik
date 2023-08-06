namespace SimpleHashTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new SimpleHashTable();

            hashTable.Add(1, 2);
            hashTable.Add(2, 3);
            hashTable.Add(3, 4);
            hashTable.Add(5, 6);

            Console.WriteLine(hashTable.Search(3));
        }
    }
}