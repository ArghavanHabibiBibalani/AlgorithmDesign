

namespace AlgorithmsLib
{
    internal class Utility
    {
        public void Swap(ref double[] array, int first, int second) { (array[first], array[second]) = (array[second], array[first]); }
    }
}
