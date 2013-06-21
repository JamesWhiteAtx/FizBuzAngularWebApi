using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizBuzLib
{
    /// <summary>
    /// Orginal solution, now refactored using the configurable DivisorChecker
    /// Produces a list strings from 1 to 100, either displaying the interger, or if divisable 3 then "Fiz", or if divisable 5 then "Buz"
    /// </summary>
    public class FizBuz
    {
        public static IEnumerable<string> FizBuzList()
        {
            DivisorChecker divChecker = new DivisorChecker();
            divChecker.RangeFrom = 1;
            divChecker.RangeTo = 100;
            divChecker.AddDivisor(3, "Fiz");
            divChecker.AddDivisor(5, "Buz");
            return divChecker.DivisorsList();
        }
    }


}
