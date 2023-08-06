namespace Brothers2
{
    public class Program
    {
        static char roundBracketOpened = '(';
        static char roundBracketClosed = ')';
        static void Main(string[] args)
        {
            string bracketSequence = Console.ReadLine();
            if (bracketSequence != null)
            {
                Stack<char> stackBracketSequence = new Stack<char>();
                short balance = 0;
                for (int i = 0; i < bracketSequence.Length; i++)
                {
                    if (IsOpenedBracket(bracketSequence[i]))
                    {
                        stackBracketSequence.Push(bracketSequence[i]);
                        balance++;
                        continue;
                    }
                    // текущая скобка закрытая
                    try
                    {
                        if (IsBracketSequenceCorrect(stackBracketSequence.Peek(),
                        bracketSequence[i]))
                        {
                            stackBracketSequence.Pop();
                            balance--;
                            continue;
                        }
                    } 
                    catch (InvalidOperationException)
                    {
                        if (IsClosedBracket(bracketSequence[i]))
                        {
                            stackBracketSequence.Push(bracketSequence[i]);
                            balance++;
                            continue;
                        }
                    }
                }
                Console.WriteLine(balance);
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