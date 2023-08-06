namespace PostfixForm
{
    public class Program
    {
        static Stack<int> numbersStack = new Stack<int>();
        static void Main(string[] args)
        {
            string[] sequence = Console.ReadLine().Split();
            for (int i = 0; i < sequence.Length; i++) 
            {
                try
                {
                    int number = int.Parse(sequence[i]);
                    numbersStack.Push(number);
                }
                catch(FormatException)
                {
                    int operand2 = numbersStack.Pop();
                    int operand1 = numbersStack.Pop();
                    int result = DoOperation(sequence[i][0], operand1, operand2);
                    numbersStack.Push(result);
                }
            }
            Console.WriteLine(numbersStack.Pop());
        }
        static int DoOperation(char operation, int operand1, int operand2)
        {
            switch(operation)
            {
                case '+':
                    return Sum(operand1, operand2);
                case '-':
                    return Subtraction(operand1, operand2);
                case '*':
                    return Multiplication(operand1, operand2);
                case '/':
                    return Division(operand1, operand2);
                case '%':
                    return RemainderDivision(operand1, operand2);
            }
            throw new ArgumentException($"No such operation {operation}!");
        }
        static int Sum(int operand1, int operand2) 
            => operand1 + operand2;
        static int Subtraction(int operand1, int operand2)
            => operand1 - operand2;
        static int Multiplication(int operand1, int operand2)
            => operand1 * operand2;
        static int Division(int operand1, int operand2)
            => operand1 / operand2;
        static int RemainderDivision(int operand1, int operand2)
            => operand1 % operand2;

    }
}