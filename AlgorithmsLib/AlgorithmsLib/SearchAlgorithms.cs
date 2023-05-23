namespace AlgorithmsDesign
{
    public class SearchAlgorithms
    {
        public static int BinarySearch(int[] array, int low, int high, double value)
        {
            int midPoint = (low + high) / 2;
            if (value == array[midPoint]) { return midPoint; }
            else if (value < array[midPoint]) { return BinarySearch(array, low, midPoint, value); }
            else { return BinarySearch(array, midPoint + 1, high, value); }
        }
        public static int BinarySearch(int[] array, double value)
        {
            var low = 0;
            var high = array.Length - 1;
            var midPoint = (low + high) / 2;
            if (value == array[midPoint]) { return midPoint; }
            else if (value < array[midPoint]) { return BinarySearch(array, low, midPoint, value); }
            else { return BinarySearch(array, midPoint + 1, high, value); }
        }
    }
}