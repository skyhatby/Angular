using Kon.Voi.Model.DecisionModels.ViewModels;

namespace Kon.Voi.Workflow.Decision
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDecisionWorkflow
    {
        /// <summary>
        /// Counts the decision.
        /// </summary>
        /// <param name="decision">The decision.</param>
        DecisionViewModel CountDecision(DecisionViewModel decision);
    }
}