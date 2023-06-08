namespace AlgorithmsLib
{
    public class SearchAlgorithms
    {
        public static int BinarySearch(int[] array, double value) { return BinarySearch(array, value, 0, array.Length - 1); } // Θ(nlog(n))
        public static int BinarySearch(int[] array, double value, int low, int high)
        {
            int midPoint = (low + high) / 2;
            if (value == array[midPoint]) { return midPoint; }
            else if (value < array[midPoint]) { return BinarySearch(array, value, low, midPoint); }
            else { return BinarySearch(array, value, midPoint + 1, high); }
        }
    }
}