using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimessionArray = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rows = dimessionArray[0];
            var columns = dimessionArray[1];

            var matrix = new char[rows][];

            var playerRow = -1;
            var playerCol = -1;

            var bunniesList = new List<Bunny>();

            var gameOver = false;
            var win = false;

            FillTheMatrix(matrix, rows, columns, ref playerRow, ref playerCol, bunniesList);

            var commandsArray = Console
                .ReadLine()
                .ToCharArray();

            foreach (var command in commandsArray)
            {
                switch (command)
                {
                    case 'U':
                        PlayerCurrentMoving(matrix, ref gameOver, playerRow - 1, playerCol,
                            ref playerRow, ref playerCol, rows, columns, ref win);
                        break;
                    case 'D':
                        PlayerCurrentMoving(matrix, ref gameOver, playerRow + 1, playerCol,
                            ref playerRow, ref playerCol, rows, columns, ref win);
                        break;
                    case 'L':
                        PlayerCurrentMoving(matrix, ref gameOver, playerRow, playerCol - 1,
                            ref playerRow, ref playerCol, rows, columns, ref win);
                        break;
                    case 'R':
                        PlayerCurrentMoving(matrix, ref gameOver, playerRow, playerCol + 1,
                            ref playerRow, ref playerCol, rows, columns, ref win);
                        break;
                }

                BunnySpreading(matrix, bunniesList, ref gameOver, rows, columns, ref win);

                bunniesList.Clear();

                FillBunnyList(matrix, bunniesList);

                if (gameOver)
                {
                    break;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }

            if (win)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        private static void FillBunnyList(char[][] matrix, List<Bunny> bunniesList)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        var currentBunny = new Bunny()
                        { rowB = row, colB = col };
                        bunniesList.Add(currentBunny);
                    }
                }
            }
        }

        private static void BunnySpreading(char[][] matrix, List<Bunny> bunniesList, ref bool gameOver, int rows, 
            int columns, ref bool win)
        {
            foreach (var bunny in bunniesList)
            {
                for (int subRow = Math.Max(0, bunny.rowB - 1); subRow <= Math.Min(rows - 1, bunny.rowB + 1); subRow++)
                {
                    BunnySpreadingAttack(matrix, subRow, bunny.colB, ref gameOver, ref win);
                }
                for (int subCol = Math.Max(0, bunny.colB - 1); subCol <= Math.Min(columns - 1, bunny.colB + 1); subCol++)
                {
                    BunnySpreadingAttack(matrix, bunny.rowB, subCol, ref gameOver, ref win);
                }
            }
        }

        private static void BunnySpreadingAttack(char[][] matrix, int row, int col, ref bool gameOver, ref bool win)
        {
            if (matrix[row][col] == 'P')
            {
                matrix[row][col] = 'B';
                gameOver = true;
                win = false;
            }
            else
            {
                matrix[row][col] = 'B';
            }
        }

        private static void PlayerCurrentMoving(char[][] matrix, ref bool gameOver, int NewRow, int NewCol,
            ref int currentPlayerRow, ref int currentPlayerCol, int rows, int columns, ref bool win)
        {
            matrix[currentPlayerRow][currentPlayerCol] = '.';
            if (NewRow >= 0 && NewRow < rows &&
                NewCol >= 0 && NewCol < columns)
            {
                if (matrix[NewRow][NewCol] == 'B')
                {
                    gameOver = true;
                    win = false;
                }
                else if (matrix[NewRow][NewCol] == '.')
                {
                    matrix[NewRow][NewCol] = 'P';
                }
                currentPlayerRow = NewRow;
                currentPlayerCol = NewCol;
            }
            else
            {
                gameOver = true;
                win = true;
            }
        }

        private static void FillTheMatrix(char[][] matrix, int rows, int columns, ref int playerRow,
            ref int playerCol, List<Bunny> bunniesList)
        {
            for (int row = 0; row < rows; row++)
            {
                var rowInput = Console.ReadLine().ToCharArray();
                if (rowInput.Contains('P'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(rowInput, 'P');
                }
                if (rowInput.Contains('B'))
                {
                    for (int i = 0; i < rowInput.Length; i++)
                    {
                        if (rowInput[i] == 'B')
                        {
                            var currentBunny = new Bunny()
                            { rowB = row, colB = i };
                            bunniesList.Add(currentBunny);
                        }
                    }
                }
                matrix[row] = rowInput;
            }
        }
    }

    class Bunny
    {
        public int rowB { get; set; }
        public int colB { get; set; }
    }

}
