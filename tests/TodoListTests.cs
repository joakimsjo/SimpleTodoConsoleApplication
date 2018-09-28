using System;
using NUnit.Framework;
using application;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class TodoListTests
    {
        [Test]
        public void CreateTodoList()
        {
            var list = new TodoList();

            Assert.NotNull(list);
        }

        [Test]
        [TestCase("someTodoListItem")]
        public void TodoListAddNewElementShouldAdd(string description)
        {
            var list = new TodoList();
            
            list.AddElement(description);
            
            Assert.NotNull(list);
            Assert.AreEqual(1, list.GetSize());
        }

        [Test]
        [TestCase("someTodoListItem")]
        public void TodoListAddNewElementShoudAddCheckDescription(string description)
        {
            var list = new TodoList();

            list.AddElement(description);
            var elements = list.GetTodoElements();
            
            Assert.NotNull(list);
            StringAssert.AreEqualIgnoringCase(description, elements[0].GetDescription());

        }

        [Test]
        [TestCase("someTodoListItem", "0")]
        public void TodoListMarkDone(string description, string id)
        {
            var list = new TodoList();

            list.AddElement(description);
            list.DoElement(id);

            var elements = list.GetTodoElements();

            Assert.NotNull(list);
            Assert.IsTrue(elements[0].IsDone());
        }

        [Test]
        [TestCase("someTodoListItem", 5)]
        public void TodoListAddElements(string description, int numElements) 
        {
            var list = new TodoList();

            for(int i = 0; i < numElements; i++) 
            {
                list.AddElement(description);
            }

            var elements = list.GetTodoElements();

            Assert.NotNull(list);
            Assert.AreEqual(numElements, elements.Length);
        }

        [Test]
        [TestCase("someTodoListItem", 10, 3)]
        public void TodoListMarkElementsDone(string description, int numElements, int shouldBeMarkedDone) 
        {
            var list = new TodoList();

            for(int i = 0; i < numElements; i++) 
            {
                list.AddElement(description);
            }
            
            for(int i = 0; i < shouldBeMarkedDone; i++)
            {
                list.DoElement(i.ToString());
            }

            var elements = list.GetTodoElements();

            int markedDone = 0;
            for(int i = 0; i < numElements; i++) 
            {
                if (elements[i].IsDone())
                {
                    markedDone += 1;
                }
            }

            Assert.NotNull(list);
            Assert.AreEqual(shouldBeMarkedDone, markedDone);
        }

        [Test]
        [TestCase("someTodoListItem", 10)]
        public void TodoListAddElementsCreateNewListCheckState(string description, int numElements)
        {
            var list = new TodoList();

            for(int i = 0; i < numElements; i++)
            {
                list.AddElement(description);
            }

            var elements = list.GetTodoElements();
            list = new TodoList();

            var reloadedElements = list.GetTodoElements();

            Assert.AreEqual(elements.Length, reloadedElements.Length);
            for(int i = 0; i < numElements; i++) 
            {
                Assert.AreEqual(elements[0].GetDescription(), reloadedElements[0].GetDescription());
                Assert.AreEqual(elements[0].IsDone(), reloadedElements[0].IsDone());
            }
            Assert.NotNull(list);
        }

        [Test]
        [TestCase("someTodoListItem", 10, 4)]
        public void TodoListAddElementsMarkSomeDoneCreateNewListCheckState(string description, int numElements, int shouldBeMarkedDone)
        {
            var list = new TodoList();

            for(int i = 0; i < numElements; i++)
            {
                list.AddElement(description);
            }

            for(int i = 0; i < shouldBeMarkedDone; i++)
            {
                list.DoElement(i.ToString());
            }

            var elements = list.GetTodoElements();
            list = new TodoList();

            var reloadedElements = list.GetTodoElements();

            Assert.AreEqual(elements.Length, reloadedElements.Length);
            for(int i = 0; i < numElements; i++) 
            {
                Assert.AreEqual(elements[0].GetDescription(), reloadedElements[0].GetDescription());
                Assert.AreEqual(elements[0].IsDone(), reloadedElements[0].IsDone());
            }
            Assert.NotNull(list);
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