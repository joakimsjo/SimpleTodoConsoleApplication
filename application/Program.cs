using System;

namespace application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this simple to do application!");
            Console.WriteLine("Type 'Help' for a description of actions");
            Todo app = new Todo(new TodoList());

            while(true) 
            {
                string command = Console.ReadLine();
                app.DoAction(command);
            }
        }
    }
}
