namespace Tasks;

public class T03_IsPalindrome
{
    public static void RunTask(string[] args)
    {
        string inputStr;
        if(args.Length > 0)
        {
            inputStr = args[0].ToLower();
        }
        else 
            return;
    int i = 0;
    int j = inputStr.Length -1;
    bool isPalindrome = false;

    while(i < j)
        {
            if (i >= j)
            {
                isPalindrome = true;
                break;
            }
            while (i < j && inputStr[i] == ' ') i++;
            while (i < j && inputStr[j] == ' ') j--;
            i++;
            j--;
        }    
        System.Console.WriteLine(isPalindrome);
    }
}