using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tymakov
{
    class MainClass
    {
        /// <summary>
        /// Writes "> " in start of the line.
        /// </summary>
        static void Offer()
        {
            Console.Write("> ");
        }

        /// <summary>
        /// Writes a number of the task.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="number">Number of the task.</param>
        static void Message(string message, int number)
        {
            Console.WriteLine("\nLet's check problem #{0}\nThis program {1}\nPress any to continue...", number, message);
            Console.ReadKey();
        }

        /// <summary>
        /// Reads the input int. If input incorrect it ass user to try again.
        /// </summary>
        /// <returns>The input int.</returns>
        /// <param name="positiveFlag">If set to <c>true</c> input must be positive.</param>
        /// <param name="nonZero">If set to <c>true</c> input must not be zero.</param>
        static int ReadInt(bool positiveFlag, bool nonZero)
        {
            int result = 1;
            bool term = true;
            while (term)
            {
                Offer();
                bool convert = int.TryParse(Console.ReadLine(), out result);
                bool positive = (result >= 0) || !positiveFlag;
                bool noZero = (result != 0) || !nonZero;
                if (convert && positive && noZero)
                {
                    term = false;
                }
                else if (!positive)
                {
                    Console.WriteLine("The input must be positive. Please, try again:");
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please, try again:");
                }
            }
            return result;
        }

        /// <summary>
        /// Counts the vowels and consonants in the array.
        /// </summary>
        /// <returns>The array with count of vowels and consonants. 0 - vowels, 1 - consonants</returns>
        /// <param name="chars">Array ot the chars.</param>
        static int[] CountVowelsAndConsonants(char[] chars)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' , 'а', 'у', 'о', 'ы', 'э', 'я', 'ю', 'ё', 'и', 'е' };
            int vowelsCount = 0;
            int consonantsCount = 0;
            foreach(char ch in chars)
            {
                if (char.IsLetter(ch))
                {
                    bool isVowel = false;
                    foreach(char vow in vowels)
                    {
                        if (ch.Equals(vow))
                        {
                            isVowel = true;
                            break;
                        }
                    }

                    if (isVowel)
                    {
                        vowelsCount += 1;
                    }
                    else
                    {
                        consonantsCount += 1;
                    }
                }
            }
            return new int[] { vowelsCount, consonantsCount };
        }

        /// <summary>
        /// Counts the vowels and consonants in the list.
        /// </summary>
        /// <returns>The array with count of vowels and consonants. 0 - vowels, 1 - consonants</returns>
        /// <param name="chars">Array ot the chars.</param>
        static int[] CountVowelsAndConsonantsViaList(List<char> chars)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'а', 'у', 'о',
                'ы', 'э', 'я', 'ю', 'ё', 'и', 'е' };
            int vowelsCount = 0;
            int consonantsCount = 0;
            foreach (char ch in chars)
            {
                if (char.IsLetter(ch))
                {
                    bool isVowel = false;
                    foreach (char vow in vowels)
                    {
                        if (ch.Equals(vow))
                        {
                            isVowel = true;
                            break;
                        }
                    }

                    if (isVowel)
                    {
                        vowelsCount += 1;
                    }
                    else
                    {
                        consonantsCount += 1;
                    }
                }
            }
            return new int[] { vowelsCount, consonantsCount };
        }

        /// <summary>
        /// Multiplies <paramref name="matrix1"/> by <paramref name="matrix2"/>.
        /// </summary>
        /// <throws exception="IndexOutOfRangeException">If count of lines <paramref name="matrix1"/> 
        /// does not equals a count of columns of <paramref name="matrix2"/></throws>
        /// <returns>The multiplied matrix.</returns>
        /// <param name="matrix1">Matrix1.</param>
        /// <param name="matrix2">Matrix2.</param>
        static int[,] MultiplyMatrixes(int[,] matrix1, int[,] matrix2)
        { 
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new IndexOutOfRangeException("These matrixes cannot be multiplied!");
            }

            int l = matrix1.GetLength(0);
            int m = matrix1.GetLength(1);
            int n = matrix2.GetLength(1);
            int[,] result = new int[l, n];
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies <paramref name="matrix1"/> by <paramref name="matrix2"/>.
        /// </summary>
        /// <throws ="IndexOutOfRangeException">If count of lines <paramref name="matrix1"/> 
        /// does not equals a count of columns of <paramref name="matrix2"/></throws>
        /// <returns>The multiplied matrix.</returns>
        /// <param name="matrix1">Matrix1.</param>
        /// <param name="matrix2">Matrix2.</param>
        static LinkedList<LinkedList<int>> MultiplyMatrixesViaLinkedList(LinkedList<LinkedList<int>> matrix1,
         LinkedList<LinkedList<int>> matrix2)
        {
            if (matrix1.First.Value.Count != matrix2.Count)
            {
                throw new IndexOutOfRangeException("These matrixes cannot be multiplied!");
            }

            int l = matrix1.Count;
            int m = matrix1.First.Value.Count;
            int n = matrix2.Count;
            LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();
            for (int i = 0; i < l; i++)
            {
                LinkedList<int> row = new LinkedList<int>();
                for (int j = 0; j < n; j++)
                {
                    int value = 0;
                    for (int k = 0; k < m; k++)
                    {
                        value += matrix1.ElementAt(i).ElementAt(k) * matrix2.ElementAt(k).ElementAt(j);
                    }
                    row.AddLast(value);
                }
                result.AddLast(row);
            }

            return result;
        }
        /// <summary>
        /// Prints the matrix.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.Write("|\n");
            }
        }

        /// <summary>
        /// Prints the matrix.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        static void PrintMatrixViaLinkedList(LinkedList<LinkedList<int>> matrix)
        {
            int n = matrix.Count;
            int m = matrix.First.Value.Count;
            for (int i = 0; i < n; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix.ElementAt(i).ElementAt(j)} ");
                }
                Console.Write("|\n");
            }
        }

        /// <summary>
        /// Gets the array of random month temperatures.
        /// </summary>
        /// <returns>The random month temperatures.</returns>
        static double[] GetRandomMonth()
        {
            double[] month = new double[30];
            Random rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                month[i] = rnd.Next(-4100, 4100) % 100;
            }
            return month;
        }

        /// <summary>
        /// Convert arraies to strings.
        /// </summary>
        /// <returns>The to string.</returns>
        /// <param name="arr">Arr.</param>
        static string ArrayToStr(double[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in arr)
            {
                sb.Append($"{i:f2} ");
            }
            return sb.ToString();
        }

        enum Months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public static void Main(string[] args)
        {
            void Lab1()
            {
                Message("counts number of vovels and conconants if the file", 1);
                Offer();
                string path = Console.ReadLine();
                if (File.Exists(path))
                {
                    string chars = File.ReadAllText(path);
                    int[] counts = CountVowelsAndConsonants(chars.ToCharArray()); // only Russian and English
                    Console.WriteLine($"The count of vowels is: {counts[0]}, consonants: {counts[1]}");
                }
                else
                {
                    Console.WriteLine("There is no such file...");
                }
            }

            void Lab2()
            {
                Message("multiplies matrixes", 2);
                int[,] matrix1 = { { 1, 2 },
                                   { 5, 3 },
                                   { 1, 0 } };
                int[,] matrix2 = { { 5, 6 },
                                   { 9, 3 } };
                Console.WriteLine("The first matrix is:");
                PrintMatrix(matrix1);
                Console.WriteLine("The second matrix is:");
                PrintMatrix(matrix2);
                Console.WriteLine("The multiplied matrix is:");
                int[,] result = MultiplyMatrixes(matrix1, matrix2);
                PrintMatrix(result);
            }

            void Lab3()
            {
                Message("counts an average temperature per every month", 3);
                double[][] year = new double[12][];
                for (int i = 0; i < 12; i++)
                {
                    year[i] = GetRandomMonth();
                }
                double[] average = new double[12];
                Console.WriteLine("The temperatures per year:");
                foreach (double[] i in year)
                {
                    Console.WriteLine(ArrayToStr(i));
                }

                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        average[i] += year[i][j];
                    }
                    average[i] /= 12d;
                }
                Array.Sort(average);
                Console.WriteLine("==============================");
                Console.WriteLine($"The averages temperatures is: {ArrayToStr(average)}");
            }

            void HT1()
            {
                Message("do Lab1 with List<T>", 1);
                List<char> list = new List<char>{ 'g', 'o', 'v', 'n', 'o' };
                int[] counts = CountVowelsAndConsonantsViaList(list);
                Console.WriteLine($"The count of vowels is: {counts[0]}, consonants: {counts[1]}");
            }

            void HT2()
            {
                Message("do Lab2 with LinkedList<LinkedList<T>>", 2);

                LinkedList<LinkedList<int>> matrix1 = new LinkedList<LinkedList<int>>();
                matrix1.AddLast(new LinkedList<int>(new int[] { 1, 2 }));
                matrix1.AddLast(new LinkedList<int>(new int[] { 5, 3 }));
                matrix1.AddLast(new LinkedList<int>(new int[] { 1, 0 }));

                LinkedList<LinkedList<int>> matrix2 = new LinkedList<LinkedList<int>>();
                matrix2.AddLast(new LinkedList<int>(new int[] { 5, 6 }));
                matrix2.AddLast(new LinkedList<int>(new int[] { 9, 3 }));

                Console.WriteLine("The first matrix is:");
                PrintMatrixViaLinkedList(matrix1);
                Console.WriteLine("The second matrix is:");
                PrintMatrixViaLinkedList(matrix2);
                Console.WriteLine("The multiplied matrix is:");
                LinkedList<LinkedList<int>> result = MultiplyMatrixesViaLinkedList(matrix1, matrix2);
                PrintMatrixViaLinkedList(result);
            }   

            void HT3()
            {
                Message("do Lab3 with Dictionary<TKey, TValue>", 3);
                Dictionary<Months, double[]> year = new Dictionary<Months, double[]>
                {
                    [Months.January] = GetRandomMonth(),
                    [Months.February] = GetRandomMonth(),
                    [Months.May] = GetRandomMonth(),
                    [Months.April] = GetRandomMonth(),
                    [Months.March] = GetRandomMonth(),
                    [Months.June] = GetRandomMonth(),
                    [Months.July] = GetRandomMonth(),
                    [Months.August] = GetRandomMonth(),
                    [Months.September] = GetRandomMonth(),
                    [Months.October] = GetRandomMonth(),
                    [Months.November] = GetRandomMonth(),
                    [Months.December] = GetRandomMonth()
                };
                Console.WriteLine("The temperatures per year:");
                foreach(KeyValuePair<Months, double[]> pair in year)
                {
                    Console.WriteLine($"{pair.Key}: {ArrayToStr(pair.Value)}");
                }

                Dictionary<Months, double> average = new Dictionary<Months, double>();
                for (int i = 0; i < 12; i++)
                {
                    average[(Months)i] = year[(Months)i].Average();
                }
                average =  average.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine("==================================");
                Console.WriteLine("The average temperatures per year:");
                foreach (KeyValuePair<Months, double> pair in average)
                {
                    Console.WriteLine($"The average temperature of {pair.Key} is: {pair.Value:f2}");
                }

            }

            bool run = true;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("||===========================<\\\\>===========================||");
                Console.WriteLine("Please, input \"HT\", if you want to check the HT solutions  or type \"exit\" to stop");
                Offer();
                string respond = Console.ReadLine().ToLower().Trim();
                if (respond.Equals("exit"))
                {
                    run = false;
                    continue;
                }
                Console.WriteLine("Please, input a number of a task:");
                int number = ReadInt(true, true);
                if (respond.Equals("ht") || respond.Equals("нт")) // and russian-letters case
                {
                    switch (number)
                    {
                        case 1: HT1(); break;
                        case 2: HT2(); break;
                        case 3: HT3(); break;
                        default: Console.WriteLine("This is not a command or a number of task"); break;
                    }
                }
                else
                {
                    switch (number)
                    {
                        case 1: Lab1(); break;
                        case 2: Lab2(); break;
                        case 3: Lab3(); break;
                        default: Console.WriteLine("This is not a command or a number of task"); break;
                    }
                }
            }
        }
    }
}
