using System;
using System.Linq;

namespace _7_Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var side = int.Parse(Console.ReadLine());
            var matrix = new char[side, side];
            FillTheMatrix(side, matrix);
            var removedKnight = 0;
            var noKnightAttacked = false;
            while (!noKnightAttacked)
            {
                var maxKnight = 0;
                var maxRow = 0;
                var maxCol = 0;

                for (int row = 0; row < side; row++)
                {
                    for (int col = 0; col < side; col++)
                    {
                        var currentAttacked = 0;
                        if (matrix[row, col] == 'K')
                        {
                            CheckForAttacks(matrix, row, col, ref currentAttacked);
                        }
                        if (currentAttacked > maxKnight)
                        {
                            maxKnight = currentAttacked;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }
                if (maxKnight > 0)
                {
                    matrix[maxRow, maxCol] = '0';
                    removedKnight++;
                }
                else if (maxKnight == 0)
                {
                    noKnightAttacked = true;
                }
            }
            Console.WriteLine(removedKnight);
        }

        private static void CheckForAttacks(char[,] matrix, int row, int col, ref int currentAttacked)
        {            
            if (row >= 2 && col >= 1 && matrix[row - 2, col - 1] == 'K')
            {
                currentAttacked++;
            }
            if (row >= 2 && col < matrix.GetLength(1) - 1 && matrix[row - 2, col + 1] == 'K')
            {
                currentAttacked++;
            }
            if (row >= 1 && col >= 2 && matrix[row - 1, col - 2] == 'K')
            {
                currentAttacked++;
            }
            if (row >= 1 && col < matrix.GetLength(1) - 2 && matrix[row - 1, col + 2] == 'K')
            {
                currentAttacked++;
            }
            if (row < matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 2 && matrix[row + 1, col + 2] == 'K')
            {
                currentAttacked++;
            }
            if (row < matrix.GetLength(0) - 1 && col >= 2 && matrix[row + 1, col - 2] == 'K')
            {
                currentAttacked++;
            }
            if (row < matrix.GetLength(0) - 2 && col < matrix.GetLength(1) - 1 && matrix[row + 2, col + 1] == 'K')
            {
                currentAttacked++;
            }
            if (row < matrix.GetLength(0) - 2 && col >= 1 && matrix[row + 2, col - 1] == 'K')
            {
                currentAttacked++;
            }
        }

        private static void FillTheMatrix(int side, char[,] matrix)
        {
            for (int row = 0; row < side; row++)
            {
                var rowInput = Console
                    .ReadLine()
                    .Trim()
                    .ToCharArray();
                for (int col = 0; col < side; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
        }
    }
}
