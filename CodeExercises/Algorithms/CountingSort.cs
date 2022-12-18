using System;
namespace CodeExercises.Algorithms;

public class CountingSort
{
    public static void Sort(int[] array, int max)
    {
        int[] counts = new int[max + 1];

        foreach (var item in array)
        {
            counts[item]++;
        }

        var k = 0;
        for (var i = 0; i < counts.Length; i++)
        {
            for (var j = 0; j < counts[i]; j++)
            {
                array[k++] = i;
            }
        }

    }
}

