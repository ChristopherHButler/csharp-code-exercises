using System;
namespace CodeExercises.Exercises
{
    /***
     * For every 5 kilometer over the speed limit, a driver will lose 1pt.
     * The speed cannot be negative or greater than 300km/h or it shoudl throw an exception.
     */
    public class DemeritPointsCalculator
    {
        private const int speedLimit = 65;
        private const int MaxSpeed = 300;

        public static int Run(int driverSpeed)
        {
            if (driverSpeed < 0 || driverSpeed > MaxSpeed)
                throw new ArgumentOutOfRangeException();

            if (driverSpeed <= speedLimit)
                return 0;

            const int kmPerDemeritPoint = 5;

            var demeritPoints = (driverSpeed - speedLimit) / kmPerDemeritPoint;

            return demeritPoints;
        }
    }
}

