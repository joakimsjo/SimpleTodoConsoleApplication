using System;
using NUnit.Framework;
using Application;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class TodoTests
    {
        [Test]
        public void CreateTodo()
        {
            var todo = new Todo(new TodoList());

            Assert.NotNull(todo);
        }

        [Test]
        [TestCase("Add someTodoListElement")]
        public void TodoTestAddVerb(string action)
        {
            var todo = new Todo(new TodoList());

            todo.DoAction(action);

            Assert.NotNull(todo);
            Assert.AreEqual(1, todo._list.GetSize());
        }

        [Test]
        [TestCase("Add ")]
        public void TodoTestAddVerbShouldNotAdd(string action)
        {
            var todo = new Todo(new TodoList());

            todo.DoAction(action);

            Assert.NotNull(todo);
            Assert.AreEqual(0, todo._list.GetSize());
        }

        [Test]
        [TestCase(new object[] {"Add \"\"", "Add \"", "Add '", "Add ''"})]
        public void TodoTestAddVerbShouldNotAddEmptyDescriptionString(object[] actions)
        {
            var todo = new Todo(new TodoList());

            foreach(string action in actions)
            {
                todo.DoAction(action);
            }

            Assert.NotNull(todo);
            Assert.AreEqual(0, todo._list.GetSize());
        }

        [Test]
        [TestCase("Add someTodoListElement", "Do #1")]
        public void TodoTestDoVerb(string addAction, string doAction)
        {
            var todo = new Todo(new TodoList());

            todo.DoAction(addAction);
            todo.DoAction(doAction);

            var elements = todo._list.GetTodoElements();

            Assert.NotNull(todo);
            Assert.AreEqual(1, todo._list.GetSize());
            Assert.IsTrue(elements[0].IsDone());
        }

        [Test]
        [TestCase("Add someTodoListElement", "Do ")]
        public void TodoTestDoVerbShouldNotDo(string addAction, string doAction)
        {
            var todo = new Todo(new TodoList());

            todo.DoAction(addAction);
            todo.DoAction(doAction);

            var elements = todo._list.GetTodoElements();

            Assert.NotNull(todo);
            Assert.AreEqual(1, todo._list.GetSize());
            Assert.IsFalse(elements[0].IsDone());
        }

        [Test]
        [TestCase("Add someTodoListElement", 10)]
        public void TodoAddElements(string action, int numElements)
        {
            var todo = new Todo(new TodoList());
            
            for(int i = 0; i < numElements; i++)
            {
                todo.DoAction(action);
            }

            var elements = todo._list.GetTodoElements();

            Assert.NotNull(todo);
            Assert.AreEqual(numElements, todo._list.GetSize());
        }

        [Test]
        [TestCase("Add someTodoListElement", 10, new object[] {"Do #1", "Do #4", "Do #5"})]
        public void TodoAddElementsMarkSomeDone(string action, int numElements, object[] doActions)
        {
            var todo = new Todo(new TodoList());
            
            for(int i = 0; i < numElements; i++)
            {
                todo.DoAction(action);
            }

            foreach(string doAction in doActions)
            {
                todo.DoAction(doAction);
            }

            var elements = todo._list.GetTodoElements();
            int markedDone = 0;
            
            for(int i = 0; i < numElements; i++)
            {
                if (elements[i].IsDone())
                {
                    markedDone += 1;
                }
            }

            Assert.NotNull(todo);
            Assert.AreEqual(numElements, todo._list.GetSize());
            Assert.AreEqual(markedDone, doActions.Length);
        }

        [Test]
        [TestCase("Add someTodoListElement", 10, new string[] {"Do #0", "Do #4", "Do #5"})]
        public void TodoCheckPersistantState(string action, int numElements, string[] doActions)
        {
            var todo = new Todo(new TodoList());
            
            for(int i = 0; i < numElements; i++)
            {
                todo.DoAction(action);
            }

            foreach(string doAction in doActions)
            {
                todo.DoAction(doAction);
            }

            var elements = todo._list.GetTodoElements();

            todo = new Todo(new TodoList());
            var reloadedElements = todo._list.GetTodoElements();
            
            Assert.AreEqual(elements.Length, reloadedElements.Length);
            for(int i = 0; i < numElements; i++) 
            {
                Assert.AreEqual(elements[0].GetDescription(), reloadedElements[0].GetDescription());
                Assert.AreEqual(elements[0].IsDone(), reloadedElements[0].IsDone());
            }
            Assert.NotNull(todo);
        }

        [TearDown]
        public void cleanUp() 
        {
            if (File.Exists("data.json")) 
            {
                File.Delete("data.json");
            }
        }
    }
}