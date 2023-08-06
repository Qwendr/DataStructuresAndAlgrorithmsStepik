﻿using System.Security.Cryptography;

namespace Stack1
{
    public class Program
    {
        // Гарантируется, что команды pop и peek корректны
        static string pushCommand = "push ";
        static Stack<int> stack = new Stack<int>();
        static List<string> commandsHistory = new List<string>();
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            if (command == null)
                return;
            while(command != "exit")
            {
                if(IsPushCommand(command))
                    PushCommand(command);

                switch (command.ToLower()) 
                {
                    case "pop":
                        PopCommand();
                        break;
                    case "peek":
                        PeekCommand();
                        break;
                    case "count":
                        CountCommand();
                        break;
                    case "clear":
                        ClearCommad();
                        break;
                }
                command = Console.ReadLine();
            }
            commandsHistory.Add("bye");
            foreach (string commandDone in commandsHistory)
            {
                Console.WriteLine(commandDone);
            }
        }
        static void PushCommand(string command)
        {
            int number = GetNumberFromPushCommand(command);
            stack.Push(number);
            commandsHistory.Add("ok");
        }
        static void PopCommand()
        {
            commandsHistory.Add(stack.Pop().ToString());
        }
        static void PeekCommand()
        {
            commandsHistory.Add(stack.Peek().ToString());
        }
        static void CountCommand()
        {
            commandsHistory.Add(stack.Count().ToString());
        }
        static void ClearCommad()
        {
            stack.Clear();
            commandsHistory.Add("ok");
        }

        static bool IsPushCommand(string command)
        {
            for (int i = 0; i < pushCommand.Length; i++) 
            {
                try
                {
                    if (pushCommand[i] == command[i])
                        continue;
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        static int GetNumberFromPushCommand(string command)
        {
            string numberResult = String.Empty;
            for (int i = pushCommand.Length; i < command.Length; i++) 
            {
                numberResult += command[i];
            }
            return int.Parse(numberResult);
        }
    }
}