

namespace AlgorithmsLib
{
    public class SortingAlgorithms
    {
        public static void ExchangeSort(double[] array) // Θ(n^2)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j]) { Utility.Swap(array, i, j); } 
                }
            }
        }
        public static void QuickSort(double[] array) { QuickSort(array, 0, array.Length - 1); }
        public static void QuickSort(double[] array, int low, int high) // Θ(nlog(n))
        {
            if (high - low <= 1)
            {
                if (low < high && array[low] > array[high]) { Utility.Swap(array, low, high); }
                return;
            }
            // Middle element as pivot to reduce chance of worst-case scenario
            Utility.Swap(array, (low + high) / 2,  high); 
            var pivot = array[high];
            var left = low;
            var right = high - 1;

            left = Partition(array, pivot, ref left, ref right);

            Utility.Swap(array, left, high);

             // Left subarray
            if (low < left) { QuickSort(array, low, left - 1); }
            // Right subarray
            if (high > right) { QuickSort(array, left + 1, high); }
            return;  
        }
        private static int Partition(double[] array, double pivot, ref int left, ref int right)
        {
            while (left < right)
            {
                while (array[left] < pivot) { left++; }
                while (array[right] > pivot) { right--; }
                if (left < right) { Utility.Swap(array, left, right); }
            }
            return left;
        }
    }
}
