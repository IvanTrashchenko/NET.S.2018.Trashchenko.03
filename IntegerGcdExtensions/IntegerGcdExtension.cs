using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IntegerGcdExtensions
{
    /// <summary>
    /// Class of methods for computing GCD.
    /// </summary>
    public static class IntegerGcdExtension
    {
        /// <summary>
        /// Method which computes GCD of two numbers using Euclid's algorithm.
        /// </summary>
        /// <param name="numberFirst">First number.</param>
        /// <param name="numberSecond">Second number.</param>
        /// <returns>GCD of source numbers.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when source numbers are out of range.</exception>
        public static int EuclidGcd(int numberFirst, int numberSecond)
        {
            if (numberFirst < 0)
            {
                throw new ArgumentOutOfRangeException($"{numberFirst} is out of range.");
            }

            if (numberSecond < 0)
            {
                throw new ArgumentOutOfRangeException($"{numberSecond} is out of range.");
            }

            if (numberFirst == numberSecond)
            {
                return numberFirst;
            }

            if (numberFirst == 0)
            {
                return numberSecond;
            }

            if (numberSecond == 0)
            {
                return numberFirst;
            }

            while (numberFirst != numberSecond)
            {
                if (numberFirst > numberSecond)
                {
                    numberFirst = numberFirst - numberSecond;
                }
                else
                {
                    numberSecond = numberSecond - numberFirst;
                }
            }

            return numberFirst;
        }

        /// <summary>
        /// Method which computes GCD of optional amount of numbers using Euclid's algorithm.
        /// </summary>
        /// <param name="numberFirst">First number.</param>
        /// <param name="numberSecond">Second number.</param>
        /// <param name="array">Optional numbers.</param>
        /// <returns>GCD of source numbers.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when source numbers are out of range.</exception>
        public static int EuclidGcd(int numberFirst, int numberSecond, params int[] array)
        {
            int gcd = EuclidGcd(numberFirst, numberSecond);

            if (array.Length == 0)
            {
                return gcd;
            }

            Queue<int> queue = new Queue<int>(array);

            return EuclidGcd(gcd, queue.Dequeue(), queue.ToArray());
        }

        /// <summary>
        /// Method which finds the time Euclid's method takes to compute GCD of specicfic numbers.
        /// </summary>
        /// <param name="numberFirst">First number.</param>
        /// <param name="numberSecond">Second number.</param>
        /// <param name="array">Optional numbers.</param>
        /// <returns>Elapsed time of type (TimeSpan).</returns>
        public static TimeSpan GetEuclidGcdTime(int numberFirst, int numberSecond, params int[] array)
        {
            Stopwatch watch = Stopwatch.StartNew();
            EuclidGcd(numberFirst, numberSecond, array);
            watch.Stop();
            return watch.Elapsed;
        }

        /// <summary>
        /// Method which computes GCD of two numbers using Stein's algorithm.
        /// </summary>
        /// <param name="numberFirst">First number.</param>
        /// <param name="numberSecond">Second number.</param>
        /// <returns>GCD of source numbers.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when source numbers are out of range.</exception>
        public static int SteinGcd(int numberFirst, int numberSecond)
        {
            if (numberFirst < 0)
            {
                throw new ArgumentOutOfRangeException($"{numberFirst} is out of range.");
            }

            if (numberSecond < 0)
            {
                throw new ArgumentOutOfRangeException($"{numberSecond} is out of range.");
            }

            if (numberFirst == numberSecond)
            {
                return numberFirst;
            }

            if (numberFirst == 0)
            {
                return numberSecond;
            }

            if (numberSecond == 0)
            {
                return numberFirst;
            }

            if ((~numberFirst & 1) != 0)
            {
                if ((numberSecond & 1) != 0)
                {
                    return SteinGcd(numberFirst >> 1, numberSecond);
                }

                return SteinGcd(numberFirst >> 1, numberSecond >> 1) << 1;
            }

            if ((~numberSecond & 1) != 0)
            {
                return SteinGcd(numberFirst, numberSecond >> 1);
            }

            if (numberFirst > numberSecond)
            {
                return SteinGcd((numberFirst - numberSecond) >> 1, numberSecond);
            }

            return SteinGcd((numberSecond - numberFirst) >> 1, numberFirst);
        }

        /// <summary>
        /// Method which computes GCD of optional amount of numbers using Stein's algorithm.
        /// </summary>
        /// <param name="numberFirst">First number.</param>
        /// <param name="numberSecond">Second number.</param>
        /// <param name="array">Optional numbers.</param>
        /// <returns>GCD of source numbers.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when source numbers are out of range.</exception>
        public static int SteinGcd(int numberFirst, int numberSecond, params int[] array)
        {
            int gcd = SteinGcd(numberFirst, numberSecond);

            if (array.Length == 0)
            {
                return gcd;
            }

            Queue<int> queue = new Queue<int>(array);

            return SteinGcd(gcd, queue.Dequeue(), queue.ToArray());
        }

        /// <summary>
        /// Method which finds the time Stein's method takes to compute GCD of specicfic numbers.
        /// </summary>
        /// <param name="numberFirst">First number.</param>
        /// <param name="numberSecond">Second number.</param>
        /// <param name="array">Optional numbers.</param>
        /// <returns>Elapsed time of type (TimeSpan).</returns>
        public static TimeSpan GetSteinGcdTime(int numberFirst, int numberSecond, params int[] array)
        {
            Stopwatch watch = Stopwatch.StartNew();
            SteinGcd(numberFirst, numberSecond, array);
            watch.Stop();
            return watch.Elapsed;
        }
    }
}