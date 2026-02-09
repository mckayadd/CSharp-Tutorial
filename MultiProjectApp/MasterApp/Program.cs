using HelloWorldLib;
using UserInputApp;
using Pastel;
using System.Drawing;

class Program
{
    static void Main()
    {
        Console.WriteLine("--- MASTER APP ---".Pastel(Color.Gold));

        string name = UserScanner.AskName();
        string message = Greeter.GetMessage(name);

        Console.WriteLine("\n[Final Output]: ".Pastel(Color.Cyan) + message.Pastel(Color.Chartreuse));
        Console.WriteLine("-----------------------------".Pastel(Color.Gold));
    }
}
