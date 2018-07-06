using System;
using System.Diagnostics;
using System.Linq;

namespace IntegerExtensions
{
    /// <summary>
    /// Class of finding next bigger number method.
    /// </summary>
    public static class IntegerExtension
    {
        #region GetMethodTime method      
        /// <summary>
        /// Testing method for finding FindNextBiggerNumber's value and the time it took to perform the calculations.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Tuple element of type (result number, elapsed time in ticks).</returns>
        public static (int, long) GetNextBiggerNumberTime(int number)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int resultNumber = FindNextBiggerNumber(number);
            watch.Stop();
            return (resultNumber, watch.ElapsedTicks);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Method for finding next bigger number, which consists of the same digits.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Result number if it exists or -1 if it doesn't.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when source number is out of range.</exception>
        private static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException($"{number} cannot be negative.");
            }

            int[] digitArray = number.ToDigitArray();

            if (number < 12 || IsDecreasing(digitArray))
            {
                return -1;
            }

            Array.Sort(digitArray);
            while (true)
            {
                number++;
                int[] tempArray = number.ToDigitArray();
                Array.Sort(tempArray);
                if (tempArray.SequenceEqual(digitArray))
                {
                    break;
                }
            }

            return number;
        }

        /// <summary>
        /// Method which converts the number into the array of its digits.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Array of number's digits.</returns>
        private static int[] ToDigitArray(this int number)
        {
            int[] resultArray = new int[number.ToString().Length];
            for (int i = resultArray.Length - 1; i > -1; i--)
            {
                resultArray[i] = number % 10;
                number /= 10;
            }

            return resultArray;
        }

        /// <summary>
        /// Method which determines whether the array is sorted in descending order.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <returns>True if the array is sorted; otherwise, false.</returns>
        private static bool IsDecreasing(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
        #endregion    
    }
}
