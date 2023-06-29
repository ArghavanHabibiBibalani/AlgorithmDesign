

namespace AlgorithmsLib
{
    public class MatrixAlgorithms
    { 
        public static double[,] MultiplyMatrices(double[,] first, double[,] second)
        {
            if (first.GetLength(1) == second.GetLength(0))
            {
                if (Utility.CanSplitMatrix(first) && Utility.CanSplitMatrix(second))
                {
                    return MultiplyMatricesStrassen(first, second);
                }
                else
                {
                    return MultiplyMatricesBruteForce(first, second);
                }
            }
            throw new ArgumentException("The first matrix's width should be equal to the second's height");
        }
        public static double[,] MultiplyMatricesBruteForce(double[,] first, double[,] second)
        {
            if (first.GetLength(1) != second.GetLength(0))
            {
                throw new ArgumentException("The first matrix's width should be equal to the second's height");
            }
            var output = new double[first.GetLength(0), second.GetLength(1)];
            for (int i = 0; i < first.GetLength(0); i++)
            {
                for (int j = 0; j < second.GetLength(1); j++)
                {
                    for (int k = 0; k < first.GetLength(1); k++)
                    {
                        output[i, j] += first[i, k] * second[k, j];
                    }
                }
            }
            return output;
        }
        public static double[,] MultiplyMatricesStrassen(double[,] first, double[,] second)
        {
            if (first.GetLength(0) != first.GetLength(1) ||
                first.GetLength(1) != second.GetLength(0) ||
                second.GetLength(0) != second.GetLength(1))
            {
                throw new ArgumentException("The matrices are either incompatible or not square");
            }
            // Recursion's base-case
            if (Utility.CanSplitMatrix(first) == false)
            {
                return MultiplyMatricesBruteForce(first, second);
            }

            // Split the two matrices into 8 smaller ones
            var f11 = Utility.SplitMatrix(first, 0);
            var f12 = Utility.SplitMatrix(first, 1);
            var f21 = Utility.SplitMatrix(first, 2);
            var f22 = Utility.SplitMatrix(first, 3);
            var s11 = Utility.SplitMatrix(second, 0);
            var s12 = Utility.SplitMatrix(second, 1);
            var s21 = Utility.SplitMatrix(second, 2);
            var s22 = Utility.SplitMatrix(second, 3);

            // Calculate the 7 terms needed
            var t1 = MultiplyMatricesStrassen(Utility.AddSubMatrices(f11, f22, true), Utility.AddSubMatrices(s11, s22, true)); // (A1 + A4) * (B1 + B4)
            var t2 = MultiplyMatricesStrassen(Utility.AddSubMatrices(f21, f22, true), s11); // (A3 + A4) * B1
            var t3 = MultiplyMatricesStrassen(f11, Utility.AddSubMatrices(s12, s22, false)); // A1 * (B2 - B4)
            var t4 = MultiplyMatricesStrassen(f22, Utility.AddSubMatrices(s21, s11, false)); // A4 * (B3 - B1)
            var t5 = MultiplyMatricesStrassen(Utility.AddSubMatrices(f11, f12, true), s22); // (A1 + A2) * B4
            var t6 = MultiplyMatricesStrassen(Utility.AddSubMatrices(f21, f11, false), Utility.AddSubMatrices(s11, s12, true)); // (A3 - A1) * (B1 + B2)
            var t7 = MultiplyMatricesStrassen(Utility.AddSubMatrices(f12, f22, false), Utility.AddSubMatrices(s21, s22, true)); // (A2 - A4) * (B3 + B4)

            // Make the 4 sections of the new matrix
            var R11 = Utility.AddSubMatrices(Utility.AddSubMatrices(Utility.AddSubMatrices(t1, t4, true), t5, false), t7, true); // t1 + t4 - t5 + t7
            var R12 = Utility.AddSubMatrices(t3, t5, true); // t3 + t5
            var R21 = Utility.AddSubMatrices(t2, t4, true); // t2 + t4
            var R22 = Utility.AddSubMatrices(Utility.AddSubMatrices(Utility.AddSubMatrices(t1, t2, false), t3, true), t6, true); // t1 - t2 + t3 + t6

            // Merge the matrices and return the result
            return Utility.MergeMatrices(R11, R12, R21, R22);
        }

    }
}
