using System;
using NUnit.Framework;
using Application;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class TodoElementTests
    {
        [Test]
        [TestCase(0, "someTodoListElement")]
        public void CreateTodoElement(int id, string description)
        {
            var element = new TodoElement(id, description);

            Assert.NotNull(element);
        }

        [Test]
        [TestCase(0, "someTodoListElement")]
        public void CreateTodoElementCheckCorrectness(int id, string description)
        {
            var element = new TodoElement(id, description);

            Assert.NotNull(element);
            StringAssert.AreEqualIgnoringCase(description, element._description);
            Assert.AreEqual(id, element._id);
        }

        [Test]
        [TestCase(0, "someTodoListElement", true)]
        public void CreateTodoElementRestoreStateConstructur(int id, string description, bool done)
        {
            var element = new TodoElement(id, description, done);

            Assert.NotNull(element);
            StringAssert.AreEqualIgnoringCase(description, element._description);
            Assert.AreEqual(id, element._id);
            Assert.AreEqual(done, element._done);
        }

        [Test]
        [TestCase(0, "someTodoListElement")]
        public void MarkTodoElementAsDone(int id, string description)
        {
            var element = new TodoElement(id, description);

            element.MarkAsDone();

            Assert.NotNull(element);
            Assert.IsTrue(element._done);
        }
    }
}