namespace Tasks;

public class T06_TwoSum
{
    public static void RunTask(string[] args)
    {
        List<int> numbers = new List<int>(); 
        int target;
        if (args.Length > 1)
        {
            string arrayData = args[0].Trim('[', ']'); 

            numbers = arrayData.Split(',')   
                                 .Select(int.Parse) 
                                 .ToList();         

            
            target = int.Parse(args[1]);
        }
        else return;

        Dictionary<int, int> seen = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            int complement = target - numbers[i];

            if (seen.ContainsKey(complement))
            {
                System.Console.WriteLine($"{seen[complement]}, {i}");
                return;
            }
            seen[numbers[i]] = i;
        }
        System.Console.WriteLine("null");
        return;
    }
}
