using AlgorithmsLib;

public class Program
{
    static void Main(string[] args)
    {

        int edge = 4;
        int[,] save = new int[4, 4] { { 0, 3, 100000, 5 }, { 2, 0, 100000, 4 }, { 100000, 1, 4, 100000 }, { 100000, 100000, 2 ,0 } };
        GraphAlgorithms.FloydWarshall(save, edge);
    }
}