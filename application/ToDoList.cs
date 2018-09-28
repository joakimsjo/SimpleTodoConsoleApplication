using System;
using System.Collections.Generic;
using System.IO;
using application;
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
            ToDoElement newTodoElemen = new ToDoElement();
        }

        public void DoElement(string id)
        {
            throw new NotImplementedException();
        }


        public void PrintElements()
        {
            throw new NotImplementedException();
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
            using (StreamWriter file = File.CreateText("data.json")) {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, file);
            }
        }
    }
}