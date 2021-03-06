﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Kon.Voi.Math;
using Kon.Voi.Math.Decision;
using Kon.Voi.Model.DecisionModels;
using Kon.Voi.Model.DecisionModels.ViewModels;

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
    public class DecisionResultWorkflowComponent : IDecisionExecutionComponent
    {
        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="decisionSession">The decision session.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Execute(Model.DecisionModels.Decision decisionSession)
        {
            foreach (DecisionSubject decisionSubject in decisionSession.DecisionArray)
            {
                decisionSubject.FinalRate = System.Math.Round(decisionSubject.FinalRate * 100);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecisionWorkflow : IDecisionWorkflow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionWorkflow"/> class.
        /// </summary>
        public DecisionWorkflow(IMathManager mathManager)
        {
            this.DecisionExecutionComponents = new List<IDecisionExecutionComponent>
            {
                new DecisionCountComponent(mathManager),
                new DecisionResultWorkflowComponent()
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
        public DecisionViewModel CountDecision(DecisionViewModel decision)
        {
            Model.DecisionModels.Decision workflowDecision = Mapper.Map<Model.DecisionModels.Decision>(decision);

            foreach (IDecisionExecutionComponent decisionExecutionComponent in this.DecisionExecutionComponents)
            {
                decisionExecutionComponent.Execute(workflowDecision);
            }

            return Mapper.Map<DecisionViewModel>(workflowDecision);
        }
    }
}
