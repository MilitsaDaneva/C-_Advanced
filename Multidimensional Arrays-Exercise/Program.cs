using System;
using System.Collections.Generic;
using System.Linq;

namespace _8_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var side = int.Parse(Console.ReadLine());
            var initialMatrix = new int[side, side];
            FillTheMatrix(initialMatrix, side);
            var newMatrix = initialMatrix;
            var bombsInput = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int bomb = 0; bomb < bombsInput.Length; bomb++)
            {
                var bombCoordinates = bombsInput[bomb]
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                var bombRow = bombCoordinates[0];
                var bombCol = bombCoordinates[1];
                if (IsBombAndOnTheMatrix(bombRow, bombCol, side, newMatrix))
                {
                    var bombPower = initialMatrix[bombRow, bombCol];
                    for (int subRow = bombRow - 1; subRow <= bombRow + 1; subRow++)
                    {
                        for (int subCol = bombCol - 1; subCol <= bombCol + 1; subCol++)
                        {
                            if (subRow == bombRow && subCol == bombCol)
                            {
                                newMatrix[subRow, subCol] = 0;
                            }
                            else if (IsBombAndOnTheMatrix(subRow, subCol, side, newMatrix))
                            {
                                newMatrix[subRow, subCol] = initialMatrix[subRow, subCol] - bombPower;
                            }
                        }
                    }
                }
            }
            var bombsList = new List<int>();
            for (int row = 0; row < side; row++)
            {
                for (int col = 0; col < side; col++)
                {
                    bombsList.Add(newMatrix[row, col]);
                }
            }
            var bombsNum = bombsList.Where(x => x > 0).Count();
            var bombsSum = bombsList.Where(x => x > 0).Sum();
            Console.WriteLine($"Alive cells: {bombsNum}");
            Console.WriteLine($"Sum: {bombsSum}");
            for (int row = 0; row < side; row++)
            {
                for (int col = 0; col < side; col++)
                {
                    if (col == side - 1)
                    {
                        Console.WriteLine(newMatrix[row, col]);
                    }
                    else
                    {
                        Console.Write(newMatrix[row, col] + " ");
                    }
                }
            }
        }

        private static bool IsBombAndOnTheMatrix(int row, int col, int side, int[,] newMatrix)
        {
            if (row >= 0 &&
                row < side &&
                col >= 0 &&
                col < side &&
                newMatrix[row, col] > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void FillTheMatrix(int[,] matrix, int side)
        {
            for (int row = 0; row < side; row++)
            {
                var rowInput = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < side; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
        }
    }
}
