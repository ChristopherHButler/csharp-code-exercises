using System;
namespace CodeExercises.DataStructures;

public class SinglyLinkedList
{
    private class Node
    {
        public int Value { get; set; }
        public Node? Next { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }

    private Node first;
    private Node last;
    private int size;

    public SinglyLinkedList() { }

    private bool isEmpty()
    {
        return first == null;
    }

    public int indexOf(int item)
    {
        int index = 0;
        var current = first;
        while (current != null)
        {
            if (current.Value == item) return index;
            current = current.Next;
            index++;
        }
        return -1;
    }

    private bool contains(int item)
    {
        return indexOf(item) != -1;
    }

    public void addFirst(int item)
    {
        var node = new Node(item);
        if (isEmpty())
        {
            first = last = node;
        }
        else
        {
            node.Next = first;
            first = node;
        }
        size++;
    }

    private void addLast(int item)
    {
        var node = new Node(item);
        if (isEmpty())
        {
            first = last = node;
        }
        else
        {
            last.Next = node;
            last = node;
        }
        size++;
    }

    public void deleteFirst()
    {
        if (isEmpty())
            throw new ArgumentNullException();

        if (first == last)
        {
            first = last = null;
        }
        else
        {
            var second = first.Next;
            first.Next = null;
            first = second;
        }
        size--;
    }

    public void deleteLast()
    {
        if (isEmpty())
            throw new ArgumentNullException();

        if (first == last)
        {
            first = last = null;
        }
        else
        {
            var previous = getPrevious(last);
            last = previous;
            last.Next = null;
        }
        size--;
    }

    private Node? getPrevious(Node node)
    {
        var current = first;
        while (current != null)
        {
            if (current.Next == node) return current;
            current = current.Next;
        }
        return null;
    }

    public int Size()
    {
        return size;
    }

    public int[] toArray()
    {
        int[] array = new int[size];
        var current = first;
        var index = 0;
        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Next;
        }
        return array;
    }

    public void reverse()
    {
        if (isEmpty()) return;

        var previous = first;
        var current = first.Next;
        while(current != null)
        {
            var next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        last = first;
        last.Next = null;
        first = previous;

    }

    public int getKthFromEnd(int k)
    {
        var a = first;
        var b = first;

        for (int i = 0; i < k - 1; i++)
        {
            b = b.Next;
            if (b == null)
                throw new ArgumentOutOfRangeException();
        }
            

        while (b != last)
        {
            a = a.Next;
            b = b.Next;
        }
        return a.Value;
    }
}

