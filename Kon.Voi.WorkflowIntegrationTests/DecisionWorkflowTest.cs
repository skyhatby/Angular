using System;
using System.Web.Mvc;
using Kon.Voi.Model.DecisionModels.ViewModels;
using Kon.Voi.Workflow.Decision;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity.Mvc;
using WebApp;

namespace Kon.Voi.WorkflowIntegrationTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class DecisionWorkflowTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionWorkflowTest"/> class.
        /// </summary>
        public DecisionWorkflowTest()
        {
            this.DependencyResolver = new UnityDependencyResolver(WebApp.App_Start.UnityConfig.GetConfiguredContainer());
        }
        /// <summary>
        /// Gets or sets the unity container.
        /// </summary>
        /// <value>
        /// The unity container.
        /// </value>
        public UnityDependencyResolver DependencyResolver { get; set; }

        /// <summary>
        /// Gets or sets the decision workflow.
        /// </summary>
        /// <value>
        /// The decision workflow.
        /// </value>
        public IDecisionWorkflow DecisionWorkflow { get; set; }

        /// <summary>
        /// Decisions the workflow count decision when passed normal data than returns correct data.
        /// </summary>
        [TestMethod]
        public void DecisionWorkflowCountDecision_PassedNormalData_returnsCorrectData()
        {
            AutoMapperConfiguration.Configure();
            this.DecisionWorkflow = DependencyResolver.GetService<IDecisionWorkflow>();
            DecisionViewModel decisionViewModel = new DecisionViewModel();

            this.DecisionWorkflow.CountDecision(decisionViewModel);
            //var c = UnityContainer.

        }
    }
}
