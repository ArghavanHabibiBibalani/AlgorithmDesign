

namespace AlgorithmsLib
{
    public class Utility
    {
        public static void Swap(double[] array, int first, int second) { (array[first], array[second]) = (array[second], array[first]); }
        public static string ArrayToString<T>(T[] array)
        {
            var output = "{ ";
            for (int i = 0; i < array.Length; i++)
            {
                output += Convert.ToString(array[i]);
                output += (i == array.Length - 1) ? " }" : ", ";
            }
            return output;
        }
        public static string MatrixToString<T>(T[,] matrix)
        {
            var output = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                output += "{ ";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    output += matrix[i, j].ToString();
                    if (j != matrix.GetLength(1) - 1) { output += ", "; }
                }
                output += " }\n";
            }
            return output;
        }
        public static bool IsSorted(double[] array)
        {
            if (array.Length < 2) { return true; }
            double previous = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < previous) { return false; }
                previous = array[i];
            }
            return true;
        }
        public static double[,] AddSubMatrices(double[,] first, double[,] second, bool isAddition)
        {
            if (first.GetLength(0) != second.GetLength(0) || first.GetLength(1) != second.GetLength(1))
            {
                throw new ArgumentException("The dimentions of the matrices must be the same.");
            }
            var output = new double[first.GetLength(0), first.GetLength(1)];
            if (isAddition)
            {
                for (int i = 0; i < first.GetLength(0); i++)
                {
                    for (int j = 0; j < first.GetLength(1); j++)
                    {
                        output[i, j] = first[i, j] + second[i, j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < first.GetLength(0); i++)
                {
                    for (int j = 0; j < first.GetLength(1); j++)
                    {
                        output[i, j] = first[i, j] - second[i, j];
                    }
                }
            }
            return output;
        }
        internal static bool CanSplitMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                if (matrix.GetLength(0) % 4 == 0) { return true; }
            }
            return false;
        }
        public static double[,] SplitMatrix(double[,] matrix, int section)
        {
            if (CanSplitMatrix(matrix) == false)
            {
                throw new ArgumentException("The matrix cannot be split into 4 matrices.");
            }
            int newSide = matrix.GetLength(0) / 2;
            var output = new double[newSide, newSide];
            int row, column;
            switch (section)
            {
                case 0:
                    row = column = 0;
                    break;
                case 1:
                    row = 0;
                    column = newSide;
                    break;
                case 2:
                    row = newSide;
                    column = 0;
                    break;
                case 3:
                    row = column = newSide;
                    break;
                default:
                    throw new ArgumentException("The section index is irrelevant. Must be a number between 0 and 3 inclusive.");
            }
            for (int i = 0; i < newSide; i++, row++)
            {
                for (int j = 0; j < newSide; j++, column++)
                {
                    output[i, j] = matrix[row, column];
                }
                switch (section)
                {
                    case 0:
                    case 2:
                        column = 0;
                        break;
                    case 1:
                    case 3:
                        column = newSide;
                        break;
                }
            }
            return output;
        }
        public static double[,] MergeMatrices(double[,] s11, double[,] s12, double[,] s21, double[,] s22)
        {
            if (s11.GetLength(0) != s11.GetLength(1) || s12.GetLength(0) != s12.GetLength(1) ||
                s21.GetLength(0) != s21.GetLength(1) || s22.GetLength(0) != s22.GetLength(1) ||
                s11.GetLength(0) != s12.GetLength(0) || s12.GetLength(0) != s21.GetLength(0) ||
                s21.GetLength(0) != s22.GetLength(0))
            {
                throw new ArgumentException("The matrices are not compatible.");
            }
            var subMatrixSide = s11.GetLength(0);
            var output = new double[subMatrixSide * 2, subMatrixSide * 2];
            var row = 0;
            var column = 0;
            for (int i = 0; i < subMatrixSide; i++, row++)
            {
                for (int j = 0; j < subMatrixSide; j++, column++)
                {
                    output[row, column] = s11[i, j];
                }
                column = 0;
            }
            row = 0;
            column = subMatrixSide;
            for (int i = 0; i < subMatrixSide; i++, row++)
            {
                for (int j = 0; j < subMatrixSide; j++, column++)
                {
                    output[row, column] = s12[i, j];
                }
                column = subMatrixSide;
            }
            row = subMatrixSide;
            column = 0;
            for (int i = 0; i < subMatrixSide; i++, row++)
            {
                for (int j = 0; j < subMatrixSide; j++, column++)
                {
                    output[row, column] = s21[i, j];
                }
                column = 0;
            }
            row = column = subMatrixSide;
            for (int i = 0; i < subMatrixSide; i++, row++)
            {
                for (int j = 0; j < subMatrixSide; j++, column++)
                {
                    output[row, column] = s22[i, j];
                }
                column = subMatrixSide;
            }
            return output;
        }
        public static void PrintMAtrixForFloydWarshall(int[, ] matrix, int numberOfEdges)
        {
            for(int i = 0; i < numberOfEdges; i++)
            {
                for(int j = 0; j < numberOfEdges; j++)
                {
                    if (matrix[i, j] == GraphAlgorithms._maxNumber)
                    {
                        Console.Write("INF" + " ");
                    }
                    else 
                    {
                        Console.Write(matrix[i, j] + "   ");
                    }
                } Console.WriteLine();
            }
        }
    }
}
