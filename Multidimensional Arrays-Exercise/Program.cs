using System;
using System.Linq;

namespace _4_Matrix_Shuffling
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
            var matrix = new string[rows, columns];
            FillInMatrix(matrix, rows, columns);
            var command = Console.ReadLine();
            while (command != "END")
            {
                var commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandArray[0] == "swap" && commandArray.Length == 5)
                {
                    int temp;
                    var row1check = int.TryParse(commandArray[1], out temp);
                    var col1check = int.TryParse(commandArray[2], out temp);
                    var row2check = int.TryParse(commandArray[3], out temp);
                    var col2check = int.TryParse(commandArray[4], out temp);
                    if (!row1check || !col1check || !row2check || !col2check)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        var row1 = int.Parse(commandArray[1]);
                        var col1 = int.Parse(commandArray[2]);
                        var row2 = int.Parse(commandArray[3]);
                        var col2 = int.Parse(commandArray[4]);
                        if (row1 < 0 || col1 < 0 || row2 < 0 || col2 < 0 ||
                            row1 >=rows || col1 >= columns || row2 >= rows || col2 >= columns)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            var oldContains = matrix[row2, col2];
                            matrix[row2, col2] = matrix[row1, col1];
                            matrix[row1, col1] = oldContains;
                            PrintTheMatrix(matrix, rows, columns);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine();
            }
        }

        private static void PrintTheMatrix(string[,] matrix, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (col == columns - 1)
                    {
                        Console.WriteLine(matrix[row, col]);
                    }
                    else
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                }
            }
        }

        private static void FillInMatrix(string[,] matrix, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {
                var rowInput = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
        }
    }
}
