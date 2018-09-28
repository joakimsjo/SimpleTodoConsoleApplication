using System;

namespace application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this simple to do application!");
            Todo app = new Todo(new TodoList());

            while(true) 
            {
                string command = Console.ReadLine();
                app.DoAction(command);
            }
        }
    }
}
