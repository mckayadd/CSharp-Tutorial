using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the Task name as the first argument.");
            return;
        }

        string taskName = args[0];

        string[] taskArguments = args.Skip(1).ToArray();
        string fullTypeName = "Tasks." + taskName;

        try
        {
            Type taskType = Type.GetType(fullTypeName);

            if(taskType == null)
            {
                Console.WriteLine($"Error: Task '{fullTypeName}' not found.");
                return;
            }

            MethodInfo myMethod = taskType.GetMethod("RunTask", BindingFlags.Public | BindingFlags.Static);

            if (myMethod != null)
            {
                myMethod.Invoke(null, new object[]{taskArguments});
            }

            else
            {
                Console.WriteLine("Error: Method 'public static void RunTask(string[] args)' not found.");
            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

}