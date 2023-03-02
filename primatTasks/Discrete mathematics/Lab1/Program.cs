using System;
using System.Numerics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("###############################");
            Console.WriteLine("Exercise 1.");
            Console.WriteLine("###############################\n");

            AmountWords(); // 4.826.809

            /*Console.WriteLine("\n###############################");
            Console.WriteLine("Exercise 2.");
            Console.WriteLine("###############################\n");

            CountingRoads();

            Console.WriteLine("\n###############################");
            Console.WriteLine("Exercise 3.");
            Console.WriteLine("###############################\n");

            CountingRoadsAdditionalConditions();

            Console.WriteLine("\n###############################");
            Console.WriteLine("Exercise 4.");
            Console.WriteLine("###############################\n");

            int numberElement = 50;
            Console.WriteLine("Рекуррентная формула: " + RecurrentFormula(numberElement));
            Console.WriteLine("Общее решение: " + GeneralSolution(numberElement));*/
        }

        public static void AmountWords()
        {
            List<string> arr = new List<string> { "к", "о", "м", "б", "и", "н", "а", "т", "о", "р", "и", "к", "а" };

            int length = arr.Count();
            List<string> allWords = new List<string>();

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    for (int k = 0; k < length; k++)
                        for (int l = 0; l < length; l++)
                            for (int m = 0; m < length; m++)
                                for (int n = 0; n < length; n++)
                                    allWords.Add($"{arr[i]}{arr[j]}{arr[k]}{arr[l]}{arr[m]}{arr[n]}");

            Console.WriteLine(allWords.Count());
        }

        public static void CountingRoads()
        {
            int m = 17;
            int n = 12;

            int[,] matrix = new int [m, n];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = 0;

            matrix[0, 0] = 1;

            for(int count = 1; count < m; count++)
            {
                int i = count;
                int j = 0;
                while(i >= 0 && j < n)
                {
                    if (i != 0)
                        matrix[i, j] = matrix[i - 1, j];
                    if (j != 0)
                        matrix[i, j] += matrix[i, j - 1];

                    i--;
                    j++;

                    if (i == 0 && j == 1)
                        matrix[i, j] = 1;
                }
            }

            for(int count = 1; count < n; count++)
            {
                int i = m - 1;
                int j = count;

                while(j < n && i >= 0)
                {
                    if (i != 0)
                        matrix[i, j] = matrix[i - 1, j];
                    if (j != 0)
                        matrix[i, j] += matrix[i, j - 1];

                    i--;
                    j++;
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{matrix[i, j]}, ");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(matrix[m - 1, n - 1]);
        }

        public static void CountingRoadsAdditionalConditions()
        {
            int m = 17;
            int n = 12;

            int[,] matrix = new int[m, n];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = 0;

            matrix[0, 0] = 1;

            for (int count = 1; count < m; count++)
            {
                int i = count;
                int j = 0;
                while (i >= 0 && j < n)
                {
                    if (i != 0)
                        matrix[i, j] = matrix[i - 1, j];
                    if (j != 0 && i != 0)
                        matrix[i, j] += matrix[i - 1, j - 1];

                    i--;
                    j++;

                    if (i == 0 && j == 1)
                        matrix[i, j] = 1;
                }
            }

            for (int count = 1; count < n; count++)
            {
                int i = m - 1;
                int j = count;

                while (j < n && i >= 0)
                {
                    if (i != 0)
                        matrix[i, j] = matrix[i - 1, j];
                    if (j != 0 && i != 0)
                        matrix[i, j] += matrix[i - 1, j - 1];

                    i--;
                    j++;
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{matrix[i, j]}, ");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(matrix[m - 1, n - 1]);
        }

        public static int RecurrentFormula(int k)
        {
            if (k < 1)
                return 1;
            else if (k == 1)
                return -7;
            else
            {
                int result = 5 * RecurrentFormula(k - 1) + 6 * RecurrentFormula(k - 2);
                return result;
            } 
        }
        public static int GeneralSolution(int k)
        {
            double result = ((Math.Pow(13 * (-1), k) - Math.Pow(6, k + 1)) / 7);
            int res = (int)Math.Round(result);
            return res;
        }
    }
}