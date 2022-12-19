using System;
namespace CodeExercises.Algorithms;

public class BucketSort
{
    public static void Sort(int[] array, int numberOfBuckets)
    {
        List<int> x = new List<int>();
        List<List<int>> buckets = new List<List<int>>();

        for (int i = 0; i < numberOfBuckets; i++)
            buckets.Add(new List<int>());
       
        foreach (var item in array)
            buckets[item / numberOfBuckets].Add(item);

        var j = 0;
        foreach (var bucket in buckets)
        {
            QuickSort.Sort(bucket.ToArray());
            foreach (var item in bucket)
                array[j++] = item;
        }
            


    }
}

