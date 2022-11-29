using System;
namespace CodeExercises.Exercises
{
    public class FizzBuzz
    {
        public static string Run(int number)
        {
            if ((number % 5 == 0) && (number % 3 == 0))
                return "FizzBuzz";

            if (number % 5 == 0)
                return "Buzz";

            if (number % 3 == 0)
                return "Fizz";

            return number.ToString();
        }
    }
}

