

namespace AlgorithmsLib
{
    public class SortingAlgorithms
    {
        public static double[] ExchangeSort(double[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        Utility.Swap(ref array, i, j);
                    } 
                }
            }
            return array;
        }
    }
}
