using CodeExercises.DataStructureTests;
using CodeExercises.Exercises;

namespace CodeExercises;

class Program
{
    static void Main(string[] args)
    {
        

        Console.Read();
    }

    private void ExerciseArray()
    {
        CustomArray numbers = new CustomArray(3);
        numbers.Insert(10);
        numbers.Insert(20);
        numbers.Insert(30);
        numbers.Insert(40);
        numbers.removeAt(0);
        numbers.print();
    }
}

