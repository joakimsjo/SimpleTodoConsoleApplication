using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace application
{

    public class TodoList : ITodoList
    {
        List<ITodoElement> _elements;

        public TodoList()
        {
            if (File.Exists("data.json"))
            {
                Load();
            }
            else
            {
                _elements = new List<ITodoElement>();
            }
        }
        public void AddElement(string description)
        {
            int id = _elements.Count;
            ITodoElement newTodo = new TodoElement(id, description);
            _elements.Add(newTodo);
            Save();
            Console.WriteLine(newTodo);
        }

        public void DoElement(string s)
        {
            int id = Int32.Parse(s);

            if (id > _elements.Count)
            {
                return;
            }

            ITodoElement elementToComplete = _elements[id];

            if (elementToComplete.IsDone())
            {
                return;
            }
            elementToComplete.MarkAsDone();
            Console.WriteLine("Completed {0}", elementToComplete);
            Save();
        }

        public void PrintElements()
        {
            foreach (ITodoElement element in _elements)
            {
                Console.WriteLine(element);
            }
        }
        public void Load()
        {
            using (StreamReader file = new StreamReader("data.json"))
            {
                string r = file.ReadToEnd();
                JsonConverter[] converters = {new TodoElementConverter()};

                _elements = JsonConvert.DeserializeObject<List<ITodoElement>>(r, converters: converters);
                
            }
        }

        public void Save()
        {
            using (StreamWriter file = new StreamWriter("data.json"))
            {
                var settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;

                string data = JsonConvert.SerializeObject(_elements, formatting: Formatting.Indented, settings: settings);
                file.Write(data);
            }
        }
    }
}