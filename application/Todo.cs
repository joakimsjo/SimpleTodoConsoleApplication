using System;
using System.IO;
using application;
using Newtonsoft.Json;

namespace application
{
    public class Todo : ITodo
    {
        ITodoList _list;
        private readonly string HelpString = "To add elements to the todo list type:\n"
                                            + "Add <Description of what should be done>\n"
                                            + "Mark element as done:\nDo #<Id of todo element>\n"
                                            + "Print all remaining to-dos:\nPrint";

        public Todo(ITodoList list)
        {
            _list = list;
        }
        public void DoAction(string action)
        {
            string[] splitted = action.Split(" ", 2);

            if ((splitted[0] == "Add" || splitted[0] == "Do") && (splitted.Length != 2 || splitted[1].Length == 0))
            {
                Console.WriteLine("Second argument is missing");
                return;
            }

            switch (splitted[0])
            {
                case "Add":
                    _list.AddElement(splitted[1]);
                    break;
                case "Do":
                    string RemovedHashTag = splitted[1].Replace("#", string.Empty);
                    _list.DoElement(RemovedHashTag);
                    break;
                case "Print":
                    _list.PrintElements();
                    break;
                case "Help":
                    Console.WriteLine(HelpString);
                    break;
                default:
                    Console.WriteLine("Unkown action");
                    break;
            }
        }
    }
}