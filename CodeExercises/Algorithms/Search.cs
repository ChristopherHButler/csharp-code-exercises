using System;
namespace CodeExercises.Algorithms;

public class Search
{

    public static int LinearSearch(int[] array, int target)
    {
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
                return i;
        }
        return -1;
    }


    public static int BinarySearchRec(int[] array, int target)
    {
        return BinarySearchRec(array, target, 0, array.Length);
    }

    private static int BinarySearchRec(int[] array, int target, int left, int right)
    {
        if (right < left)
            return -1;

        int middle = (left + right) / 2;

        if (array[middle] == target)
            return middle;

        if (target < array[middle])
            return BinarySearchRec(array, target, left, middle - 1);

        return BinarySearchRec(array, target, middle + 1, right);
    }

    public int BinarySearch(int[] array, int target)
    {
        var left = 0;
        var right = array.Length - 1;

        while (left <= right)
        {
            var middle = (left + right) / 2;

            if (array[middle] == target)
                return middle;

            if (target < array[middle])
                right = middle - 1;
            else
                left = middle + 1;
        }
        return -1;
    }


    public static int TernarySearch(int[] array, int target)
    {
        return TernarySearch(array, target, 0, array.Length - 1);
    }

    private static int TernarySearch(int[] array, int target, int left, int right)
    {
        if (left > right)
            return -1;

        int partitionSize = (right - left) / 3;
        int mid1 = left + partitionSize;
        int mid2 = right - partitionSize;

        if (array[mid1] == target)
            return mid1;

        if (array[mid2] == target)
            return mid2;

        if (target < array[mid1])
            return TernarySearch(array, target, left, mid1 - 1);
        if (target > array[mid2])
            return TernarySearch(array, target, mid2 + 1, right);
        return TernarySearch(array, target, mid1 + 1, mid2 - 1);
    }


    public static int JumpSearch(int[] array, int target)
    {
        int blockSize = (int)Math.Sqrt(array.Length);
        int start = 0;
        int next = blockSize;

        while (start < array.Length && array[next - 1] < target)
        {
            start = next;
            next += blockSize;

            if (next > array.Length)
                next = array.Length;
        }

        for (var i = start; i < next; i++)
        {
            if (array[i] == target)
                return i;
        }

        return -1;
    }


    public static int ExponentialSearch(int[] array, int target)
    {
        int bound = 1;

        while (bound < array.Length && array[bound] < target)
        {
            bound *= 2;
        }

        int left = bound / 2;
        int right = Math.Min(bound, array.Length - 1);

        return BinarySearchRec(array, target, left, right);
    }



}

