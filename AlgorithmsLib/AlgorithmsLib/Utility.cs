

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
    }
}
