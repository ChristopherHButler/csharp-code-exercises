using System;
namespace CodeExercises.Exercises;

/*
 * Fizzbuzz is a classic game.
 * The rules are:
 * - The games should count up, returning the number as a string
 * - If the number is divisible by 3, the program should return 'Fizz'
 * - If the number is divisible by 5, the program should return 'Buzz'
 * - If the number is divisible by both, the program should return 'FizzBuzz'
 */
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

