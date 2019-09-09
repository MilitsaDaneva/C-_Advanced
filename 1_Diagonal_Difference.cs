using System;
using System.Linq;

namespace _1_Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var side = int.Parse(Console.ReadLine());
            var matrix = new int[side, side];
            for (int row = 0; row < side; row++)
            {
                var rowInput = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < side; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
            var primaryDiagonal = 0;
            var secondaryDiagonal = 0;
            for (int row = 0; row < side; row++)
            {
                for (int col = 0; col < side; col++)
                {
                    if (row == col)
                    {
                        primaryDiagonal += matrix[row, col];
                    }
                    if (col + row == side - 1)
                    {
                        secondaryDiagonal += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
