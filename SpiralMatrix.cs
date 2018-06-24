using System;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] spiralMatrix = GetSpiralMatrix(size);

            for (int i = 0; i < spiralMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < spiralMatrix.GetLength(1); j++)
                {
                    Console.Write(spiralMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] GetSpiralMatrix(int size)
        {
            var matrix = new int[size, size];
            var rows = 0;
            var columns = 0;
            var direction = "right";

            for (int i = 1; i <= size * size; i++)
            {
                if (direction.Equals("right") && (columns > size - 1 || matrix[rows, columns] != 0))
                {
                    columns--;
                    rows++;
                    direction = "down";
                }

                if (direction.Equals("down") && (rows > size - 1 || matrix[rows, columns] != 0))
                {
                    rows--;
                    columns--;
                    direction = "left";
                }

                if (direction.Equals("left") && (columns < 0 || matrix[rows, columns] != 0))
                {
                    rows--;
                    columns++;
                    direction = "up";
                }

                if (direction.Equals("up") && (rows < 0 || matrix[rows, columns] != 0))
                {
                    rows++;
                    columns++;
                    direction = "right";
                }

                matrix[rows, columns] = i;

                switch (direction)
                {
                    case "right": columns++; break;
                    case "down": rows++; break;
                    case "left": columns--; break;
                    case "up": rows--; break;
                }
            }

            return matrix;
        }
    }
}
