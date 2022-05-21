using System;

namespace AngryBirds
{
    public static class AngryBirdsTask
    {
        private const double EarthGravity = 9.8;

        private var a = 33;
        
        
        public static double FindSightAngle(double velocity, double distance)
        {
            return Math.Asin((EarthGravity * distance) / (velocity * velocity)) / 2;
        }

        
    }
}