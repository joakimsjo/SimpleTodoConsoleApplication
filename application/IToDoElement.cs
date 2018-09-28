using System;

namespace application {
    /// <summary>
    /// A todo element.
    /// </summary>
    public interface IToDoElement {
        /// <summary>
        /// Get name of todo element
        /// </summary>
        string GetDescription();

        /// <summary>
        /// Marks a element as done
        /// </summary>
        void MarkAsDone();

    }
}