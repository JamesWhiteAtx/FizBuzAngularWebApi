using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizBuzLib;

namespace FizBuzTest
{
    ///This is a test class for DivisorChecker 
    ///</summary>

    [TestClass]
    public class DivisorCheckerTest
    {
        string tick = "Tick";
        string tack = "Tack";
        string toe = "Toe";
        DivisorChecker divChecker;

        /// <summary>
        /// Method to set up DivisorChecker with list from 0 to 15, and demoniators of 3, 5, and 7
        /// </summary>
        [TestInitialize]
        public void SetupFixBuzProtoForTest()
        {
            divChecker = new DivisorChecker();
            divChecker.RangeFrom = 0;
            divChecker.RangeTo = 16;
            divChecker.AddDivisor(3, tick);
            divChecker.AddDivisor(5, tack);
            divChecker.AddDivisor(7, toe);
        }

        /// <summary>
        /// Test that output is instance of IEnumerable<string>
        /// </summary>
        [TestMethod]
        public void DivisorCheckerIsEnumerableOfStringTest()
        {
            Assert.IsInstanceOfType(divChecker.DivisorsList(), typeof(IEnumerable<string>));
        }

        /// <summary>
        /// Test that the Enumerable output has one item for each list member
        /// </summary>
        [TestMethod]
        public void DivisorCheckerToListIsTheCorrectLenghtTest()
        {
            Assert.AreEqual(divChecker.DivisorsList().ToList().Count, 16);
        }

        /// <summary>
        /// Test that actual output enumerable has the expected values
        /// </summary>
        [TestMethod]
        public void DivisorCheckerListOfFifteenMatchesEnumerableResultTest()
        {
            var expectedList = new[] { tick + tack + toe, "1", "2", tick, "4", tack, tick, toe, "8", tick, tack, "11", tick, "13", toe, tick + tack };
            var fizBuzList = divChecker.DivisorsList().ToList();
            CollectionAssert.AreEqual(fizBuzList, expectedList);
        }
    }
}
