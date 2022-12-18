using System;
namespace CodeExercises.Algorithms;

public class MergeSort
{
    public static void Sort(int[] array)
    {
        if (array.Length < 2)
            return;

        // divide array in half
        var middle = array.Length / 2;

        int[] left = new int[middle];

        for (var i = 0; i < middle; i++)
        {
            left[i] = array[i];
        }

        int[] right = new int[array.Length - middle];

        for (var i = middle; i < array.Length; i++)
        {
            right[i - middle] = array[i];
        }

        // sort each
        Sort(left);
        Sort(right);

        // merge the result
        Merge(left, right, array);
    }

    private static void Merge(int[] left, int[] right, int[] result)
    {
        var i = 0;
        var j = 0;
        var k = 0;

        while(i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
                result[k++] = left[i++];
            else
                result[k++] = right[j++];
        }

        while (i < left.Length)
            result[k++] = left[i++];

        while (j < right.Length)
            result[k++] = right[j++];
    }
}

