using System;
using System.Collections.Generic;

namespace application
{
    public class Todo : ITodo
    {
        public ITodoList _list;
        private readonly string HelpString = "To add elements to the todo list type:\n"
                                            + "Add <Description of what should be done>\n"
                                            + "Mark element as done:\nDo #<Id of todo element>\n"
                                            + "Print all remaining to-dos:\nPrint";
        private readonly string InfoFormatString = "INFO: {0}";
        private static List<string> ActionVerbs = new List<string>(new string[] {"ADD", "DO"});

        public Todo(ITodoList list)
        {
            _list = list;
        }
        
        public void DoAction(string action)
        {
            string[] args = action.Split(" ", 2);

            string Verb = args[0].ToUpper();
            
            if (ActionVerbs.Contains(Verb) && (args.Length < 2 || args[1].Trim().Length < 1)) 
            {
                Console.WriteLine(string.Format(InfoFormatString, $"{Verb} is missing second argument."));
                return;
            }

            switch (Verb)
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
                default:
                    Console.WriteLine("Unkown action. Type 'Help' for available actions.");
                    break;
            }
        }
    }
}