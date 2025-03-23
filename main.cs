using System;
using System.Collections.Generic;

class Program
{
    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    static List<int> PrimeFactors(int n)
    {
        List<int> factors = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            while (IsPrime(i) && n % i == 0)
            {
                factors.Add(i);
                n /= i;
            }
        }
        return factors;
    }

    static int[,] GenerateMagicSquare(int size)
    {
        int[,] square = new int[size, size];
        int row = 0, col = size / 2;
        for (int num = 1; num <= size * size; num++)
        {
            square[row, col] = num;
            int newRow = (row - 1 + size) % size;
            int newCol = (col + 1) % size;
            if (square[newRow, newCol] != 0)
            {
                row = (row + 1) % size;
            }
            else
            {
                row = newRow;
                col = newCol;
            }
        }
        return square;
    }

    static void PrintMatrix(int[,] matrix, int innerSize, int outerSize)
    {
        int n = matrix.GetLength(0);
        string separator = new string('-', n * 4 + outerSize - 1);
        Console.WriteLine(separator);
        for (int i = 0; i < n; i++)
        {
            if (i % innerSize == 0)
            {
                Console.WriteLine(separator);
            }
            for (int j = 0; j < n; j++)
            {
                if (j % innerSize == 0) Console.Write("| ");
                Console.Write(matrix[i, j].ToString().PadLeft(2) + " ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine(separator);
    }

    static void Main()
    {
        while (true)
        {
            Console.Write("Enter an odd number: ");
            int n = int.Parse(Console.ReadLine());
            if (n % 2 == 0)
            {
                Console.WriteLine("The number must be odd!");
                continue;
            }

            List<int> factors = PrimeFactors(n);
            Console.WriteLine("Prime factors: " + string.Join(" ", factors));

            Console.Write("Enter inner size: ");
            int innerSize = int.Parse(Console.ReadLine());
            Console.Write("Enter outer size: ");
            int outerSize = int.Parse(Console.ReadLine());

            if (innerSize * outerSize != n)
            {
                Console.WriteLine($"Invalid sizes! innerSize * outerSize must be equal to {n}");
                continue;
            }

            int[,] magicSquare = GenerateMagicSquare(n);
            Console.WriteLine("\nGenerated Magic Square:");
            PrintMatrix(magicSquare, innerSize, outerSize);

            Console.Write("Do you want to continue? (y/n): ");
            string cont = Console.ReadLine().ToLower();
            if (cont == "n") break;
        }
    }
}
