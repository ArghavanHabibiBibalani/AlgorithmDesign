

namespace AlgorithmsLib
{
    public class Utility
    {
        public static void Swap(ref double[] array, int first, int second) { (array[first], array[second]) = (array[second], array[first]); }
        public static string ArrayToString(double[] array)
        {
            var output = "{ ";
            for (int i = 0; i < array.Length; i++)
            {
                output += Convert.ToString(array[i]);
                output += (i == array.Length - 1) ? " }" : ", ";
            }
            return output;
        }
    }
}
