namespace UserInputApp;

public class UserScanner
{
    public static string AskName()
    {
        Console.Write("Your name: ");
        string? input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? "World" : input;
    }
}
