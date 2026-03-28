using System;

// Defining the delegate in this example, the Processor class doesn't have to know to who to notify. 

// 1. Define a delegate
public delegate void ProcessCompleted(string message);

class Processor
{
    // 2. declare a variable with the type of the delegate
    public ProcessCompleted OnCompleted;

    public void Start()
    {
        // simulate a process
        Console.WriteLine("started...");

        // 3. call delegate when the process ends
        OnCompleted?.Invoke("Process ended succesfully.");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Processor p = new Processor();

            // 4. bind a method to the delegate
            p.OnCompleted = ShowMessage;

            // 5. start the process
            p.Start();
        }

        static void ShowMessage(string msg)
        {
            Console.WriteLine("Notification: " + msg);
        }

    }
}