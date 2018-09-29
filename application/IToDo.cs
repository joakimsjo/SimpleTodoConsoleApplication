using System;

namespace Application 
{
    /// <summary>
    /// A todo class.
    /// </summary>
    public interface ITodo 
    {
        /// <summary>
        /// Performes an action on the ToDoList
        /// </summary>
        /// <param name="action"> Description of what action to be executed</param>
        void DoAction(string action);
    }
}