using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizBuz.Services;
using FizBuz.Models;
using Newtonsoft.Json;

namespace FizBuzTest
{
    [TestClass]
    public class FizBuzServiceTest
    {
        [TestMethod]
        public void FizBuzErviceReturnsSerializedEvalTest()
        {
            int from = 1;
            int thru = 15;
            string denoms = "3,5";
            string tokens = "Fiz,Buz";

            FizBuzService testSrvc = new FizBuzService();

            string srvcResult = testSrvc.SerializedFizBuz(from, thru, denoms, tokens);

            
            DivEval divEval = new DivEval
            {
                From = from,
                Thru = thru
            };

            divEval.Evals.Add(new EvalToken { Denominator = 3, Token = "Fiz" });
            divEval.Evals.Add(new EvalToken { Denominator = 5, Token = "Buz" });

            string expectedResult = JsonConvert.SerializeObject(divEval);

            Assert.AreEqual(srvcResult, expectedResult);

        }
    }
}
