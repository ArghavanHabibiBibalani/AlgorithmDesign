using AlgorithmsLib;

public class Program
{
    static void Main(string[] args)
    {

        int edge = 8;
        int verteces = 7;
        int[, ] save = new int[8, 3] { {0, 1, 10 }, {1, 2, 10 }, {2, 3, 10 }, {0, 3, 10 }, {3, 4, 2 }, {4, 5, 3 }, {5, 6, 3 }, {4, 6, 8 } };
        
        Console.WriteLine(GraphAlgorithms.Kruskal(verteces, edge, save));
        
        var height = 8;
        var width = 8;
        var matrix = new double[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                matrix[i, j] = i + j;
            }
        }
        Console.WriteLine(Utility.MatrixToString(matrix));
        var s11 = Utility.SplitMatrix(matrix, 0);
        var s12 = Utility.SplitMatrix(matrix, 1);
        var s21 = Utility.SplitMatrix(matrix, 2);
        var s22 = Utility.SplitMatrix(matrix, 3);
        Console.WriteLine(Utility.MatrixToString(s11));
        Console.WriteLine(Utility.MatrixToString(s12));
        Console.WriteLine(Utility.MatrixToString(s21));
        Console.WriteLine(Utility.MatrixToString(s22));
        Console.WriteLine(Utility.MatrixToString(MatrixAlgorithms.MultiplyMatrices(s11, s12)));
    }
}