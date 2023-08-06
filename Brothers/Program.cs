namespace Brothers
{
    public class Program
    {
        static char roundBracketOpened = '(';
        static char roundBracketClosed = ')';
        static void Main(string[] args)
        {
            string bracketSequence = Console.ReadLine();
            if (bracketSequence != null ) 
            {
                if (bracketSequence.Length % 2 != 0)
                {
                    Console.WriteLine("NO");
                    return;
                }

                Stack<char> stackBracketSequence = new Stack<char>();
                short balance = 0;
                for (int i = 0; i < bracketSequence.Length; i++)
                {
                    if (i == 0 && IsClosedBracket(bracketSequence[i]))
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    if (IsOpenedBracket(bracketSequence[i]))
                    {
                        stackBracketSequence.Push(bracketSequence[i]);
                        balance++;
                        continue;
                    }
                    // текущая скобка закрытая
                    if (IsBracketSequenceCorrect(stackBracketSequence.Peek(),
                        bracketSequence[i]))
                    {
                        stackBracketSequence.Pop();
                        balance--;
                        continue;
                    }
                    Console.WriteLine("NO");
                    return;
                }
                if(balance == 0)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
        static bool IsBracketSequenceCorrect(char openedBracket, char closedBracket)
        {
            return IsBracketSequenceRound(openedBracket, closedBracket);
        }
        static bool IsBracketSequenceRound(char openedBracket, char closedBracket)
        {
            return openedBracket == roundBracketOpened &&
                closedBracket == roundBracketClosed;
        }

        static bool IsOpenedBracket(char bracket)
        {
            return bracket == roundBracketOpened;
        }
        static bool IsClosedBracket(char bracket)
        {
            return bracket == roundBracketClosed;
        }
    }
}