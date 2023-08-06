using System.Diagnostics;

namespace BracketSequence
{
    public class Program
    {
        static char curlyBracketOpened = '{';
        static char curlyBracketClosed = '}';

        static char squareBracketOpened = '[';
        static char squareBracketClosed = ']';

        static char roundBracketOpened = '(';
        static char roundBracketClosed = ')';
        static void Main(string[] args)
        {
            string bracketSequence = Console.ReadLine();
            if (bracketSequence != null)
            {
                if (bracketSequence.Length % 2 != 0)
                    ThrowExceptionIfIncorrectSequence(bracketSequence);

                Stack<char> stackBracketSequence = new Stack<char>();
                short balance = 0;
                for (int i = 0; i < bracketSequence.Length; i++)
                {
                    if (i == 0 && IsClosedBracket(bracketSequence[i]))
                        ThrowExceptionIfIncorrectSequence(bracketSequence);

                    if (IsOpenedBracket(bracketSequence[i]))
                    {
                        stackBracketSequence.Push(bracketSequence[i]);
                        balance++;
                        continue;
                    }

                    if (IsBracketSequenceCorrect(stackBracketSequence.Peek(),
                        bracketSequence[i]))
                    {
                        stackBracketSequence.Pop();
                        balance--;
                        continue;
                    }

                    ThrowExceptionIfIncorrectSequence(bracketSequence);
                }
                if (balance == 0)
                    Console.WriteLine("Bracket sequence is correct!");
                else
                    ThrowExceptionIfIncorrectSequence(bracketSequence);
            }
        }
        static bool IsBracketSequenceCorrect(char openedBracket, char closedBracket)
        {
            if (IsBracketSequenceCurly(openedBracket, closedBracket))
                return true;
            if (IsBracketSequenceSquare(openedBracket, closedBracket))
                return true;
            if (IsBracketSequenceRound(openedBracket, closedBracket))
                return true;
            return false;
        }
        static bool IsBracketSequenceCurly(char openedBracket, char closedBracket)
        {
            return openedBracket == curlyBracketOpened &&
                closedBracket == curlyBracketClosed;
        }
        static bool IsBracketSequenceSquare(char openedBracket, char closedBracket)
        {
            return openedBracket == squareBracketOpened &&
                closedBracket == squareBracketClosed;
        }
        static bool IsBracketSequenceRound(char openedBracket, char closedBracket)
        {
            return openedBracket == roundBracketOpened &&
                closedBracket == roundBracketClosed;
        }
        
        static bool IsOpenedBracket(char bracket)
        {
            return bracket == curlyBracketOpened ||
                    bracket == squareBracketOpened ||
                     bracket == roundBracketOpened;
        }
        static bool IsClosedBracket(char bracket) 
        {
            return bracket == curlyBracketClosed ||
                    bracket == squareBracketClosed ||
                     bracket == roundBracketClosed;
        }

        static void ThrowExceptionIfIncorrectSequence(string sequence)
        {
            throw new ArgumentException($"Incorrect sequence \"{sequence}\"!");
        }
    }
}