using System;
using System.Linq;

namespace _3_Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var columns = dimensions[1];
            var matrix = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                var rowInput = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
            var maximalSum = int.MinValue;
            var maxRow = 0;
            var maxCol = 0;
            for (int row = 0; row < rows - 3 + 1; row++)
            {
                for (int col = 0; col < columns - 3 + 1; col++)
                {
                    //var currentSum 
                    //    = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] 
                    //    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    //    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    var currentSum = 0;
                    for (int subRow = row; subRow < row + 3; subRow++)
                    {
                        for (int subCol = col; subCol < col + 3; subCol++)
                        {
                            currentSum += matrix[subRow, subCol];
                        }
                    }
                    if (currentSum > maximalSum)
                    {
                        maximalSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maximalSum}");
            for (int row = maxRow; row < maxRow + 3; row++)
            {
                for (int col = maxCol; col < maxCol + 3; col++)
                {
                    if (col == maxCol + 3 - 1)
                    {
                        Console.WriteLine(matrix[row, col]);
                    }
                    else
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                }
            }
            //for (int row = maximalSumRowIndex; row < maximalSumRowIndex + 3; row++)
            //{
            //    var currentRow = new int[3];
            //    var index = 0;
            //    for (int col = maximalSumColIndex; col < maximalSumColIndex + 3; col++)
            //    {
            //        currentRow[index] = matrix[row, col];
            //        index++;
            //    }
            //    Console.WriteLine(string.Join(" ", currentRow));
            //}
            //Console.WriteLine
            //($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]} {matrix[maxRow, maxCol + 2]}");
            //Console.WriteLine
            //($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]} {matrix[maxRow + 1, maxCol + 2]}");
            //Console.WriteLine
            //($"{matrix[maxRow + 2, maxCol]} {matrix[maxRow + 2, maxCol + 1]} {matrix[maxRow + 2, maxCol + 2]}");
        }
    }
}
