using System.Text;

namespace AdventOfCode2025.Days;

/*
--- Day 1: Secret Entrance ---
The Elves have good news and bad news.

The good news is that they've discovered project management! This has given them the tools they need to prevent their usual Christmas emergency. 
For example, they now know that the North Pole decorations need to be finished soon so that other critical tasks can start on time.
The bad news is that they've realized they have a different emergency: according to their resource planning, none of them have any time left to decorate the North Pole!
To save Christmas, the Elves need you to finish decorating the North Pole by December 12th.
Collect stars by solving puzzles. Two puzzles will be made available on each day; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!
You arrive at the secret entrance to the North Pole base ready to start decorating. Unfortunately, the password seems to have been changed, so you can't get in. 
A document taped to the wall helpfully explains:
"Due to new security protocols, the password is locked in the safe below. Please see the attached document for the new combination."
The safe has a dial with only an arrow on it; around the dial are the numbers 0 through 99 in order. As you turn the dial, it makes a small click noise as it reaches each number.
The attached document (your puzzle input) contains a sequence of rotations, one per line, which tell you how to open the safe. 
A rotation starts with an L or R which indicates whether the rotation should be to the left (toward lower numbers) or to the right (toward higher numbers). 
Then, the rotation has a distance value which indicates how many clicks the dial should be rotated in that direction.
So, if the dial were pointing at 11, a rotation of R8 would cause the dial to point at 19. After that, a rotation of L19 would cause it to point at 0.
Because the dial is a circle, turning the dial left from 0 one click makes it point at 99. Similarly, turning the dial right from 99 one click makes it point at 0.
So, if the dial were pointing at 5, a rotation of L10 would cause it to point at 95. After that, a rotation of R5 could cause it to point at 0.
The dial starts by pointing at 50.
You could follow the instructions, but your recent required official North Pole secret entrance security training seminar taught you that the safe is actually a decoy. 
The actual password is the number of times the dial is left pointing at 0 after any rotation in the sequence.

For example, suppose the attached document contained the following rotations:

L68
L30
R48
L5
R60
L55
L1
L99
R14
L82
Following these rotations would cause the dial to move as follows:

The dial starts by pointing at 50.
The dial is rotated L68 to point at 82.
The dial is rotated L30 to point at 52.
The dial is rotated R48 to point at 0.
The dial is rotated L5 to point at 95.
The dial is rotated R60 to point at 55.
The dial is rotated L55 to point at 0.
The dial is rotated L1 to point at 99.
The dial is rotated L99 to point at 0.
The dial is rotated R14 to point at 14.
The dial is rotated L82 to point at 32.
Because the dial points at 0 a total of three times during this process, the password in this example is 3.

Analyze the rotations in your attached document. What's the actual password to open the door?

To begin, get your puzzle input.
*/

// https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-file
//https://stackoverflow.com/questions/8037070/whats-the-fastest-way-to-read-a-text-file-line-by-line

public class Day01
{
    public static void Run()
    {
        string filePath1 = "";
        try
        {
            
            // This opens the text file using a stream reader
            using StreamReader reader = new StreamReader(@"C:\Users\Porter\RiderProjects\AdventOfCode2025\AdventOfCode2025\Input\day1.txt");

            // read the stream as a string
            string text = reader.ReadToEnd();

            //Write the text to Console 
            //Console.WriteLine(text);
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        
        int lineCounter = 0;
        
        int zeroCounter = 0;
        int zeroCounterCrossed = 0;
        
        int leftCounter = 0;
        int rightCounter = 0;
        
        int startingValue = 50;

        string temp;
        
        int tempLength = 0;
        
        int tempValue = 0;
        
        Console.WriteLine("- The dial starts by pointing at 50.");
        var lines = File.ReadAllLines(@"C:\Users\Porter\RiderProjects\AdventOfCode2025\AdventOfCode2025\testData\day1test.txt");
        foreach (var line in lines)
        {
            var sb = new StringBuilder();
            
            temp = line;
            tempLength = temp.Length;

            for (int i = 1; i < line.Length; i++)
            {
                sb.Append(temp[i]);
            }
            
            tempValue = Int32.Parse(sb.ToString());
            // Console.WriteLine(sb.ToString() + " This is the int:" + tempValue.ToString());

            int howmany = 0;
            if (line.Contains("R"))
            {
                
                startingValue += tempValue;
                
                while (startingValue > 99)
                {
                    
                    startingValue -= 100;
                    zeroCounterCrossed++; // Added this line for part 2 - to solve part 1 remove this line
                    
                }
                
            }
            if (line.Contains("L"))
            {
                
                startingValue -= tempValue;
                if (startingValue == 0)
                {
                    zeroCounterCrossed++;
                }
                while (startingValue < 0)
                {
                    
                    startingValue += 100;
                    zeroCounterCrossed++; // Added this line for part 2 - to solve part 1 remove this line
                    
                }
                
            }
            
            var dailRoations = new StringBuilder();
            dailRoations.AppendLine("- The dial is rotated " + line + " to point at "  + startingValue + ".");
            if (howmany != 0)
            {
                dailRoations.AppendLine("; during this rotation, it points at 0 " + "[  " + howmany+"  ]");
            }
            
            Console.WriteLine(dailRoations);

            if (startingValue == 0)
            {
                zeroCounter++; 
            }
          
            
        }

        int dail = 50;
        int rotation;
        int zero = 0;
        
        Console.WriteLine("Total Zeros: " + zeroCounter + "\nTotal Zeros that we crossed: " + zeroCounterCrossed + "\nCrossed - Total: " + (zeroCounterCrossed - zeroCounter) );
        
        var linesP2 = File.ReadAllLines(@"C:\Users\Porter\RiderProjects\AdventOfCode2025\AdventOfCode2025\Input\day1.txt");
        foreach (var lineP2 in linesP2)
        {
            var sb = new StringBuilder();
            temp = lineP2;
            for (int i = 1; i < lineP2.Length; i++)
            {
                sb.Append(temp[i]);
            }
            rotation = Int32.Parse(sb.ToString());
            
            int loops = rotation / 100;
            int remainder = rotation % 100;
            
            zero += loops;

            int start = dail; 
                
            if (lineP2.Contains("R"))
            {
                // remainder hits 0 if we cross 99 -> 0
                if (remainder != 0 && start != 0 && start + remainder >= 100)
                {
                    zero++;
                }
                
                dail = start + remainder;
                
                while (dail > 99)
                {
                  
                    dail -= 100;
                }
                
            }
            if (lineP2.Contains("L"))
            {
                // remainder hits 0 if we move left at least 'start' clicks
                // (includes the "land exactly on 0" case)
                if (remainder != 0 && start != 0 && remainder >= start)
                {
                    zero++;
                }

                dail = start - remainder;
                
                while (dail < 0)
                {
                    
                    dail += 100;
                    
                    
                }
                
            }
            

        }
        Console.WriteLine(zero);
    }
    
    /*
    --- Part Two ---
You're sure that's the right password, but the door won't open. You knock, but nobody answers. You build a snowman while you think.

As you're rolling the snowballs for your snowman, you find another security document that must have fallen into the snow:

"Due to newer security protocols, please use password method 0x434C49434B until further notice."

You remember from the training seminar that "method 0x434C49434B" means you're actually supposed to count the number of times any click causes the dial to point at 0, regardless of whether it happens during a rotation or at the end of one.

Following the same rotations as in the above example, the dial points at zero a few extra times during its rotations:

The dial starts by pointing at 50.
The dial is rotated L68 to point at 82; during this rotation, it points at 0 once.
The dial is rotated L30 to point at 52.
The dial is rotated R48 to point at 0.
The dial is rotated L5 to point at 95.
The dial is rotated R60 to point at 55; during this rotation, it points at 0 once.
The dial is rotated L55 to point at 0.
The dial is rotated L1 to point at 99.
The dial is rotated L99 to point at 0.
The dial is rotated R14 to point at 14.
The dial is rotated L82 to point at 32; during this rotation, it points at 0 once.
In this example, the dial points at 0 three times at the end of a rotation, plus three more times during a rotation. So, in this example, the new password would be 6.

Be careful: if the dial were pointing at 50, a single rotation like R1000 would cause the dial to point at 0 ten times before returning back to 50!

Using password method 0x434C49434B, what is the password to open the door?
    
     */
    

    
    
    

}