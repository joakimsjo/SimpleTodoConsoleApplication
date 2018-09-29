using System;

namespace Application 
{
    /// <summary>
    /// A todo element.
    /// </summary>
    public interface ITodoElement 
    {
        /// <summary>
        /// Get name of todo element
        /// </summary>
        /// <returns>Returns description of element</returns>
        string GetDescription();

        /// <summary>
        /// Marks a element as done
        /// </summary>
        void MarkAsDone();

        /// <summary>
        /// Indicates if a element is completed
        /// </summary>
        /// <returns>Returns boolean indicating if element is marked as done</returns>
        bool IsDone();
    }
}