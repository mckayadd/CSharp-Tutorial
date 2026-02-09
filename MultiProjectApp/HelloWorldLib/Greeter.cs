namespace HelloWorldLib;

public class Greeter
{
    public static string GetMessage(string name = "World")
    {
        return $"Hello {name}!";
    }

}
