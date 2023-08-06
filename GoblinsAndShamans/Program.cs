namespace GoblinsAndShamans
{
    public class Program
    {
        static Queue<int> queue = new Queue<int>();
        static Queue<int> entersHistory = new Queue<int>();

        static void Main(string[] args)
        {
            int countInputs = int.Parse(Console.ReadLine());

            while (countInputs > 0) 
            {
                string input = Console.ReadLine();
                if (input == "-")
                {
                    entersHistory.Enqueue(queue.Dequeue());
                }
                else
                {
                    int number = GetNumberFromInput(input);
                    if (input[0] == '+')
                        queue.Enqueue(number);
                    else
                        queue.EnqueueMiddle(number);
                }
                countInputs--;
            }
            int count = entersHistory.Count;
            for(int i = 0; i < count; i++) 
            {
                Console.WriteLine(entersHistory.Dequeue());
            }
        }
        static int GetNumberFromInput(string input)
        {
            string result = String.Empty;
            for(int i = 2; i < input.Length; i++)
            {
                result += input[i];
            }
            return int.Parse(result);
        }
    }
}