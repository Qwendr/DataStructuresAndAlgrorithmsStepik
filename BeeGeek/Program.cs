namespace BeeGeek
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] countNumbers = Console.ReadLine()
                .Split().ToList().ConvertAll(int.Parse).ToArray();

            int interval = countNumbers[1] - 1; // k - 1
            int[] numbersSequence = Console.ReadLine()
                .Split().ToList().ConvertAll(int.Parse).ToArray();

            int maxNumber = numbersSequence.Min();
            int result = 0;
            for (int j = 0; j < numbersSequence.Length; j++)
            {
                result += numbersSequence[j];
                for(int k = j + interval + 1; k < numbersSequence.Length; k++)
                {
                    result += numbersSequence[k];
                    if (result > maxNumber)
                    {
                        maxNumber = result;
                    }
                    result = numbersSequence[j];
                    continue;
                }
                if (result > maxNumber)
                {
                    maxNumber = result;
                }
                result = 0;
            }
            Console.WriteLine(maxNumber);

        }
    }
}