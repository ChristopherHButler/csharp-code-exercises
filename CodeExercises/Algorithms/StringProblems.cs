using System;
using System.Text;
namespace CodeExercises.Algorithms;

public class StringProblems
{
    public static int CountVowels(string str)
    {
        if (str == null)
            return 0;

        var count = 0;
        string vowels = "aeiou";

        foreach (var ch in str.ToCharArray())
        {
            if (vowels.ToLower().Contains(Char.ToString(ch)))
                count++;
        }
        return count;
    }


    public static string ReverseStr(string str)
    {
        if (str == null)
            return "";

        StringBuilder reversed = new StringBuilder();

        for (var i = str.Length - 1; i >= 0; i--)
        {
            reversed.Append(str[i]);
        }
        return reversed.ToString();
    }


    public static string ReverseWords(string str)
    {
        if (str == null)
            return "";

        var words = str.Split(" ");

        StringBuilder reversed = new StringBuilder();

        for (var i = words.Length - 1; i >= 0; i--)
        {
            reversed.Append(words[i] + " ");
        }
        return reversed.ToString().Trim();
    }


    public static bool AreRotations(string str1, string str2)
    {
        if (str1.Length != str2.Length)
            return false;

        if (!(str1 + str1).Contains(str2))
            return false;

        return false;
    }


    public static string RemoveDuplicates(string str)
    {
        StringBuilder output = new StringBuilder();

        HashSet<char> seen = new HashSet<char>();

        for (int i = 0; i < str.Length; i++)
        {
            if (seen.Contains(str[i]))
            {
                seen.Add(str[i]);
                output.Append(str[i]);
            }
        }
        return output.ToString();
    }


    public static char MostRepeatedChar(string str)
    {
        Dictionary<char, int> frequencies = new Dictionary<char, int>();

        for (int i = 0; i < str.Length; i++)
        {
            if (frequencies.ContainsKey(str[i]))
                frequencies[str[i]]++;
            else
                frequencies[str[i]] = 1;
        }
        return frequencies.Max(val => val).Key;
    }


    public static string Capitalize(string str)
    {
        if (str.Trim() == null)
            return "";

        string[] words = str.Trim().Split(" ");

        for (var i = 0; i < words.Length; i ++)
        {
            words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
        }
        return String.Join(" ", words);
    }


    public static bool AreAnagrams(string first, string second)
    {
        var array1 = first.ToCharArray();
        Array.Sort(array1);

        var array2 = second.ToCharArray();
        Array.Sort(array2);

        return Array.Equals(array1, array2);
    }


    public static bool IsPalindrome(string str)
    {
        // return ReverseStr(str).Equals(str);

        int left = 0;
        int right = str.Length - 1;

        while (left < right)
            if (str[left++] != str[right--])
                return false;
        return true;
    }

}

