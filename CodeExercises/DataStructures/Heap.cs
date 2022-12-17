using System;
namespace CodeExercises.DataStructures;

public class Heap
{
    public int[] items { get; set; } = new int[10];
    private int size;

    public void Insert(int value)
    {
        if (IsFull())
            throw new ArgumentOutOfRangeException();
        // store item in next available slot
        // and update (increment) size field
        items[size++] = value;

        BubbleUp();
    }

    public int Remove()
    {
        if (IsEmpty())
            throw new ArgumentOutOfRangeException();

        var root = items[0];

        // remove root node which holds largest value
        // move value of last node into the root node
        items[0] = items[--size];

        BubbleDown();

        return root;
    }

    public bool IsFull()
    {
        return size == items.Length;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    private void BubbleUp()
    {
        // bubble up
        // index of last item
        var index = size - 1;

        while (index > 0 && items[index] > items[GetParentIndex(index)])
        {
            Swap(index, GetParentIndex(index));
            index = GetParentIndex(index);
        }
    }

    private void BubbleDown()
    {
        var index = 0;

        while (index <= size && !IsValidParent(index))
        {
            var largerChildIndex = LargerChildIndex(index);

            Swap(index, largerChildIndex);
            index = largerChildIndex;
        }
    }

    private void Swap(int first, int second)
    {
        var temp = items[first];
        items[first] = items[second];
        items[second] = temp;
    }

    private int GetParentIndex(int index)
    {
        return (index - 1) / 2;
    }

    private bool IsValidParent(int index)
    {
        if (!HasLeftChild(index))
            return true;

        var isValid = items[index] >= LeftChild(index);

        if (HasRightChild(index))
            isValid &= items[index] >= RightChild(index);

        return isValid;
    }

    private int LeftChild(int index)
    {
        return items[LeftChildIndex(index)];
    }

    private int RightChild(int index)
    {
        return items[RightChildIndex(index)];
    }

    private int LeftChildIndex(int index)
    {
        return index * 2 + 1;
    }

    private int RightChildIndex(int index)
    {
        return index * 2 + 2;
    }

    private int LargerChildIndex(int index)
    {
        if (!HasLeftChild(index))
            return index;
        if (!HasRightChild(index))
            return LeftChildIndex(index);
        return (LeftChild(index) > RightChild(index)) ? LeftChildIndex(index) : RightChildIndex(index);
    }

    private bool HasLeftChild(int index)
    {
        return LeftChildIndex(index) <= size;
    }

    private bool HasRightChild(int index)
    {
        return RightChildIndex(index) <= size;
    }
}

