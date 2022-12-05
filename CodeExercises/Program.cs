using CodeExercises.DataStructureTests;
using CodeExercises.Exercises;

namespace CodeExercises;

class Program
{
    static void Main(string[] args)
    {
        ArrayQueue arrayQueue = new ArrayQueue(5);

        arrayQueue.enqueue(10);
        arrayQueue.enqueue(20);
        arrayQueue.enqueue(30);
        arrayQueue.ToString();

        Console.Read();
    }
}

