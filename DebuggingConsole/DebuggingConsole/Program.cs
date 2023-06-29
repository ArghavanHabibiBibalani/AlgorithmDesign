using AlgorithmsLib;

public class Program
{
    static void Main(string[] args)
    {
        int[] profit = new int[3] { 50, 60, 140 };
        int[] value = new int[3] {5, 10, 20};
        int total = 30;
        Console.WriteLine(ProblemSolutions.KnapSack(value, profit, total, profit.Length));
    }
}