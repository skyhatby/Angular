using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kon.Voi.Model.DecisionModels;
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
        /// Gets the test data.
        /// </summary>
        /// <returns></returns>
        public DecisionViewModel GetTestData()
        {
            return new DecisionViewModel
            {
                Id = "0",
                SessionName = "testData",
                DecisionArray = new DecisionSubjectViewModel[]{
                    new DecisionSubjectViewModel  {
                        Id= "0",
                        Name = "iPhone",
                        CriteriaArray = new CriterionViewModel[]{
                            new CriterionViewModel{
                                Id =  "0",
                                Name =  "design",
                                Rate =  1,
                                Value =  "brand",
                                ValueRate =  1
                            },
                            new CriterionViewModel{
                                Id =  "1",
                                Name =  "price",
                                Rate =  1,
                                Value =  "1000",
                                ValueRate =  1
                            }
                        }
                    },
                    new DecisionSubjectViewModel {
                        Id =  "1",
                        Name =  "Nokia Lumia 930",
                        CriteriaArray = new CriterionViewModel[] {
                            new CriterionViewModel{
                                Id =  "0",
                                Name =  "design",
                                Rate =  1,
                                Value =  "brand",
                                ValueRate =  1
                            },
                            new CriterionViewModel{
                                Id =  "1",
                                Name =  "price",
                                Rate =  1,
                                Value =  "400",
                                ValueRate =  1
                            }
                        }
                    },
                    new DecisionSubjectViewModel {
                        Id =  "2",
                        Name =  "Samsung Galaxy S5",
                        CriteriaArray =  new CriterionViewModel[] {
                            new CriterionViewModel{
                                Id = "0",
                                Name =  "design",
                                Rate =  1,
                                Value =  "brand",
                                ValueRate =  1
                            },
                            new CriterionViewModel{
                                Id =  "1",
                                Name =  "price",
                                Rate =  1,
                                Value =  "700",
                                ValueRate =  1
                            }
                        }
                    }
                }
            };
        }

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
        /// <exception cref="ArgumentNullException"><paramref /> or <paramref /> is null.</exception>
        [TestMethod]
        public void DecisionWorkflowCountDecision_PassedNormalData_returnsCorrectData()
        {
            AutoMapperConfiguration.Configure();
            this.DecisionWorkflow = this.DependencyResolver.GetService<IDecisionWorkflow>();
            DecisionViewModel workingDecision = this.GetTestData();

            DecisionViewModel result = this.DecisionWorkflow.CountDecision(workingDecision);

            IEnumerable<bool> assertResult = result.DecisionArray.Select(x => Math.Abs(x.FinalRate - 33) < 1);
            Assert.IsNotNull(result.DecisionArray.Any(x => Math.Abs(x.FinalRate - 33) < 1));
            Assert.IsTrue(assertResult.Count() == 3);
        }
    }
}
