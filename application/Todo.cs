using System;
using System.Collections.Generic;

namespace Application
{
    public class Todo : ITodo
    {
        public ITodoList _list;
        private readonly string HelpString = "To add elements to the todo list type:\n"
                                            + "Add <Description of what should be done>\n"
                                            + "To mark element as done type:\nDo #<Id of todo element>\n"
                                            + "Print all remaining to-dos type:\nPrint\n"
                                            + "To exit the application type:\nQuit";
        private readonly string InfoFormatString = "INFO: {0}";
        private static List<string> ActionVerbs = new List<string>(new string[] {"ADD", "DO"});

        public Todo(ITodoList list)
        {
            _list = list;
        }
        
        public void DoAction(string action)
        {
            string[] args = action.Split(" ", 2);

            string verb = args[0].ToUpper();
            
            if (ActionVerbs.Contains(verb) && (args.Length < 2 || args[1].Trim().Length < 1)) 
            {
                Console.WriteLine(string.Format(InfoFormatString, $"{verb} is missing second argument."));
                return;
            }

            switch (verb)
            {
                case "ADD":
                    _list.AddElement(args[1]);
                    break;
                case "DO":
                    string RemovedHashTag = args[1].Replace("#", string.Empty);
                    _list.DoElement(RemovedHashTag);
                    break;
                case "PRINT":
                    _list.PrintElements();
                    break;
                case "HELP":
                    Console.WriteLine(HelpString);
                    break;
                case "QUIT":
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Unkown action. Type 'Help' for available actions.");
                    break;
            }
        }
    }
}