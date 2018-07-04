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
        [TestCase(new int[] { 18, 48 }, ExpectedResult = 6)]
        public int EuclidGcd_Test(params int[] array)
        {
            var tuple = IntegerGcdExtension.GetEuclidGcdTime(array);
            Debug.WriteLine($"Time elapsed: {tuple.Item2} ticks.");
            return tuple.Item1;
        }

        [TestCase(2, 4, -2)]
        public void EuclidGcd_ThrowsArgumentOutOfRangeException(params int[] array)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => IntegerGcdExtension.GetEuclidGcdTime(array));
        }

        [TestCase(2)]
        public void EuclidGcd_ThrowsArgumentException(params int[] array)
        {
            Assert.Throws<ArgumentException>(() => IntegerGcdExtension.GetEuclidGcdTime(array));
        }

        [TestCase(2, 4, ExpectedResult = 2)]
        [TestCase(13, 13, 13, ExpectedResult = 13)]
        [TestCase(20, 100, 20, ExpectedResult = 20)]
        [TestCase(37, 600, 1, ExpectedResult = 1)]
        [TestCase(0, 624129, 2061517, 18913, ExpectedResult = 18913)]
        [TestCase(new int[] { 18, 48 }, ExpectedResult = 6)]
        public int SteinGcd_Test(params int[] array)
        {
            var tuple = IntegerGcdExtension.GetSteinGcdTime(array);
            Debug.WriteLine($"Time elapsed: {tuple.Item2} ticks.");
            return tuple.Item1;
        }

        [TestCase(2, -4)]
        public void SteinGcd_ThrowsArgumentOutOfRangeException(params int[] array)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => IntegerGcdExtension.GetSteinGcdTime(array));
        }

        [TestCase(2)]
        public void SteinGcd_ThrowsArgumentException(params int[] array)
        {
            Assert.Throws<ArgumentException>(() => IntegerGcdExtension.GetSteinGcdTime(array));
        }
    }
}