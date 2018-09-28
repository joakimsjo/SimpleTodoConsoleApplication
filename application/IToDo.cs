using System;

namespace application {
    /// <summary>
    /// A todo class.
    /// </summary>
    public interface IToDo {
        /// <summary>
        /// Performes an action on the ToDoList
        /// </summary>
        /// <param name="action"> Description of what action be done</param>
        void DoAction(string action);

    }
}