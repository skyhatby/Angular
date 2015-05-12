using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kon.Voi.Workflow.Decision;
using WebApp.Models;
using WebApp.Models.Decision;

namespace WebApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DecisionController : ApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionController"/> class.
        /// </summary>
        /// <param name="decisionWorkflow">The decision workflow.</param>
        public DecisionController(IDecisionWorkflow decisionWorkflow)
        {
            this.DecisionWorkflow = decisionWorkflow;
        }

        /// <summary>
        /// Gets or sets the decision workflow.
        /// </summary>
        /// <value>
        /// The decision workflow.
        /// </value>
        public IDecisionWorkflow DecisionWorkflow { get; set; }

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
