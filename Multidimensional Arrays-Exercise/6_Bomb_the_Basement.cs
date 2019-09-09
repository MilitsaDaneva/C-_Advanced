using System;
using System.Linq;

namespace _6_Bomb_the_Basement
{
    class Program
    {
        static void Main(string[] args)
        {
            //row >= bombRow - bombRad
            //row <= bombRow + bombRad
            //col >= bombCol - bombRad + math.abs(bombRow - currRow)
            //col <= bombCol + bombRad - math.abs(bombRow - currRow)

            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var columns = dimensions[1];
            var matrix = new int[rows, columns];
            var bombParametarsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bombRow = bombParametarsArr[0];
            var bombCol = bombParametarsArr[1];
            var bombRadius = bombParametarsArr[2];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (row >= bombRow - bombRadius &&
                        row <= bombRow + bombRadius &&
                        col >= bombCol - bombRadius + Math.Abs(bombRow - row) &&
                        col <= bombCol + bombRadius - Math.Abs(bombRow - row))
                    {
                        matrix[row, col] = 1;
                    }
                    else
                    {
                        matrix[row, col] = 0;
                    }
                }
            }
            for (int row = rows - 1; row >= 0; row--)
            {
                for (int col = columns - 1; col >= 0; col--)
                {
                    if (matrix[row, col] == 1)
                    {
                        for (int subRow = row - 1; subRow >= 0; subRow--)
                        {
                            if (matrix[subRow, col] == 0)
                            {
                                matrix[subRow, col] = 1;
                                matrix[row, col] = 0;
                                break;
                            }
                        }
                    }
                }
            }

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
                        Console.Write(matrix[row, col]);
                    }
                }
            }

        }
    }
}
