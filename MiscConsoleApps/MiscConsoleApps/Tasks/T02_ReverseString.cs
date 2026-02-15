
namespace Tasks
{
    // Reverse a given string
    public class T02_ReverseString
    {
        public static void RunTask(string[] args)
        {
            string inputStr = "";
            if(args.Length > 0)
            {
                foreach(string s in args)
                    inputStr += s + " ";
            }
            else 
                inputStr = "Read this backwards!";
            
            string reverse = "";

            for (int i = inputStr.Length - 1; i >= 0; i--)
            {
                reverse += inputStr[i];
            }

            System.Console.WriteLine(reverse);
        }
    }
}