using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FizBuz.Models;
using Newtonsoft.Json;

namespace FizBuz.Services
{
    public interface IFizBuzService
    {
        string SerializedFizBuz(int from, int thru, string denoms, string tokens);
    }

    public class FizBuzService : IFizBuzService
    {
        public string SerializedFizBuz(int from, int thru, string denoms, string tokens)
        {
            DivEval divEval = new DivEval
            {
                From = from,
                Thru = thru
            };

            if (!String.IsNullOrWhiteSpace(denoms) && !String.IsNullOrWhiteSpace(tokens))
            {
                string[] strDnArr = denoms.Split(',');
                string[] tokenArr = tokens.Split(',');

                var zip = strDnArr.Zip(tokenArr, (d, t) =>
                {
                    return new EvalToken { Denominator = Convert.ToInt32(d), Token = t };
                });

                foreach (var item in zip)
                {
                    divEval.Evals.Add(item);
                }
            }

            return JsonConvert.SerializeObject(divEval);
        }
    }
}