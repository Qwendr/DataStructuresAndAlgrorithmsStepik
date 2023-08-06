namespace Queue
{
    public class Program
    {
        static Queue<int> queue = new Queue<int>();
        static List<string> operationsHistory = new List<string>();

        static string enqueueOperation = "enqueue ";

        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            while(operation != "exit")
            {
                DoOperation(operation);
                operation = Console.ReadLine();
            }
            ExitOperation();
            PrintOperationsHistory();
        }
        static void DoOperation(string operation) 
        {
            try 
            {
                EnqueueOperation(operation);
            }
            catch(FormatException) 
            {
                switch(operation) 
                {
                    case "dequeue":
                        DequeueOperation();
                        break;
                    case "peek":
                        PeekOperation();
                        break;
                    case "count":
                        CountOperation();
                        break;
                    case "clear":
                        ClearOperation();
                        break;
                }
            }
        }
        static int GetNumberFromEnqueueString(string operation)
        {
            string number = String.Empty;
            for (int i = enqueueOperation.Length; i < operation.Length; i++)
            {
                number += operation[i];
            }
            return int.Parse(number);
        }
        static void EnqueueOperation(string operation)
        {
            int number = GetNumberFromEnqueueString(operation);
            queue.Enqueue(number);
            operationsHistory.Add("ok");
        }
        static void DequeueOperation()
        {
            operationsHistory.Add(queue.Dequeue().ToString());
        }
        static void PeekOperation()
        {
            operationsHistory.Add(queue.Peek().ToString());
        }
        static void CountOperation()
        {
            operationsHistory.Add(queue.Count.ToString());
        }
        static void ClearOperation()
        {
            queue.Clear();
            operationsHistory.Add("ok");
        }
        static void ExitOperation()
        {
            operationsHistory.Add("bye");
        }

        static void PrintOperationsHistory()
        {
            foreach (string operation in operationsHistory)
            {
                Console.WriteLine(operation);
            }
        }
    }
}