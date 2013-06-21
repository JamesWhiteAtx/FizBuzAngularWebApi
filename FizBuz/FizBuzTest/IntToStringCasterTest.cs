using FizBuzLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FizBuzTest
{
    /// <summary>
    ///This is a test class for IntToStringCaster
    ///</summary>
    [TestClass()]
    public class IntToStringCasterTest
    {

        public IntToStringCaster CreateFizBuzCaster()
        {
            IntToStringCaster target = new IntToStringCaster();
            return  target;
        }

        /// <summary>
        ///A test for IntToStringCaster.CastCollection
        ///</summary>
        [TestMethod()]
        public void IntToStringCasterCastCollectionCastIntListToConcatenatedStrings()
        {
            IntToStringCaster target = CreateFizBuzCaster();
            ICollection<string> list = new List<string> { "","",""};
            string expected = String.Join(String.Empty, list);
            string actual;
            actual = target.CastCollection(list);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IntToStringCaster.Cast
        ///</summary>
        [TestMethod()]
        public void IntToStringCasterCastCastsIntToStr()
        {
            IntToStringCaster target = CreateFizBuzCaster();
            int item = 5;
            string expected = item.ToString();
            string actual;
            actual = target.Cast(item);
            Assert.AreEqual(expected, actual);
        }
    }
}
