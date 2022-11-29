using CodeExercises.Exercises;

namespace CodeExercises;
class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine(FizzBuzz.Run(i));
        }

        Console.Read();
    }
}

