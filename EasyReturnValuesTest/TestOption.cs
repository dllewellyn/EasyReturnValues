using NUnit.Framework;
using System;
using EasyReturnValues;

namespace EasyReturnValuesTest
{
    [TestFixture()]
    public class TestOption
    {
        [Test()]
        public void TestOptionalThrowsException()
        {
            Option<int> option = Option<int>.None();
            Assert.Throws<ArgumentNullException>(() => option.unwrap());
        }

        [Test()]
        public void TestOptionalDoesntThrowExceptionOnNonNone()
        {
            Option<int> option = new Option<int>(5);
            Assert.AreEqual(option.unwrap(), 5);
        }

        [Test()]
        public void TestOptionalReturnsTrueOnIsSome()
        {
            Option<int> option = new Option<int>(5);
            Assert.IsTrue(option.IsSome());
        }

        [Test()]
        public void TestOptionalReturnsTrueOnIsNone()
        {
            Option<int> option = Option<int>.None();
            Assert.IsTrue(option.IsNone());
        }

    }
}
