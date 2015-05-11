using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;
using WebApp.Models.Decision;

namespace WebApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DecisionController : ApiController
    {
        // POST api/values
        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="decisionViewModel">The value.</param>
        [HttpPost]
        public DecisionViewModel Post([FromBody]DecisionViewModel decisionViewModel)
        {
            return decisionViewModel;
        }
    }
}
