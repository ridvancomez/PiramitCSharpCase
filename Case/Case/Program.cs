using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Case
{
    internal class Program
    {
        //Algoritma için gereken sayılar
        private static List<int> orthogonalTriangleNumbers = new List<int>{215, 193, 124, 117, 237, 442, 218, 935, 347, 235, 320, 804, 522, 417,
                                                         345, 229, 601, 723, 835, 133, 124, 248, 202, 277, 433, 207, 263, 257,
                                                         359, 464, 504, 528, 516, 716, 871, 182, 461, 441, 426, 656, 863, 560,
                                                         380, 171, 923, 381, 348, 573, 533, 447, 632, 387, 176, 975, 449, 223,
                                                         711, 445, 645, 245, 543, 931, 532, 937, 541, 444, 330, 131, 333, 928,
                                                         377, 733, 017, 778, 839, 168, 197, 197, 131, 171, 522, 137, 217, 224,
                                                         291, 413, 528, 520, 227, 229, 928, 223, 626, 034, 683, 839, 053, 627,
                                                         310, 713, 999, 629, 817, 410, 121, 924, 622, 911, 233, 325, 139, 721,
                                                         218, 253, 223, 107, 233, 230, 124, 233};

        internal static List<Number> Numbers = new();

        internal static int MatrixNumber;
        static void Main(string[] args)
        {
            FindTheMatrixNumber();
            UseTheNumberType();
            CalculateHighNumber();
            PrintTheNumber();
            Calculate.FindHighScore();
            Calculate.HighScores.Sort();
            Calculate.HighScores.Reverse();
            Console.WriteLine("Answer : " + Calculate.HighScores[0]);
        }

        //En fazla kaç adet basamak olduğunu öğreniyoruz
        private static void FindTheMatrixNumber()
        {
            int total = 0;
            for (int i = 0; i < orthogonalTriangleNumbers.Count; i++)   
            {
                total += i;
                if (total == orthogonalTriangleNumbers.Count)
                {
                    MatrixNumber = i;
                    break;
                }
            }
        }

        //Sayıları Number tipinde işliyoruz
        private static void UseTheNumberType()
        {
            int orthogonalNumberIndex = 0;
            for (int i = 1; i <= MatrixNumber; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    int value = orthogonalTriangleNumbers[orthogonalNumberIndex];
                    Number n = new Number(value, i, j, IsPrimeNumber(value));
                    Numbers.Add(n);
                    orthogonalNumberIndex++;
                }
            }
        }

        private static void CalculateHighNumber()
        {
            foreach (var number in Numbers) Calculate.RootNumber = number;
        }

        private static void PrintTheNumber()
        {
            for (int i = 1; i <= MatrixNumber; i++)
            {
                for (int j = 0; j < MatrixNumber - i; j++)
                {
                    Console.Write("   ");
                }
                foreach (var number in Numbers)
                {

                    if (number.CoordinatOne == i)
                    {
                        Console.Write(number.Value.ToString("000") + "   ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static bool IsPrimeNumber(int value)
        {
            for (int i = 2; i < value; i++)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }

    }


}

