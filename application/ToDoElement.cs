using System;


namespace application {

    public class ToDoElement : IToDoElement
    {
        private readonly string formatString = "#{0} {1}";
        public int _id;
        public string _description;
        public bool _done;

        public ToDoElement(int id, string description) {
            _id = id;
            _description = description;
            _done = false;
        }

        public void MarkAsDone()
        {
            _done = true;
        }

        public bool IsDone() {
            return _done;
        }
        public string GetId()
        {
            return _id.ToString();
        }
        public string GetDescription()
        {
            return _description;
        }

        public override string ToString()
        {
            return string.Format(formatString, GetId(), GetDescription());
        }
    }
}