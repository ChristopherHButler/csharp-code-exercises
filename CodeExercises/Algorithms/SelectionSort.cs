using System;
namespace CodeExercises.Algorithms;

public class SelectionSort
{
    private static void Sort(int[] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            var minIndex = i;
            for (var j = i; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                    minIndex = j;
            }
            Swap(array, minIndex, i);
        }
    }

    private static void Swap(int[] array, int a, int b)
    {
        var temp = array[b];
        array[a] = array[b];
        array[b] = temp;
    }
}

