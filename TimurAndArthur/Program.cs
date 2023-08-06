namespace TimurAndArthur
{
    internal class Program
    {
        static HashSet<string> cities = new HashSet<string>();

        static void Main(string[] args)
        {
            byte numberOfCities = byte.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCities; i++) 
            {
                cities.Add(Console.ReadLine());
            }
            if(cities.Add(Console.ReadLine()))
                Console.WriteLine("OK");
            else
                Console.WriteLine("EXIST");
        }
    }
}