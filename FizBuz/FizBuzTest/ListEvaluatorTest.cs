using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizBuzLib;

namespace FizBuzTest
{
    /// <summary>
    ///This is a test class for ListEvaluatorTest 
    ///</summary>

    [TestClass]
    public class ListEvaluatorTest
    {
        string fiz = "Fiz";
        string buz = "Buz";
        private ICaster<int, string> caster;
        private IEvaluator<int, int> evaluator;
        private ListEvaluator<int, int, string> listEvaler;

        /// <summary>
        /// method to set up ListEvaluatorTest for the range of 0 to 15, with denominators of 3 and 5
        /// injects DivisorEvaluator for evaluating the list and IntToStringCaster to format output
        /// </summary>
        [TestInitialize]
        public void SetupFixBuzProtoForTest()
        {
            IEnumerable<int> list = Enumerable.Range(0, 16);
            List<ValueTokenPair<int, string>> pairs = new List<ValueTokenPair<int, string>> { 
                new ValueTokenPair<int, string> {Value=3, Token=fiz},
                new ValueTokenPair<int, string> {Value=5, Token=buz}
            };

            caster = new IntToStringCaster();
            evaluator = new DivisorEvaluator();
            listEvaler = new ListEvaluator<int, int, string>(list, pairs, caster, evaluator);
        }

        /// <summary>
        /// Test that output is IEnumerable<string>
        /// </summary>
        [TestMethod]
        public void ListEvaluatorIsEnumerableOfStringTest()
        {
            Assert.IsInstanceOfType(listEvaler, typeof(IEnumerable<string>));
        }

        /// <summary>
        /// Test that the Enumerable output has one item for each list member
        /// </summary>
        [TestMethod]
        public void ListEvaluatorToListIsTheCorrectLenghtTest()
        {
            Assert.AreEqual(listEvaler.ToList().Count, 16);
        }

        /// <summary>
        /// Test that actual output enumerable has the expected values
        /// </summary>
        [TestMethod]
        public void ListEvaluatorListOfFifteenMatchesEnumerableResultTest()
        {
            var expectedList = new[] { fiz + buz, "1", "2", fiz, "4", buz, fiz, "7", "8", fiz, buz, "11", fiz, "13", "14", fiz + buz };
            var fizBuzList = listEvaler.ToList();
            CollectionAssert.AreEqual(fizBuzList, expectedList);
        }
    }
}
