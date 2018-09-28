using System;


namespace application {

    public class ToDoElement : IToDoElement
    {
        int _id;
        string _description;
        Boolean _done;

        public ToDoElement(int id, string description) {
            _id = id;
            _description = description;
            _done = false;
        }
        public string GetDescription()
        {
            return _description;
        }

        public void MarkAsDone()
        {
            _done = true;
        }
    }
}