using System;
using NUnit.Framework;

namespace IntegerExtensions.NUnitTests
{
    using System.Diagnostics;

    [TestFixture]
    public class IntegerExtensionNUnitTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumber_Test(int number)
        {
            return IntegerExtension.FindNextBiggerNumber(number);
        }

        [TestCase(-45)]
        public void FindNextBiggerNumber_ThrowsArgumentOutOfRangeException(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => IntegerExtension.FindNextBiggerNumber(number));
        }

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int GetMethodTime_Test(int number)
        {
            var tuple = IntegerExtension.GetMethodTime(number);
            Debug.WriteLine($"Time elapsed: {tuple.Item2} milliseconds.");
            return tuple.Item1;
        }
    }
}
