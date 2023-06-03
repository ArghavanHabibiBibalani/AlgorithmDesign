namespace AlgorithmsLib
{
    public class ProblemSolutions
    {
        public static void TowerOfHanoi(int diskCount) // Θ(2^n)
        {
            Console.WriteLine("Follow the steps below:");
            var stepCounter = 1;
            TowerOfHanoi(diskCount, 'a', 'c', 'b', ref stepCounter);
        }
        private static void TowerOfHanoi(int diskCount, char startingRod, char targetRod, char auxiliaryRod, ref int step)
        {
            if (diskCount == 1)
            {
                Console.WriteLine($"{step++}.Move disk 1 from rod {startingRod} to rod {targetRod}.");
                return;
            }
            TowerOfHanoi(diskCount - 1, startingRod, auxiliaryRod, targetRod, ref step);
            Console.WriteLine($"{step++}.Move disk {diskCount} from rod {startingRod} to rod {targetRod}.");
            TowerOfHanoi(diskCount - 1, auxiliaryRod, targetRod, startingRod, ref step);
        }
    }
}
