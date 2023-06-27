

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
        public static double[] MergeSort(double[] unsorted_Array)
        {
            if(unsorted_Array.Length ==0 || unsorted_Array.Length == 1)
            {
                return unsorted_Array;
            }
            else
            {
                double[] left_Array = new double[unsorted_Array.Length / 2];
                double[] right_Array = new double[unsorted_Array.Length / 2];
                int middle_Element = unsorted_Array.Length / 2 ;

                for(int i = 0; i < middle_Element; i++)
                {
                    left_Array[i] = unsorted_Array[i];
                }
                for(int i = middle_Element; i < unsorted_Array.Length; i++)
                {
                    right_Array[i - middle_Element] = unsorted_Array[i];
                }


                left_Array = MergeSort(left_Array);
                right_Array = MergeSort(right_Array);
                return Merge(left_Array, right_Array);
            }
        }
        private static double[] Merge(double[] left_Array, double[] right_Array)
        {
            double[] merged = new double[left_Array.Length + right_Array.Length];
            int i_left = 0;
            int i_right = 0;
            int i_merged = 0;
            while (right_Array.Length < right_Array.Length || left_Array.Length < left_Array.Length)///////////
            {
                if (left_Array[i_left] >= right_Array[i_right])
                {
                    merged[i_merged++] = left_Array[i_left++];
                }
                else
                {
                    merged[i_merged++] = right_Array[i_right++];
                }
            }
            return merged;
        }
    }
}
