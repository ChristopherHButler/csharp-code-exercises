using System;
namespace CodeExercises.Exercises;

public class QueueFromStack
{
    private Stack<int> stack1 { get; set; }
    private Stack<int> stack2 { get; set; }

    public void Enqueue(int item)
    {
        stack1.Push(item);
    }

    public int dequeue()
    {
        if (isEmpty())
            throw new ArgumentNullException();

        if (stack2.Count == 0)
        {
            while (stack1.Count != 0)
            {
                stack2.Push(stack1.Pop());
            }
        }
        return stack2.Pop();
    }

    public bool isEmpty()
    {
        return stack1.Count == 0 && stack2.Count == 0;
    }
}

