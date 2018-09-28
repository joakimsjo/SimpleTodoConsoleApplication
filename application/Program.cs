using System;

namespace application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this simple to do application!");
            ToDo app = new ToDo();

            while(true) {
                string command = Console.ReadLine();
                app.DoAction(command);
            }
            
        }
    }
}
