namespace NumberOfEachLetter
{
    public class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Dictionary<char, int> countLetter = new Dictionary<char, int>();

            foreach(char letter in word)
            {
                if(!countLetter.ContainsKey(letter))
                    countLetter[letter] = CountLetter(word, letter);
            }

            foreach(KeyValuePair<char, int> pair in countLetter)
                Console.WriteLine($"{pair.Key} {pair.Value}");
        }
        static int CountLetter(string word, char letter)
        {
            int countLetter = 0;
            foreach(char c in word) 
            {
                if(c == letter)
                    countLetter++;
            }
            return countLetter;
        }
    }
}