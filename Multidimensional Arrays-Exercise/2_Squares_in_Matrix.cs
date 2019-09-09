using System;
using System.Linq;

namespace _2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var columns = dimensions[1];
            var matrix = new char[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                var rowInput = Console
                    .ReadLine()
                    .Split();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = char.Parse(rowInput[col]);
                }
            }
            var equalCharsSquaresCounter = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    if (matrix[row,col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        equalCharsSquaresCounter++;
                    }
                }
            }
            Console.WriteLine(equalCharsSquaresCounter);
        }
    }
}
