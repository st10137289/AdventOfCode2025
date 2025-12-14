using System.Numerics;
using AdventOfCode2025.Utils;

namespace AdventOfCode2025.Day03;

public class Day03
{
 public static void Run()
 
 {
     BigInteger totalJolts = 0;

     var path = Paths.FromProjectRoot("Day03", "Input", "day03.txt");
     var lines = File.ReadAllLines(path);

     foreach (var lineRaw in lines)
     {
         var line = lineRaw.Trim();
         if (string.IsNullOrEmpty(line)) continue;

         const int L = 12;
         if (line.Length < L)
             throw new InvalidOperationException($"Line too short for part 2: '{line}'");

         int k = line.Length - L; // how many digits we must remove

         var stack = new List<char>(line.Length);

         foreach (char c in line)
         {
             // c is '1'..'9' per problem statement
             while (k > 0 && stack.Count > 0 && stack[^1] < c)
             {
                 stack.RemoveAt(stack.Count - 1);
                 k--;
             }
             stack.Add(c);
         }

         // If we still need to remove digits, remove from the end
         while (k > 0 && stack.Count > 0)
         {
             stack.RemoveAt(stack.Count - 1);
             k--;
         }

         // Take the first 12 digits as the max joltage output for this bank
         string best12 = new string(stack.Take(L).ToArray());

         Console.WriteLine(best12);

         totalJolts += BigInteger.Parse(best12);
     }

     Console.WriteLine("Total Jolts: " + totalJolts);
 }
 /*
 {

         int firstNumber = battery[0]; // This is temporaly set
         int firstNumberPosition = 0;

         //first run
         for (int i = 0; i < battery.Length; i++)
         {
             if (i < battery.Length -1)
             {
                 if (battery[i] > firstNumber)
                 {
                     firstNumber = battery[i];
                     firstNumberPosition = i;
                 }
             }
         }
         int secondNumberPosition = firstNumberPosition + 1;
         int secondNumber = battery[secondNumberPosition];

         //second run
         for (int i = secondNumberPosition; i < battery.Length; i++)
         {
             if (firstNumberPosition == battery.Length - 2)
             {
                 secondNumber = battery[battery.Length - 1];
             }
             if (battery[i] > secondNumber)
             {
                 secondNumber = battery[i];
                 secondNumberPosition = i;
             }
         }
          
 }   
*/
 
 // https://www.geeksforgeeks.org/dsa/concatenate-the-array-of-elements-into-a-single-element/  ( 14 December 2025)
 static int ConcatenateArr(int[] arr, int N)
 {
    
     // Stores the resulting integer value
     int ans = arr[0];

     // Traverse the array arr[]
     for(int i = 1; i < N; i++)
     {
        
         // Stores the count of digits of
         // arr[i]
         int l = (int)Math.Floor(Math.Log10(arr[i]) + 1);

         // Update ans
         ans = ans * (int)Math.Pow(10, l);

         // Increment ans by arr[i]
         ans += arr[i];
     }
    
     // Return the ans
     return ans;
 }

}

/*
int a = 1039;
int b = 7056;

int newNumber = int.Parse(a.ToString() + b.ToString())
*/