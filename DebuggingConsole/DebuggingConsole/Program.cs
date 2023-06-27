using AlgorithmsLib;

public class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine(Utility.ArrayToString(GenerationAlgorithms.BinomialExpansion(12)));

        int edge = 8;
        int verteces = 7;
        int[, ] save = new int[8, 3] { {0, 1, 10 }, {1, 2, 10 }, {2, 3, 10 }, {0, 3, 10 }, {3, 4, 2 }, {4, 5, 3 }, {5, 6, 3 }, {4, 6, 8 } };
        
        Console.WriteLine(GraphAlgorithms.Kruskal(verteces, edge, save));
        
    }
}