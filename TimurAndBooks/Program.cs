namespace TimurAndBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte numberBooksTimurHas = byte.Parse(Console.ReadLine());
            var booksTimurHas = new HashSet<string>();
            for (int i = 0; i < numberBooksTimurHas; i++)
                booksTimurHas.Add(Console.ReadLine());

            byte numberBooksSummerLiterature = byte.Parse(Console.ReadLine());
            var booksSummerLiterature = new HashSet<string>();
            for (int i = 0; i < numberBooksSummerLiterature; i++)
                booksSummerLiterature.Add(Console.ReadLine());

            foreach (string book in booksSummerLiterature)
            {
                if (booksTimurHas.Contains(book))
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}