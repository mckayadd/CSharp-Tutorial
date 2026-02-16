namespace Tasks;

public class T07_ValidateParantheses
{
    public static void RunTask(string[] args)
    {
        Stack<char> stack = new Stack<char>(); 
        if (args.Length == 0) return;
        string input = args[0];

        foreach(char c in input)
        {

            if(c == '{' || c == '(' || c == '[') 
            {
                stack.Push(c);
            }
            else if(c == '}' || c == ')' || c == ']')
            {
                if (stack.Count == 0) 
                {
                    System.Console.WriteLine("false");
                    return;
                }

                char popped = stack.Pop();

                if ((c == '}' && popped != '{') ||
                    (c == ')' && popped != '(') ||
                    (c == ']' && popped != '['))
                {
                    System.Console.WriteLine("false");
                    return;
                }
            }
        }
        System.Console.WriteLine(stack.Count == 0 ? "true" : "false");
    }
}