using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity.Mvc;

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
            this.UnityContainer = new UnityDependencyResolver(WebApp.App_Start.UnityConfig.GetConfiguredContainer());
        }
        /// <summary>
        /// Gets or sets the unity container.
        /// </summary>
        /// <value>
        /// The unity container.
        /// </value>
        public UnityDependencyResolver UnityContainer { get; set; }

        [TestMethod]
        public void TestMethod1()
        {

            //var c = UnityContainer.

        }
    }
}
