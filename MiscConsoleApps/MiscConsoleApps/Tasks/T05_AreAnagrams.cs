namespace Tasks;

public class T05_AreAnagrams
{
    public static void RunTask(string[] args)
    {
        string a;
        string b;

       List<char> listA = new List<char>();
       List<char> listB = new List<char>();

        if(args.Length > 1)
        {
            a = args[0].ToLower();
            b = args[1].ToLower();
        }
        else return;

        foreach(char c in a)
        {
            if(Char.IsLetter(c)) listA.Add(c);
        }

        foreach(char c in b)
        {
            if(Char.IsLetter(c)) listB.Add(c);
        }

        listA.Sort(); // nlog(n), using dictionary would keep it log(n) 
        listB.Sort();

        if (listA.Count != listB.Count)
        {
            System.Console.WriteLine("false");
            return;
        }

        for(int i = 0; i < listA.Count; i++)
        {
            if(listA[i] == listB[i]) continue;
            else
            {
                System.Console.WriteLine("false");
                return;
            }
        }

        System.Console.WriteLine("true");
    }
}