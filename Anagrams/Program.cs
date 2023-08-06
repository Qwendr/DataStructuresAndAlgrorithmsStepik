namespace Anagrams
{
    public class Program
    {
        static void Main(string[] args)
        {
            string word1 = Console.ReadLine();
            string word2 = Console.ReadLine();

            if(word1.Count() != word2.Count())
                Console.WriteLine("NO");

            Dictionary<char, byte> word1Letter = new Dictionary<char, byte>();
            Dictionary<char, byte> word2Letter = new Dictionary<char, byte>();

            FillDictionaryLetterCount(word1Letter, word1);
            FillDictionaryLetterCount(word2Letter, word2);

            bool isAnagram = true;
            foreach (KeyValuePair<char, byte> pair in word1Letter)
            {
                if(word2Letter.ContainsKey(pair.Key))
                {
                    if (word1Letter[pair.Key] != word2Letter[pair.Key])
                    {
                        isAnagram = false;
                        break;
                    }
                    continue;
                }
                isAnagram = false;
                break;
            }

            if (isAnagram)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
        static void FillDictionaryLetterCount
            (Dictionary<char, byte> dictionary, string word)
        {
            foreach(char c in word)
            {
                if (!dictionary.ContainsKey(c))
                    dictionary[c] = (byte)CountLetter(word, c);
            }
        }

        static int CountLetter(string word, char letter)
        {
            int countLetter = 0;
            foreach (char c in word)
            {
                if (c == letter)
                    countLetter++;
            }
            return countLetter;
        }
    }
}