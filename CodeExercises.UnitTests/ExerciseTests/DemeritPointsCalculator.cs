using CodeExercises.Exercises;

namespace CodeExercises.UnitTests;

public class DemeritPointsCalculatorTests
{
    [Test]
    [TestCase(-1)]
    [TestCase(301)]
    public void DemeritPointsCalculator_WhenSpeedIsOutOfRange_ThrowsArgumentOutOfRangeException(int speed)
    {
        // Arrange, Act, Assert
        Assert.That(() => DemeritPointsCalculator.Run(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    [TestCase(0, 0)]
    [TestCase(64, 0)]
    [TestCase(65, 0)]
    [TestCase(66, 0)]
    [TestCase(70, 1)]
    [TestCase(75, 2)]
    public void DemeritPointsCalculator_WhenCalled_ReturnsDemeritPoints(int speed, int demeritPoints)
    {
        // Arrange & Act
        int result = DemeritPointsCalculator.Run(speed);

        // Assert
        Assert.That(result, Is.EqualTo(demeritPoints));
    }
}

