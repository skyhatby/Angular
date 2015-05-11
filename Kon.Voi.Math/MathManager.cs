using System;
using System.Collections.Generic;
using System.Linq;
using Kon.Voi.Math.Decision;
using Kon.Voi.Model.DecisionModels;

namespace Kon.Voi.Math
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMathManager
    {
        /// <summary>
        /// Counts the global decision.
        /// </summary>
        /// <param name="decisionSession">The decision session.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref /> or <paramref /> is null.</exception>
        /// <exception cref="OverflowException">The number of elements in <paramref /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref /> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1" />.</exception>
        /// <exception cref="NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IList`1" /> is read-only.</exception>
        Model.DecisionModels.Decision CountGlobalDecision(Model.DecisionModels.Decision decisionSession);

        /// <summary>
        /// Counts the decision.
        /// </summary>
        /// <param name="decisionSession">The decision session.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref /> or <paramref /> is null.</exception>
        Model.DecisionModels.Decision CountDecision(Model.DecisionModels.Decision decisionSession);
    }

    /// <summary>
    /// 
    /// </summary>
    public class MathManager : IMathManager
    {
        /// <summary>
        /// The _decision math
        /// </summary>
        private readonly IDecisionMath _decisionMath;

        /// <summary>
        /// Initializes a new instance of the <see cref="MathManager"/> class.
        /// </summary>
        /// <param name="decisionMath">The decision math.</param>
        public MathManager(IDecisionMath decisionMath)
        {
            this._decisionMath = decisionMath;
        }

        /// <summary>
        /// Counts the global decision.
        /// </summary>
        /// <param name="decisionSession">The decision session.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref /> or <paramref /> is null.</exception>
        /// <exception cref="OverflowException">The number of elements in <paramref /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref /> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1" />.</exception>
        /// <exception cref="NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IList`1" /> is read-only.</exception>
        public Model.DecisionModels.Decision CountGlobalDecision(Model.DecisionModels.Decision decisionSession)
        {
            foreach (DecisionSubject decisionSubject in decisionSession.DecisionArray)
            {
                double[] criteriaRateArray = decisionSubject.CriteriaArray.Select(x => (double)x.Rate).ToArray();
                double[] countedPrioritise = this._decisionMath.CountPriorities(criteriaRateArray);
                int count = decisionSubject.CriteriaArray.Count();
                for (int i = 0; i < count; i++)
                {
                    decisionSubject.CriteriaArray[i].CriterionPriority = countedPrioritise[i];
                }
            }

            this.CountLocalPriorities(decisionSession);

            return this.CountDecision(decisionSession);
        }

        /// <summary>
        /// Counts the local priorities.
        /// </summary>
        /// <param name="decisionSession">The decision session.</param>
        private void CountLocalPriorities(Model.DecisionModels.Decision decisionSession)
        {
            for (int i = 0; i < decisionSession.DecisionArray.First().CriteriaArray.Count(); i++)
            {
                List<Criterion> list = decisionSession.DecisionArray.Select(decisionSubject => decisionSubject.CriteriaArray[i]).ToList();
                double[] c = this._decisionMath.CountPriorities(list.Select(x => (double)x.ValueRate).ToArray());
                for (int j = 0; j < c.Length; j++)
                {
                    list[j].ValuePriority = c[j];
                }
            }
        }

        /// <summary>
        /// Counts the decision.
        /// </summary>
        /// <param name="decisionSession">The decision session.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref /> or <paramref /> is null.</exception>
        public Model.DecisionModels.Decision CountDecision(Model.DecisionModels.Decision decisionSession)
        {
            foreach (DecisionSubject decisionSubject in decisionSession.DecisionArray)
            {
                decisionSubject.FinalRate = decisionSubject.CriteriaArray
                    .Sum(criterion => criterion.CriterionPriority * criterion.ValuePriority);
            }
            return decisionSession;
        }
    }
}