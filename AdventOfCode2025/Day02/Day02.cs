using System.Numerics;
using System.Text;

namespace AdventOfCode2025.Day02;

public class Day02
{
    public static void RunDay2()
    {
        List<long> invalidIDs = new List<long>();
        
        checkBetween(269351, 363914, invalidIDs);
        checkBetween(180, 254, invalidIDs);
        checkBetween(79, 106, invalidIDs);
        checkBetween(771, 1061, invalidIDs);
        checkBetween(4780775, 4976839, invalidIDs);
        checkBetween(7568, 10237, invalidIDs);
        checkBetween(33329, 46781, invalidIDs);
        checkBetween(127083410, 127183480, invalidIDs);
        checkBetween(19624, 26384, invalidIDs);
        checkBetween(9393862801, 9393974421, invalidIDs);
        checkBetween(2144, 3002, invalidIDs);
        checkBetween(922397, 1093053, invalidIDs);
        checkBetween(39, 55, invalidIDs);
        checkBetween(2173488366, 2173540399, invalidIDs);
        checkBetween(879765, 909760, invalidIDs);
        checkBetween(85099621, 85259580, invalidIDs);
        checkBetween(2, 16, invalidIDs);
        checkBetween(796214, 878478, invalidIDs);
        checkBetween(163241, 234234, invalidIDs);
        checkBetween(93853262, 94049189, invalidIDs);
        checkBetween(416472, 519164, invalidIDs);
        checkBetween(77197, 98043, invalidIDs);
        checkBetween(17, 27, invalidIDs);
        checkBetween(88534636, 88694588, invalidIDs);
        checkBetween(57, 76, invalidIDs);
        checkBetween(193139610, 193243344, invalidIDs);
        checkBetween(53458904, 53583295, invalidIDs);
        checkBetween(4674629752, 4674660925, invalidIDs);
        checkBetween(4423378, 4482184, invalidIDs);
        checkBetween(570401, 735018, invalidIDs);
        checkBetween(280, 392, invalidIDs);
        checkBetween(4545446473, 4545461510, invalidIDs);
        checkBetween(462, 664, invalidIDs);
        checkBetween(5092, 7032, invalidIDs);
        checkBetween(26156828, 26366132, invalidIDs);
        checkBetween(10296, 12941, invalidIDs);
        checkBetween(61640, 74898, invalidIDs);
        checkBetween(7171671518, 7171766360, invalidIDs);
        checkBetween(3433355031, 3433496616, invalidIDs);
        
        var total = invalidIDs.Sum();
        Console.WriteLine($"Total invalid IDs: {invalidIDs.Count}");
        Console.WriteLine($"Total number of invalid IDs: {total}");
    }

    public static void checkBetween(long firstNumber, long secondNumber, List<long> invalidIDs)
    {
        long count = firstNumber;

        while (count <= secondNumber)
        {
            if (!validCheck(count))
            {
                invalidIDs.Add(count);
                count++;
            }
            count++;
        }
    }

    public static bool validCheck(long number)
    {
        
        int numberLength = number.ToString().Length;
        if (numberLength % 2 != 0)
        {
            return true;
        }
        
        string numberString = number.ToString();
        int half = numberString.Length / 2;
        
        string frontHalfString = numberString.Substring(0, half);
        string backHalfString = numberString.Substring(half);
        
        int frontHalfInt = int.Parse(frontHalfString);
        int backHalfInt = int.Parse(backHalfString);

        if (frontHalfInt == backHalfInt)
        {
            return false;
        }
        
        return true;
    }
}