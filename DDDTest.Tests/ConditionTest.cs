using DDD.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DDDTest.Tests
{
    [TestClass]
    public class ConditionTest
    {
        [TestMethod]
        public void 晴れかどうかを判定する()
        {
            var c = new Condition(1);
            Assert.AreEqual(true, c.IsSunny());
        }
    }
}
