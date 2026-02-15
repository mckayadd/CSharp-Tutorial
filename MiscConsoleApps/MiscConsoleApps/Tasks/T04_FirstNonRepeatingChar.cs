
namespace Tasks;

public class T04_FirstNonRepeatingChar
{
    public static void RunTask(string[] args)
    {
        string input= "";
        if(args.Length > 0)
        {
            input = args[0];
        }
        else
            return;
       
        Dictionary<char, int> chars = new Dictionary<char, int>();

       foreach(char c in input)
        {
            if(c == ' ') continue;
            if(chars.ContainsKey(c))
            {
                chars[c] += 1;
            }
            else
            {
                chars[c] = 1;
            }
        } 

        foreach(char c in input)
        {
            if(c == ' ') continue;
            if(chars[c] == 1)
            {
                System.Console.WriteLine(c);
                return;
            }
        }

        System.Console.WriteLine("null");
       
    }
}
