using System;
using System.Text;

namespace CodeExercises.Exercises
{
    public class StringReverser
    {
        public string reverse(string input)
        {
            if (input == null)
                throw new ArgumentOutOfRangeException();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            StringBuilder reversed = new StringBuilder();

            while (stack.Count > 0)
            {
                reversed.Append(stack.Pop());
            }
            return reversed.ToString();
        }
    }
}

