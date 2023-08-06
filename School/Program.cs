namespace School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte numberStudentsLearnFrench = byte.Parse(Console.ReadLine());
            var studentsLearnFrench = new HashSet<string>();
            for (int i = 0; i < numberStudentsLearnFrench; i++)
                studentsLearnFrench.Add(Console.ReadLine());

            byte numberStudentsLearnGerman = byte.Parse(Console.ReadLine());
            var studentsLearnGerman = new HashSet<string>();
            for (int i = 0; i < numberStudentsLearnGerman; i++)
                studentsLearnGerman.Add(Console.ReadLine());

            var temporarySet = new HashSet<string>();
            foreach (string student in studentsLearnFrench)
                temporarySet.Add(student);

            studentsLearnFrench.ExceptWith(studentsLearnGerman);
            studentsLearnGerman.ExceptWith(temporarySet);

            byte numberStudentsLearnOneLanguage = (byte)
                (studentsLearnFrench.Count + studentsLearnGerman.Count);
            if(numberStudentsLearnOneLanguage == 0)
                Console.WriteLine("NO");
            else
                Console.WriteLine(numberStudentsLearnOneLanguage);
        }
    }
}