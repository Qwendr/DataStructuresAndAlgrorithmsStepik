namespace SwitchingBetweenWindows
{
    internal class Program
    {
        static string tabSubstring = "Tab";
        static string programSubstring = "Run ";

        static List<string> operations
            = new List<string>();
        static LinkedList<string> openedPrograms
            = new LinkedList<string>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            ReadLineAndAddOperation(n);

            foreach (string operation in operations)
            {
                int countTabs;
                try
                {
                    countTabs = int.Parse(operation);

                    if (openedPrograms.First == null)
                        continue;

                    LinkedListNode<string> current = openedPrograms.First;
                    // Найти последний элемент
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    LinkedListNode<string> openedProgram = current;
                    for (int i = 0; i != countTabs; i++)
                    {
                        if (current.Previous != openedPrograms.First.Previous
                            && openedProgram.Previous != null)
                            openedProgram = openedProgram.Previous;
                    }
                    var newNode = new LinkedListNode<string>(openedProgram.Value);
                    openedPrograms.AddLast(newNode);
                }
                catch (FormatException)
                {
                    openedPrograms.AddLast(operation);
                }
            }

            foreach (string openedProgram in openedPrograms)
            {
                Console.WriteLine(openedProgram);
            }
        }
        static void AddOperationToList
            (string stringToCheck)
        {
            if (IsStringStartsWithSubstring
                    (stringToCheck, programSubstring))
            {
                operations.Add(CreateStringWithoutFirstSubstring
                    (stringToCheck, programSubstring));
            }
            else
            {
                int count = CountNumberSubstring
                    (stringToCheck, tabSubstring);
                if (count != 0)
                    operations.Add(count.ToString());
            }
        }
        static void ReadLineAndAddOperation(int numberOfEnters)
        {
            for (int i = 0; i < numberOfEnters; i++)
            {
                string stringWithProgramNameOrAlt = Console.ReadLine();
                AddOperationToList(stringWithProgramNameOrAlt);
            }
        }

        // According to Program part
        static bool IsStringStartsWithSubstring
            (string stringToCheck, string substring)
        {
            for (int i = 0; i < substring.Length; i++)
            {
                if (stringToCheck[i] == substring[i])
                    continue;
                return false;
            }
            return true;
        }
        static string CreateStringWithoutFirstSubstring
            (string stringToChange, string substring)
        {
            string result = String.Empty;
            for (int i = substring.Length; i < stringToChange.Length; i++)
            {
                result += stringToChange[i];
            }
            return result;
        }

        // According to Tab part
        static int CountNumberSubstring
            (string stringToCheck, string substring)
        {
            int count = 0;
            int index = stringToCheck.IndexOf(substring);
            string stringWithSubstringRemained = stringToCheck;
            while (stringWithSubstringRemained.Contains(substring))
            {
                stringWithSubstringRemained = CreateStringStartFrom
                    (stringWithSubstringRemained, substring, index);
                count++;
                index = stringWithSubstringRemained.IndexOf(substring);
            }
            return count;
        }
        static string CreateStringStartFrom
            (string stringToCheck, string substring, int index)
        {
            string result = String.Empty;
            for (int i = index + substring.Length; i < stringToCheck.Length; i++)
            {
                result += stringToCheck[i];
            }
            return result;
        }
    }
}