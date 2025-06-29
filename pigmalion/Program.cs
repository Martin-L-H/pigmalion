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
            Console.WriteLine();

            int[] arrayUser = ArrayGenerator();//Pregunta tamaño y valores de un array generado por el usuario, si se ingresa 0 devuelve nulo
            if (arrayUser != null)
            {
                int objective = NumberValidator();//Revisa que el numero objetivo sea valido y no sea 0 o negativo
                Console.WriteLine(Method2(arrayUser, objective));
            }
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
        private static int[]? ArrayGenerator()
        {
            bool isSizeValid = false;
            int arraySize = 0;
            do 
            {
                try
                {
                    Console.WriteLine("Ingrese el tamaño de array. 0 o negativos para salir de la aplicacion.");
                    arraySize = Convert.ToInt32(Console.ReadLine());
                    if(arraySize > 0)
                    {
                        isSizeValid = true;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Valor invalido.");
                    isSizeValid = false;
                }
            } while (isSizeValid == false);
            int[] array = new int[arraySize];
            for (int i = 0; i < array.Length; i++)
            {
                int value = 0;
                bool isValueValid = false;
                do 
                {
                    try
                    {
                        Console.WriteLine($"Ingrese el valor de la posicion {i+1} de {arraySize}.");
                        value = Convert.ToInt32(Console.ReadLine());
                        if(value > 0)
                        {
                            array[i] = value;
                            isValueValid = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Valor invalido.");
                            isValueValid = false;
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Valor invalido.");
                        isValueValid = false;
                    }
                } while (isValueValid == false);
            }
            return array;
        }
        private static int NumberValidator()
        {
            Console.Clear();
            int objective = 0;
            bool isObjectiveValid = false;
            do 
            {
                Console.WriteLine("Ingrese el numero objetivo de la suma.");
                try 
                {
                    objective = Convert.ToInt32(Console.ReadLine());
                    if (objective > 0)
                    {
                        isObjectiveValid = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Valor no valido.");
                        isObjectiveValid = false;
                    }
                } catch
                {
                    Console.Clear();
                    Console.WriteLine("Valor no valido.");
                    isObjectiveValid = false;
                }
            } while (isObjectiveValid == false);
            return objective;
        }
    }
}
