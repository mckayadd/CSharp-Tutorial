
namespace Tasks
{
    // Fizz for multiples of 3, Buzz for multiples of 5, FizzBuzz for 3x5, up to N
    public class T01_FizzBuzz
    {
        public static void RunTask(string[] args)
        {
            int N = 100;
            if (args.Length > 0 && int.TryParse(args[0], out int parsed))
            {
                N = parsed;
            }

            for (int i = 1; i <= N; i++)
            {
                if (i % 15 == 0) System.Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0) System.Console.WriteLine("Fizz");
                else if (i % 5 == 0) System.Console.WriteLine("Buzz");
                else System.Console.WriteLine(i);
            }
        }
    }
}