using System;
namespace CodeExercises.Exercises
{
    public class BalancedExpressions
    {
        private List<char> leftBrackets =  new List<char> { '(', '<', '[', '{' };
        private List<char> rightBrackets = new List<char> { ')', '>', ']', '}' };

        public bool isBalancedFirstItr(string input)
        {
            Stack<char> stack = new Stack<char>();

            // opening brackets
            foreach (var c in input.ToCharArray())
            {
                if (c == '(' || c == '<' || c == '[' || c == '{')
                    stack.Push(c);

                if (c == ')' || c == '>' || c == ']' || c == '}')
                {
                    if (stack.Count == 0) return false;
                    var top = stack.Pop();
                    if (
                        (c == ')' && top != '(') ||
                        (c == '<' && top != '>') ||
                        (c == '[' && top != ']') ||
                        (c == '{' && top != '}')) return false;
                }
            }
            return stack.Count == 0;

        }

        public bool isBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            // opening brackets
            foreach (var c in input.ToCharArray())
            {
                if (isLeftBracket(c))
                    stack.Push(c);

                if (isRightBracket(c))
                {
                    if (stack.Count == 0) return false;

                    var top = stack.Pop();
                    if (bracketsMatch(top, c)) return false;
                }
            }
            return stack.Count == 0;

        }

        private bool isLeftBracket(char c)
        {
            return leftBrackets.Contains(c);
        }

        private bool isRightBracket(char c)
        {            
            return rightBrackets.Contains(c);
        }

        private bool bracketsMatch(char left, char right)
        {
            return leftBrackets.IndexOf(left) == rightBrackets.IndexOf(right);
        }
    }
}

