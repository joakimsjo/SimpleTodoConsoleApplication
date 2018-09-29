using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Application
{
    public class TodoList : ITodoList
    {
        private readonly string ErrorFormatString = "ERROR: {0}";
        private readonly string InfoFormatString = "INFO: {0}";

        public List<ITodoElement> elements;

        public TodoList()
        {
            if (File.Exists("data.json"))
            {
                Load();
            }
            else
            {
                elements = new List<ITodoElement>();
            }
        }

        public void AddElement(string description)
        {
            int id = elements.Count + 1;
            ITodoElement newTodo = new TodoElement(id, description);

            elements.Add(newTodo);

            Save();

            Console.WriteLine(newTodo);
        }

        public void DoElement(string s)
        {
            int id;

            try 
            {
                id = Int32.Parse(s);
            }
            catch (FormatException)
            {
                Console.WriteLine(string.Format(InfoFormatString, $"{s} is not a valid todo ID. Id must be an integer."));
                return;
            }   

            if (id > elements.Count)
            {
                Console.WriteLine(string.Format(InfoFormatString, $"Id {id} is not in list."));
                return;
            }
            else if (id <= 0)
            {
                Console.WriteLine(string.Format(InfoFormatString, $"Id {id} is not a valid id."));
                return;
            }

            ITodoElement elementToComplete = elements[id-1];

            if (elementToComplete.IsDone())
            {
                Console.WriteLine(string.Format(InfoFormatString, "Todo element is already marked as done."));
                return;
            }

            elementToComplete.MarkAsDone();

            Console.WriteLine("Completed {0}", elementToComplete);

            Save();
        }

        public void PrintElements()
        {
            bool allDone = !elements.Any(element => element.IsDone() == false);

            if (allDone)
            {
                Console.WriteLine(string.Format(InfoFormatString, "All elements is marked as done."));
            }

            foreach (ITodoElement element in elements)
            {
                if (!element.IsDone())
                {
                    Console.WriteLine(element);
                }
            }
        }

        public void Load()
        {
            using (StreamReader file = new StreamReader("data.json"))
            {
                string r = file.ReadToEnd();
                JsonConverter[] converters = { new TodoElementConverter() };

                try
                {
                    elements = JsonConvert.DeserializeObject<List<ITodoElement>>(r, converters: converters);
                }
                catch (JsonReaderException e)
                {
                    Console.WriteLine(string.Format(ErrorFormatString, e.Message));
                    Console.WriteLine(string.Format(ErrorFormatString, "Could not load saved list. Creating new todo list"));
                    elements = new List<ITodoElement>();
                }
            }
        }

        public void Save()
        {
            using (StreamWriter file = new StreamWriter("data.json"))
            {
                var settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;

                try
                {
                    string data = JsonConvert.SerializeObject(elements, formatting: Formatting.Indented, settings: settings);
                    file.Write(data);
                }
                catch (JsonWriterException e)
                {
                    Console.WriteLine(string.Format(ErrorFormatString, e.Message));
                    Console.WriteLine(string.Format(ErrorFormatString, "Failed to save. Dumping elements in console"));

                    foreach (ITodoElement TodoElement in elements)
                    {
                        Console.WriteLine(TodoElement);
                    }
                }
            }
        }

        public int GetSize()
        {
            return elements.Count;
        }

        public ITodoElement[] GetTodoElements()
        {
            return elements.ToArray();
        }
    }
}