using System;
namespace CodeExercises.Exercises;

public class ArrayQueue
{
    private int[] items;
    private int rear;
    private int front;
    private int count;

    public ArrayQueue(int capacity)
    {
        items = new int[capacity];
    }

    // items enter from the back of the queue
    public void enqueue(int item)
    {
        if (count == items.Length) throw new ArgumentOutOfRangeException();

        items[rear] = item;
        // rear++ -> this is a noral queue
        // for a circular queue
        rear = (rear + 1) % items.Length;
        count++;
    }

    // items exit from the front of the queue
    public int dequeue()
    {
        var item = items[front];
        items[front] = 0;
        // front++ -> normal queue
        // circular queue:
        front = (front + 1) % items.Length;
        count--;
        return item;
    }
}

