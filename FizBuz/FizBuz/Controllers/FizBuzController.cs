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
using FizBuz.Services;

namespace FizBuz.Controllers
{
    public class FizBuzController : ApiController
    {
        IFizBuzService fizBuzService;

        public FizBuzController(IFizBuzService service)
        {
            fizBuzService = service;
        }

        // GET api/FizBuz
        public HttpResponseMessage Get(int from, int thru, string denoms, string tokens)
        {
            string json = fizBuzService.SerializedFizBuz(from, thru, denoms, tokens);

            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
        }

    }
}
