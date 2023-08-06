namespace BinaryToIntegerConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countDigits = int.Parse(Console.ReadLine());
            List<int> digits = Console.ReadLine().Split().ToList().ConvertAll(int.Parse);
            int result = 0;
            for(int i = 0; i < digits.Count; i++)
            {
                if (digits[i] == 0)
                    continue;
                result += (int) (digits[i] * Math.Pow(2, digits.Count - i - 1));
            }
            Console.WriteLine(result);
        }
    }
}