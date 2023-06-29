using AlgorithmsLib;

public class Program
{
    static void Main(string[] args)
    {
        int[,] adjMatrix = { { 0, 3, 2, 0, 4, 0, 0 },
                             { 0, 0, 0, 1, 6, 1, 7 },
                             { 0, 0, 0, 4, 0, 0, 6 },
                             { 0, 1, 4, 0, 0, 2, 0 },
                             { 4, 6, 0, 3, 0, 8, 5 },
                             { 0, 1, 1, 0, 8, 0, 0 },
                             { 0, 7, 0, 0, 0, 0, 0 } };
        Console.WriteLine(Utility.ArrayToString(GraphAlgorithms.Dijkstra(adjMatrix, 0)));
    }
}