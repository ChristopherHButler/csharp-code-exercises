using System;
namespace CodeExercises.Algorithms;

public class BubbleSort
{
    public static void Sort(int[] array)
    {
        bool isSorted;

        for (var i = 0; i < array.Length; i++)
        {
            isSorted = true;
            // the number of comparisons go down by 1
            // each pass
            for (var j = 1; j < array.Length - i; j++)
            {
                if (array[j] < array[j-1])
                {
                    Swap(array, j, j - 1);
                    isSorted = false;
                }
            }
            if (isSorted)
                return;
        }
    }

    private static void Swap(int[] array, int a, int b)
    {
        var temp = array[b];
        array[a] = array[b];
        array[b] = temp;
    }
}

