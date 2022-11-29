using NUnit.Framework;
using CodeExercises.Exercises;

namespace CodeExercises.UnitTests;

public class Tests
{

    [Test]
    [TestCase(0)]
    [TestCase(15)]
    [TestCase(30)]
    public void FizzBuzz_WhenMod5And3_Returns_FizzBuzz(int number)
    {
        // Arrange & Act
        string result = FizzBuzz.Run(number);

        // Assert
        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }

    [Test]
    [TestCase(5)]
    [TestCase(10)]
    [TestCase(20)]
    public void FizzBuzz_WhenMod5_Returns_Buzz(int number)
    {
        // Arrange & Act
        string result = FizzBuzz.Run(number);

        // Assert
        Assert.That(result, Is.EqualTo("Buzz"));
    }

    [Test]
    [TestCase(3)]
    [TestCase(6)]
    [TestCase(9)]
    public void FizzBuzz_WhenMod3_Returns_Fizz(int number)
    {
        // Arrange & Act
        string result = FizzBuzz.Run(number);

        // Assert
        Assert.That(result, Is.EqualTo("Fizz"));
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(7)]
    public void FizzBuzz_WhenNotMod5Or3_Returns_TheNumber(int number)
    {
        // Arrange & Act
        string result = FizzBuzz.Run(number);

        // Assert
        Assert.That(result, Is.EqualTo(number.ToString()));
    }
}
