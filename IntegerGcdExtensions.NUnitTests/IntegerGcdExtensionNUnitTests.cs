using System;
using System.Diagnostics;
using NUnit.Framework;

namespace IntegerGcdExtensions.NUnitTests
{
    [TestFixture]
    public class IntegerGcdExtensionNUnitTests
    {
        [TestCase(2, 4, ExpectedResult = 2)]
        [TestCase(13, 13, 13, ExpectedResult = 13)]
        [TestCase(20, 100, 20, ExpectedResult = 20)]
        [TestCase(37, 600, 1, ExpectedResult = 1)]
        [TestCase(0, 624129, 2061517, 18913, ExpectedResult = 18913)]
        [TestCase(16, 52, new int[] { 18, 48 }, ExpectedResult = 2)]
        public int EuclidGcd_Test(int numberFirst, int numberSecond, params int[] array)
        {
            Debug.WriteLine($"Time elapsed: {IntegerGcdExtension.GetEuclidGcdTime(numberFirst, numberSecond, array)}.");
            return IntegerGcdExtension.EuclidGcd(numberFirst, numberSecond, array);
        }

        [TestCase(2, 4, -2)]
        public void EuclidGcd_ThrowsArgumentOutOfRangeException(int numberFirst, int numberSecond, params int[] array)
        {    
            Assert.Throws<ArgumentOutOfRangeException>(() => IntegerGcdExtension.EuclidGcd(numberFirst, numberSecond, array));
        }

        [TestCase(2, 4, ExpectedResult = 2)]
        [TestCase(13, 13, 13, ExpectedResult = 13)]
        [TestCase(20, 100, 20, ExpectedResult = 20)]
        [TestCase(37, 600, 1, ExpectedResult = 1)]
        [TestCase(0, 624129, 2061517, 18913, ExpectedResult = 18913)]
        [TestCase(16, 52, new int[] { 18, 48 }, ExpectedResult = 2)]
        public int SteinGcd_Test(int numberFirst, int numberSecond, params int[] array)
        {
            Debug.WriteLine($"Time elapsed: {IntegerGcdExtension.GetSteinGcdTime(numberFirst, numberSecond, array)}.");
            return IntegerGcdExtension.SteinGcd(numberFirst, numberSecond, array);
        }

        [TestCase(2, -4)]
        public void SteinGcd_ThrowsArgumentOutOfRangeException(int numberFirst, int numberSecond, params int[] array)
        {        
            Assert.Throws<ArgumentOutOfRangeException>(() => IntegerGcdExtension.SteinGcd(numberFirst, numberSecond, array));
        }
    }
}