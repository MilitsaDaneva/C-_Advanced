using System;
using System.Linq;

namespace _9_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var side = int.Parse(Console.ReadLine());

            var matrix = new char[side, side];

            var coalNum = 0;
            var minerCurrentRow = -1;
            var minerCurrentCol = -1;

            var commandsArray = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            FillTheMatrix(matrix, side, ref coalNum, ref minerCurrentCol, ref minerCurrentRow);

            for (int i = 0; i < commandsArray.Length; i++)
            {
                var command = commandsArray[i];
                matrix[minerCurrentRow, minerCurrentCol] = '*';

                switch (command)
                {
                    case "up":
                        minerCurrentRow = minerCurrentRow - 1 < 0 ? minerCurrentRow : minerCurrentRow - 1;
                        break;
                    case "down":
                        minerCurrentRow = minerCurrentRow + 1 >= side ? minerCurrentRow : minerCurrentRow + 1;
                        break;
                    case "right":
                        minerCurrentCol = minerCurrentCol + 1 >= side ? minerCurrentCol : minerCurrentCol + 1;
                        break;
                    case "left":
                        minerCurrentCol = minerCurrentCol - 1 < 0 ? minerCurrentCol : minerCurrentCol - 1;
                        break;
                }

                var hittedChar = matrix[minerCurrentRow, minerCurrentCol];
                if (hittedChar == 'e')
                {
                    Console.WriteLine($"Game over! ({minerCurrentRow}, {minerCurrentCol})");
                    return;
                }
                else if (hittedChar == 'c')
                {
                    coalNum--;
                    matrix[minerCurrentRow, minerCurrentCol] = '*';

                    if (coalNum == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minerCurrentRow}, {minerCurrentCol})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{coalNum} coals left. ({minerCurrentRow}, {minerCurrentCol})");
        }

        private static void FillTheMatrix(char[,] matrix, int side, ref int coalNum, ref int minerCurrentCol,
            ref int minerCurrentRow)
        {
            for (int row = 0; row < side; row++)
            {
                var rowInput = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < side; col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (rowInput[col] == 'c')
                    {
                        coalNum++;
                    }
                    if (rowInput[col] == 's')
                    {
                        minerCurrentRow = row;
                        minerCurrentCol = col;
                    }
                }
            }
        }
    }
}
