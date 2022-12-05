using System;
namespace CodeExercises.Exercises;

public class PriorityQueue
{
    private int[] items = new int[5];
    private int count;

    public void Add(int item)
    {
        if (count == items.Length)
            throw new ArgumentOutOfRangeException();
        var i = 0;
        // shift items
        for (i = count - 1; i >= 0; i--)
        {
            if (items[i] > item)
                items[i + 1] = items[i];
            else break;
        }
        items[i + 1] = item;
        count++;
    }

    public int Remove(int index)
    {
        if (count == 0)
            throw new ArgumentOutOfRangeException();
        return items[--count];
    }
}

