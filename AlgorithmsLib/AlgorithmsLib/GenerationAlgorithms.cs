

namespace AlgorithmsLib
{
    public class GenerationAlgorithms
    {
        public static double FibonacciSequence(int nthNumber)
        {
            switch (nthNumber)
            {   
                case 0:
                    return 0;
                case 1:
                case 2:
                    return 1;
                default:
                    break;
            }
            var buffer = new double[nthNumber];
            buffer[0] = 1;
            buffer[1] = 1;
            for (var i = 2; i < nthNumber; i++)
            {
                buffer[i] = buffer[i - 1] + buffer[i - 2];
            }
            return buffer[nthNumber - 1];
        }
        public static int[] BinomialExpansion(int n)
        {
            var buffer = new int[n, n];
            var output = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int k = 0; k <= i; k++)
                {
                    if (i == n)
                    {
                        if (k == 0 || i == k) { output[k] = 1; }
                        else { output[k] = buffer[i - 1, k - 1] + buffer[i - 1, k]; }
                    }
                    else
                    {
                        if (k == 0 || i == k) { buffer[i, k] = 1; }
                        else { buffer[i, k] = buffer[i - 1, k - 1] + buffer[i - 1, k]; }
                    }
                }
            }
            return output;
        }
    }
}
