

namespace AlgorithmsDesign
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
    }
}
