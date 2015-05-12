using System;
using System.Collections.Generic;
using System.Linq;
using Kon.Voi.Math.Decision;
using Kon.Voi.Model.DecisionModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kon.Voi.Math.UnitTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class MathManagerTest
    {
        /// <summary>
        /// Gets the math manager.
        /// </summary>
        /// <returns></returns>
        private static IMathManager GetMathManager()
        {
            return new MathManager(new DecisionMath());
        }

        /// <summary>
        /// The _id
        /// </summary>
        private int _id = -1;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        /// <summary>
        /// Gets the criteria.
        /// </summary>
        /// <param name="criteriaRate">The criteria rate.</param>
        /// <param name="criteriaName">Name of the criteria.</param>
        /// <param name="valueRate">The value rate.</param>
        /// <returns></returns>
        private Criterion GetCriteria(int criteriaRate, string criteriaName, int valueRate)
        {
            this.Id++;
            return new Criterion
            {
                Id = "0",
                //Important = true,
                Name = criteriaName,
                Rate = criteriaRate,
                ValueRate = valueRate, 
                Value = "234" 
            };
        }

        /// <summary>
        /// Gets the decision.
        /// </summary>
        /// <returns></returns>
        private Model.DecisionModels.Decision GetDecision()
        {
            IList<Criterion> criterionList = new List<Criterion>
            {
                GetCriteria(3, "asd", 1),
                GetCriteria(4, "qwe3", 5),
                GetCriteria(2, "qwe2", 5),
                GetCriteria(5, "qwe1", 5),
                GetCriteria(5, "zxc", 2)
            };
            DecisionSubject decisionSubject = new DecisionSubject { Id = "0", Name = "1234", CriteriaArray = criterionList };

            IList<Criterion> criterionList1 = new List<Criterion>
            {
                GetCriteria(3, "asd", 3),
                GetCriteria(4, "qwe3", 1),
                GetCriteria(2, "qwe2", 3),
                GetCriteria(5, "qwe1", 2),
                GetCriteria(5, "zxc", 5)
            };
            DecisionSubject decisionSubject1 = new DecisionSubject { Id = "0", Name = "1234", CriteriaArray = criterionList1 };
            return new Model.DecisionModels.Decision
            {
                DecisionArray = new List<DecisionSubject>
                {
                    decisionSubject,
                    decisionSubject1
                }
            };
        }

        /// <summary>
        /// Mathes the manager_ correct data_ returns object with priority.
        /// </summary>
        /// <exception cref="OverflowException">The number of elements in <paramref /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        [TestMethod]
        public void MathManager_CorrectData_ReturnsObjectWithPriority()
        {
            var mathManager = GetMathManager();
            var decisionSession = GetDecision();

            mathManager.CountGlobalDecision(decisionSession);

            foreach (var decisionSubject in decisionSession.DecisionArray)
            {
                Console.WriteLine("Global Decision : " + decisionSubject.FinalRate);
                Console.WriteLine("Criteria:");
                foreach (var criteria in decisionSubject.CriteriaArray)
                {
                    Console.WriteLine("Criteria priority : " + criteria.CriterionPriority + criteria.Name);
                    Console.WriteLine("Value Priority: " + criteria.ValuePriority);
                }
                Console.WriteLine();
            }
            Assert.IsNotNull(decisionSession.DecisionArray.First().FinalRate);
        }
    }
}
