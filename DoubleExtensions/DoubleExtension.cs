using System;

namespace DoubleExtensions
{
    /// <summary>
    /// Class of finding Nth root method.
    /// </summary>
    public static class DoubleExtension
    {
        #region Finding root method
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
                throw new ArgumentOutOfRangeException(nameof(degree));
            }

            if (precision <= 0 || precision >= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(precision));
            }

            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException("Root's degree must be even for calculation with negative numbers.");
            }

            if (degree == 1)
            {
                return number;
            }

            if (degree == 0)
            {
                return 1.0;
            }

            double x0 = 1;
            double x1 = (((degree - 1) * x0) + (number / Math.Pow(x0, degree - 1))) / degree;
            while (Math.Abs(x1 - x0) > precision)
            {
                x0 = x1;
                x1 = (((degree - 1) * x0) + (number / Math.Pow(x0, degree - 1))) / degree;
            }

            return Math.Round(x1, precision.ExtractDecimalLength());
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Method which finds length of decimal part of specific precision value.
        /// </summary>
        /// <param name="precision">Source precision value.</param>
        /// <returns>Amount of symbols after dot.</returns>
        private static int ExtractDecimalLength(this double precision)
        {
            int result = 0;
            while (precision < 1)
            {
                precision *= 10;
                result++;
            }

            return result;
        }
        #endregion      
    }
}
