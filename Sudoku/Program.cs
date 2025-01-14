﻿using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            var sudoku = new char[,]
            {
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' }
            };
            userInput(sudoku);
            checkSudoku(sudoku);
            Console.WriteLine(" \n After Solving : \n");
            print(sudoku);
        }
        public static void userInput(char[,] matrix)
        {
            while (true)
            {
            Console.Write("Enter row number : (between 1 to 9) ");
            int row = (Convert.ToInt32(Console.ReadLine())-1);
            Console.Write("Enter column number : (between 1 to 9) ");
            int col = (Convert.ToInt32(Console.ReadLine())-1);
            Console.Write("Enter the value: (between 1 to 9)");
            char value = Convert.ToChar(Console.ReadLine());
            matrix[row, col] = value;
            Console.WriteLine("Do you want to enter another number? (y/n) ");
            char newInput = Convert.ToChar(Console.ReadLine());
                if(char.ToLower(newInput) == 'n')
                {
                    Console.WriteLine(" \n Before Solving : \n");
                    print(matrix);
                    Console.WriteLine("are you sure?  (y/n) ");
                    char check = Convert.ToChar(Console.ReadLine());
                    if (check == 'y') break;
                }
            }
        }

        public static void print(char[,] matrix)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("----------|---------|----------");
                }
                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0)
                    {
                        Console.Write("|");
                    }
                    Console.Write(" " + matrix[i, j]
                            + " ");
                }
                Console.WriteLine();
            }
        }
        public static void checkSudoku(char[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return;
            solve(matrix);
        }
        private static bool solve(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '0')
                    {
                        for (char num = '1'; num <= '9'; num++)
                        {
                            if (isPossible(matrix, row, col, num))
                            {
                                matrix[row, col] = num;
                                if (solve(matrix))
                                    return true;
                                else
                                    matrix[row, col] = '0';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        private static bool isPossible(char[,] matrix, int row, int col, char num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (matrix[i, col] != '0' && matrix[i, col] == num)
                    return false;

                if (matrix[row, i] != '0' && matrix[row, i] == num)
                    return false;

                //check 3*3 block  
                if (matrix[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != '0' && matrix[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == num)
                    return false;
            }
            return true;
        }
    }
}
