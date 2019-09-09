using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var columns = dimensions[1];
            var matrix = new char[rows, columns];
            var snakeName = Console.ReadLine();
            var snakeQueue = new Queue<char>(snakeName);
            FillTheMatrix(matrix, rows, columns, snakeQueue);
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


        private static void FillTheMatrix(char[,] matrix, int rows, int columns, Queue<char> snakeQueue)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var currentChar = snakeQueue.Dequeue();
                    matrix[row, col] = currentChar;
                    snakeQueue.Enqueue(currentChar);
                }
            }
        }
    }
}
