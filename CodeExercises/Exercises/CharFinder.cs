using System;
using System.Collections;
namespace CodeExercises.Exercises;

public class CharFinder
{
    public static char FindFirstNonRepeatingChar(string str)
    {
        Dictionary<char, int> dictionary = new Dictionary<char, int>();

        var chars = str.ToCharArray();

        foreach (var ch in chars)
        {
            var count = dictionary.ContainsKey(ch) ? dictionary[ch] : 0;
            dictionary.Add(ch, count + 1);
        }

        foreach (var ch in chars)
        {
            if (dictionary[ch] == 1)
                return ch;
        }
        return Char.MinValue;
    }
}

