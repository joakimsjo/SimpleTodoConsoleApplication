using System;

namespace application {
    /// <summary>
    /// A todo element.
    /// </summary>
    public interface IToDoElement {
        /// <summary>
        /// Creates a new todo element
        /// </summary>
        /// <param name="description"> Description of what should be done </param>
        void Create(string description);

        /// <summary>
        /// Get name of todo element
        /// </summary>
        void GetDescription();

        /// <summary>
        /// Marks a element as done
        /// </summary>
        void MarkAsDone();

    }
}