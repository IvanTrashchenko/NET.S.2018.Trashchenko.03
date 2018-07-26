using System;
using System.Diagnostics;

namespace IntegerGcdExtensions
{
    /// <summary>
    /// Class of methods for computing GCD.
    /// </summary>
    public static class IntegerGcdExtension
    {
        #region EuclidGCD methods

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
        /// Method which computes GCD of three numbers using Euclid's algorithm.
        /// </summary>
        /// <param name="numberFirst">First number.</param>
        /// <param name="numberSecond">Second number.</param>
        /// <param name="numberThird">Third number.</param>
        /// <returns>GCD of source numbers.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when source numbers are out of range.</exception>
        public static int EuclidGcd(int numberFirst, int numberSecond, int numberThird) =>
            ThreeNumsGcd(EuclidGcd, numberFirst, numberSecond, numberThird);

        /// <summary>
        /// Method which computes GCD of optional amount of numbers using Euclid's algorithm.
        /// </summary>
        /// <param name="numbers">Numbers array.</param>
        /// <returns>GCD of source numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when initial parameters are incorrect. </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when source numbers are out of range.</exception>
        public static int EuclidGcd(params int[] numbers) => ParamsGcd(EuclidGcd, numbers);

        /// <summary>
        /// Method which finds the time Euclid's method takes to compute GCD of specicfic numbers.
        /// </summary>
        /// <param name="numbers">Numbers array.</param>
        /// <returns>Tuple element of type (result GCD, elapsed time in ticks).</returns>
        public static (int, long) GetEuclidGcdTime(params int[] numbers)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int result = EuclidGcd(numbers);
            watch.Stop();
            return (result, watch.ElapsedTicks);
        }

        #endregion

        #region SteinGCD methods

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
        /// Method which computes GCD of three numbers using Stein's algorithm.
        /// </summary>
        /// <param name="numberFirst">First number.</param>
        /// <param name="numberSecond">Second number.</param>
        /// <param name="numberThird">Third number.</param>
        /// <returns>GCD of source numbers.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when source numbers are out of range.</exception>
        public static int SteinGcd(int numberFirst, int numberSecond, int numberThird) => 
            ThreeNumsGcd(SteinGcd, numberFirst, numberSecond, numberThird);

        /// <summary>
        /// Method which computes GCD of optional amount of numbers using Stein's algorithm.
        /// </summary>
        /// <param name="numbers">Numbers array.</param>
        /// <returns>GCD of source numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when initial parameters are incorrect. </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when source numbers are out of range.</exception>
        public static int SteinGcd(params int[] numbers) => ParamsGcd(SteinGcd, numbers);

        /// <summary>
        /// Method which finds the time Stein's method takes to compute GCD of specicfic numbers.
        /// </summary>
        /// <param name="numbers">Numbers array.</param>
        /// <returns>Tuple element of type (result GCD, elapsed time in ticks).</returns>
        public static (int, long) GetSteinGcdTime(params int[] numbers)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int result = SteinGcd(numbers);
            watch.Stop();
            return (result, watch.ElapsedTicks);
        }

        #endregion

        #region Delegate methods

        private static int ParamsGcd(Func<int, int, int> gcdMethod, params int[] numbers)
        {
            if (gcdMethod == null)
            {
                throw new ArgumentNullException($"{nameof(gcdMethod)} can not be null.");
            }

            if (numbers == null)
            {
                throw new ArgumentNullException($"{nameof(numbers)} can not be null.");
            }

            if (numbers.Length == 0 || numbers.Length == 1)
            {
                throw new ArgumentException("Number of method parameters can not be less than two.");
            }

            int gcd = gcdMethod(numbers[0], numbers[1]);

            if (numbers.Length == 2)
            {
                return gcd;
            }

            for (int i = 2; i < numbers.Length; i++)
            {
                gcd = gcdMethod(gcd, numbers[i]);
            }

            return gcd;
        }

        private static int ThreeNumsGcd(Func<int, int, int> gcdMethod, int numberFirst, int numberSecond, int numberThird)
        {
            if (gcdMethod == null)
            {
                throw new ArgumentNullException($"{nameof(gcdMethod)} can not be null.");
            }

            int gcd = gcdMethod(numberFirst, numberSecond);
            return gcdMethod(gcd, numberThird);
        }

        #endregion
    }
}