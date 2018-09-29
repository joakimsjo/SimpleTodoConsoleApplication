using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this simple to do application!");
            Console.WriteLine("Type 'Help' for a description of actions");
            Console.WriteLine("Type 'Quit' to exit the application");
            Todo app = new Todo(new TodoList());

            while (true) 
            {
                Console.Write(">");
                string command = Console.ReadLine();
                app.DoAction(command);
            }
        }
    }
}