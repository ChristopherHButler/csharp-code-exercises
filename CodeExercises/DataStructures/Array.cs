using System;
namespace CodeExercises.DataStructureTests;

public class CustomArray
{
    private int[] items;
    private int count;

    public CustomArray(int length)
    {
        items = new int[length];
    }

    public int indexOf(int item)
    {
        // if we find it, return index
        for (int i = 0; i < count; i++)
        {
            if (items[i] == item)
                return i;
        }
        // otherwise return -1
        return -1;
    }

    public void Insert(int item)
    {
        // if the array is full, resize it
        if (items.Length == count)
        {
            // create a new array (twice the size)
            int[] newItems = new int[count * 2];

            // copy all the existing items
            for (int i = 0; i < items.Length; i++)
            {
                newItems[i] = items[i];
            }
            // set "items" to the new array
            items = newItems;

        }
        // add the new item at the end
        items[count++] = item;
    }

    public void removeAt(int index)
    {
        // validate the index
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException();
        }

        // shift the items to the left to fill the hole
        for (int i = index; i < count; i++)
        {
            items[i] = items[i + 1];
        }
        count--;
    }

    public void print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(items[i]);
        }
    }
}
