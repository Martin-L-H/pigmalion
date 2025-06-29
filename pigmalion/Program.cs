namespace pigmalion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 4, 3, 9 };
            int[] array2 = { 1, 2, 4, 4 };
            Console.WriteLine(Method1(array1, 8));
            Console.WriteLine(Method1(array2, 8));
            Console.WriteLine();
            Console.WriteLine(Method2(array1, 8));
            Console.WriteLine(Method2(array2, 8));
        }
        private static bool Method1(int[] array, int objective)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == objective)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool Method2(int[] array, int objective)
        {
            HashSet<int> hash = new HashSet<int>();
            foreach (int num in array)
            {
                int complemento = objective - num;
                if (hash.Contains(complemento))
                {
                    return true;
                }
                hash.Add(num);
            }
            return false;
        }
    }
}
