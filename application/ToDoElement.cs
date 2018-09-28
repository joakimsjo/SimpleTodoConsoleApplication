using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace application
{
    public class TodoElement : ITodoElement
    {
        private readonly string formatString = "#{0} {1}";
        public int _id;
        public string _description;
        public bool _done;

        public TodoElement(int id, string description)
        {
            _id = id;
            _description = description;
            _done = false;
        }

        public TodoElement(int id, string description, bool done)
        {
            _id = id;
            _description = description;
            _done = done;
        }

        public void MarkAsDone()
        {
            _done = true;
        }

        public bool IsDone()
        {
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

    public class TodoElementConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ITodoElement));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject TodoObject = JObject.Load(reader);
            return new TodoElement(TodoObject["_id"].Value<int>(), TodoObject["_description"].Value<string>(), TodoObject["_done"].Value<bool>());
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}