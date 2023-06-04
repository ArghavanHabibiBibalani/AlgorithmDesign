using AlgorithmsLib;

public class Program
{
    static void Main(string[] args, SortingAlgorithms sortingAlgorithms)
    {
        double[] a = new double[] { 27, 10, 12, 20, 25, 13, 15, 22 };
        //SortingAlgorithms sortingAlgorithms = new SortingAlgorithms();
        double[] i  = SortingAlgorithms.MergeSort(a);
        Console.WriteLine(i);

    }
}