using System;
namespace CodeExercises.Exercises
{
    public class QueueReverse
    {
        public static void reverse(Queue<int> queue)
        {
            if (queue == null || queue.Count == 0) return;

            Stack<int> stack = new Stack<int>();
            while (queue.Count != 0)
            {
                stack.Push(queue.FirstOrDefault());
            }
            while (stack.Count != 0)
            {
                queue.Append(stack.Pop());
            }
        }
    }
}

