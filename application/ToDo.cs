using System;
using System.IO;
using application;
using Newtonsoft.Json;

namespace application {

    public class ToDo : IToDo
    {   
        ToDoList _list;

        public ToDo() {
            _list = new ToDoList();
        }
        public void DoAction(string action)
        {
            string[] splitted = action.Split(" ", 2);

            switch(splitted[0]) {
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
                default:
                    Console.WriteLine("Unkown action");
                    break;
            }
        }

        
    }
}