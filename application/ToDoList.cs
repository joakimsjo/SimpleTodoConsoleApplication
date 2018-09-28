using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace application {

    public class ToDoList : IToDoList
    {
        List<ToDoElement> _elements;

        public ToDoList() {
            if(File.Exists("data.json")) {
                Load();
            } else {
                _elements = new List<ToDoElement>();
            }
        }
        public void AddElement(string description)
        {
            int id = _elements.Count;
            ToDoElement newTodo = new ToDoElement(id, description);
            _elements.Add(newTodo);
            Save();
            Console.WriteLine(newTodo);
        }

        public void DoElement(string s)
        {
            int id = Int32.Parse(s);

            if(id > _elements.Count) {
                return;
            }

            ToDoElement elementToComplete = _elements[id];

            if(elementToComplete.IsDone()) {
                return;
            }
            elementToComplete.MarkAsDone();
            Console.WriteLine("Completed {0}", elementToComplete);
            Save();
        }

        public void PrintElements()
        {
            foreach(ToDoElement element in _elements) {
                Console.WriteLine(element);
            }
        }
        public void Load()
        {
            using (StreamReader file = new StreamReader("data.json")) {
                string r = file.ReadToEnd();
                _elements = JsonConvert.DeserializeObject<List<ToDoElement>>(r);
            }
        }

        public void Save()
        {
            using (StreamWriter file = new StreamWriter("data.json")) {
                string data = JsonConvert.SerializeObject(_elements);
                file.Write(data);
            }
        }
    }
}