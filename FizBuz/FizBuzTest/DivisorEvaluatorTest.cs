using FizBuzLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FizBuzTest
{
    /// <summary>
    ///This is a test class for DivisorEvaluatorTest
    ///It tests if the first parameter of the Evaluate() is divisable by the second
    ///</summary>
    [TestClass()]
    public class DivisorEvaluatorTest
    {
        public DivisorEvaluator CreateFizBuzEvaluator()
        {
            DivisorEvaluator target = new DivisorEvaluator();
            return target;
        }

        /// <summary>
        ///Test if 6 and 3 evaluate to true
        ///</summary>
        [TestMethod()]
        public void DivisorEvaluatorEvalutesSixDivisibleByThreeTest()
        {
            DivisorEvaluator target = CreateFizBuzEvaluator();
            int l = 6;
            int v = 3;
            bool expected = true; 
            bool actual;
            actual = target.Evaluate(l, v);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Test if 7 and 3 evaluate to false
        ///</summary>
        [TestMethod()]
        public void DivisorEvaluatorEvalutesSevenIsNotDivisibleBy3Test()
        {
            DivisorEvaluator target = CreateFizBuzEvaluator();
            int l = 7;
            int v = 3;
            bool expected = true;
            bool actual;
            actual = target.Evaluate(l, v);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
