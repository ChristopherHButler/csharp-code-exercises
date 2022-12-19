using System;
namespace CodeExercises.Algorithms;

public class QuickSort
{
    public static void Sort(int[] array)
    {
        Sort(array, 0, array.Length - 1);
    }

    private static void Sort(int[] array, int start, int end)
    {
        if (start >= end)
            return;

        var boundary = Partition(array, start, end);

        // sort left
        Sort(array, start, boundary - 1);

        // sort right
        Sort(array, boundary + 1, end);
    }

    private static int Partition(int[] array, int start, int end)
    {
        var pivot = array[end];
        var boundary = start - 1;

        for (var i = start; i <= end; i++)
        {
            if (array[i] <= pivot)
                Swap(array, i, boundary++);
        }
        return boundary;
    }


    private static void Swap(int[] array, int a, int b)
    {
        var temp = array[b];
        array[a] = array[b];
        array[b] = temp;
    }
}

