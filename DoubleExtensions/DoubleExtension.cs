using System;

namespace DoubleExtensions
{
    /// <summary>
    /// Class of finding Nth root method.
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Method which finds root of specific degree of number.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="degree">Degree of root.</param>
        /// <param name="precision">Precision with which the calculations are performed.</param>
        /// <returns>Root of number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when values of degree or precision are out of range.</exception>
        /// <exception cref="ArgumentException">Thrown when root's degree is even for calculation with negative numbers.</exception>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (degree < 0)
            {
                throw new ArgumentOutOfRangeException($"{degree} is out of range.");
            }

            if (precision <= 0 || precision >= 1)
            {
                throw new ArgumentOutOfRangeException($"{precision} is out of range.");
            }

            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException("Root's degree cannot be even for calculation with negative numbers.");
            }

            if (degree == 1)
            {
                return number;
            }

            double current = 1;
            double next = (((degree - 1) * current) + (number / Math.Pow(current, degree - 1))) / degree;
            while (Math.Abs(next - current) > precision)
            {
                current = next;
                next = (((degree - 1) * current) + (number / Math.Pow(current, degree - 1))) / degree;
            }

            return next;
        }   
    }
}
