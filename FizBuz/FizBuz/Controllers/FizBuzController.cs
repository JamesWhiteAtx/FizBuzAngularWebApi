using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Configuration;
using System.Configuration;
using Newtonsoft.Json;
using FizBuz.Models;

namespace FizBuz.Controllers
{
    public class FizBuzController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get(int from, int thru, string denoms, string tokens)
        {
            DivEval divEval = new DivEval { 
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
            
            string json = JsonConvert.SerializeObject(divEval);
            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
        }

    }
}
