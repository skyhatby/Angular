using System;
using System.Collections.Generic;
using Kon.Voi.Math;
using Kon.Voi.Math.Decision;

namespace Kon.Voi.Workflow.Decision
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDecisionExecutionComponent
    {
        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="decisionSession">The decision session.</param>
        void Execute(Model.DecisionModels.Decision decisionSession);
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecisionCountComponent : IDecisionExecutionComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionCountComponent"/> class.
        /// </summary>
        /// <param name="mathManager">The math manager.</param>
        public DecisionCountComponent(IMathManager mathManager)
        {
            this.MathManager = mathManager;
        }

        /// <summary>
        /// Gets or sets the math manager.
        /// </summary>
        /// <value>
        /// The math manager.
        /// </value>
        public IMathManager MathManager { get; set; }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="decisionSession">The decision session.</param>
        /// <returns></returns>
        /// <exception cref="OverflowException">The number of elements in <paramref /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public void Execute(Model.DecisionModels.Decision decisionSession)
        {
            this.MathManager.CountGlobalDecision(decisionSession);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecisionWorkflow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionWorkflow"/> class.
        /// </summary>
        public DecisionWorkflow(IMathManager mathManager)
        {
            this.DecisionExecutionComponents = new List<IDecisionExecutionComponent>
            {
                new DecisionCountComponent(mathManager)
            };
        }

        /// <summary>
        /// Gets or sets the decision execution components.
        /// </summary>
        /// <value>
        /// The decision execution components.
        /// </value>
        public IEnumerable<IDecisionExecutionComponent> DecisionExecutionComponents { get; set; }

        /// <summary>
        /// Counts the decision.
        /// </summary>
        /// <param name="decision">The decision.</param>
        public void CountDecision(Model.DecisionModels.Decision decision)
        {
            foreach (IDecisionExecutionComponent decisionExecutionComponent in this.DecisionExecutionComponents)
            {
                decisionExecutionComponent.Execute(decision);
            }
        }
    }
}
