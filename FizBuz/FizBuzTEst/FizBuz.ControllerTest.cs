using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizBuz.Controllers;
using Moq;
using FizBuz.Services;
using System.Net.Http;

namespace FizBuzTest
{
    [TestClass]
    public class FizBuz
    {
        [TestMethod]
        public void FizBuzControllerGetReturnsExpectedResultFromInjectedController()
        {
            int f = 1;
            int t = 15;
            string d = "3,5";
            string k = "Fiz,Buz";

            var mockSrvc = new Mock<IFizBuzService>();
            
            mockSrvc.Setup(srvc => srvc.SerializedFizBuz( It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>() )
            ).Returns(
                (int from, int thru, string denoms, string tokens) => (from.ToString() + thru.ToString() + denoms + tokens)
            );

            string expectResp = mockSrvc.Object.SerializedFizBuz(f, t, d, k);

            HttpResponseMessage mockResp = new HttpResponseMessage { Content = new StringContent(expectResp, System.Text.Encoding.UTF8, "application/json") };


            FizBuzController ctrl = new FizBuzController(mockSrvc.Object);

            HttpResponseMessage testResp = ctrl.Get(f, t, d, k);


            string mockStr = mockResp.Content.ReadAsStringAsync().Result;
            string testStr = testResp.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(mockStr, testStr);
        }
    }
}
