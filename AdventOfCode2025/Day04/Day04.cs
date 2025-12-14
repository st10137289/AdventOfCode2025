using AdventOfCode2025.Utils;

namespace AdventOfCode2025.Day04;

public class Day04
{
    public static void Run()
    {
        var path = Paths.FromProjectRoot("Day04", "Input", "day04test.txt");
        var lines = File.ReadAllLines(path);

        string rowString;
        int row = 0;
        int col = 0;

        foreach (var line in lines)
        {
            rowString = line;
            if (row > 0)
            {
                for (int i = 0; i < rowString.Length; i++)
                {
                    row++;
                }

            }

            col++;

        }
        
        char[,] storage = new char[row, col];
        int totalStorage = row * col;

        int wrappingPaper = 0;

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                if (check(r, c, row, col))
                {
                    
                }
                else
                {
                    int adjacentCount = 0;
                    int count = 0;
                    while (count < 8)
                    {
                        if (storage[r - 1, c - 1] == '@')
                        {
                            adjacentCount++;
                        }

                        if (storage[r - 1, c] == '@')
                        {
                            adjacentCount++;
                        }

                        if (storage[r - 1, c + 1] == '@')
                        {
                            adjacentCount++;
                        }

                        if (storage[r, c - 1] == '@')
                        {
                            adjacentCount++;
                        }

                        if (storage[r, c + 1] == '@')
                        {
                            adjacentCount++;
                        }

                        if (storage[r + 1, c - 1] == '@')
                        {
                            adjacentCount++;
                        }
                        if (storage[r + 1, c] == '@')
                        {
                            adjacentCount++;
                        }
                        if (storage[r + 1, c + 1] == '@')
                        {
                            adjacentCount++;
                        }
                        
                        count++;
                        if (adjacentCount > 3)
                        {
                            wrappingPaper++;
                        }
                    }
                }
                
            }
        }

        Console.WriteLine(wrappingPaper);
    }

    public static bool check(int r, int c, int rowLast, int colLast)
    {
        if (r == 0 ||c == 0 || r == rowLast || c == colLast)
        {
            return true;
        }

        return false;
    }
}