using NUnit.Framework;
using System;
using EasyReturnValues;

namespace EasyReturnValuesTest
{
    [TestFixture()]
    public class TestError
    {
        [Test()]
        public void TestAnErrorReturnsAnErrorOnUnwrapWithErrorConstructor()
        {
            Result<int, String> str = Result<int, String>.Error("Error thrown!!");
            Assert.Throws<FailedException>(() => str.Unwrap());
        }

        [Test()]
        public void TestGetAnErrorWhenThereIsAnErrorAndThrowsAnExceptionIfTryingToGetValue()
        {
            Result<int, String> str = new Result<int, String>(1);
            Assert.IsTrue(str.IsOk());
            Assert.IsFalse(str.IsErr());
            Assert.AreEqual(str.Unwrap(), 1);
            Assert.Throws<FailedException>(() => str.GetErr());
        }
    }
}
