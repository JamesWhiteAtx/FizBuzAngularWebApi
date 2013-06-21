using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FizBuzLib;

namespace FizBuz.Models
{
    public class EvalToken
    {
        [Display(Name = "Denominator")]
        public int Denominator { get; set; }

        [Display(Name = "Token")]
        public string Token { get; set; }
    }

    public class DivEval
    {
        private IEnumerable<string> results = new List<string>();

        private List<EvalToken> evals = new List<EvalToken> ();

        [Display(Name = "From")]
        public int From { get; set; }

        [Display(Name = "Thru")]
        public int Thru { get; set; }

        public List<EvalToken> Evals { get { return evals; } }

        public EvalToken AddEval(int value, string token)
        {
            var eval = new EvalToken { Denominator = value, Token = token };
            return eval;
        }
        
        public IEnumerable<string> Results { get {
            DivisorChecker div = new DivisorChecker
            {
                RangeFrom = From,
                RangeTo = Thru
            };
            foreach (var eval in evals)
            {
                div.AddDivisor(eval.Denominator, eval.Token);    
            }

            return div.DivisorsList();
        } }
    }
}